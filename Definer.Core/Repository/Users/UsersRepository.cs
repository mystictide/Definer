using Dapper;
using Dapper.Contrib.Extensions;
using Definer.Core.Interface;
using Definer.Core.Repository.Helpers;
using Definer.Entity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Definer.Core.Repository.Users
{
    public class UsersRepository : Connection.DbConnection, IUsers
    {
        public Entity.Users.Users Login(string Email, string Password)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Email", Email);
                param.Add("@Password", Password);
                string query = $@"SELECT * FROM Users WHERE Email = @Email AND Password = @Password";

                using (var con = GetConnection)
                {
                    return con.QueryFirstOrDefault<Entity.Users.Users>(query, param);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return default;
            }
        }
        public ProcessResult Add(Entity.Users.Users entity)
        {
            ProcessResult result = new ProcessResult();
            try
            {
                using (var con = GetConnection)
                {
                    result.ReturnID = (int)con.Insert(entity);
                    result.Message = "Hesap başarıyla oluşturuldu.";
                    result.State = ProcessState.Success;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.State = ProcessState.Error;
                LogRepository.CreateLog(ex);
            }
            return result;
        }

        public ProcessResult Delete(int ID)
        {
            ProcessResult result = new ProcessResult();
            try
            {
                string query = "DELETE FROM Users WHERE ID = @ID";
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", ID);
                using (var con = GetConnection)
                {
                    int res = con.Execute(query, param);
                    if (res > 0)
                    {
                        result.Message = "Hesap başarıyla silindi.";
                        result.State = ProcessState.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.State = ProcessState.Error;
                LogRepository.CreateLog(ex);
            }
            return result;
        }

        public Entity.Users.Users Get(int ID)
        {
            try
            {
                using (var con = GetConnection)
                {
                    return con.Get<Entity.Users.Users>(ID);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }

        public IEnumerable<Entity.Users.Users> GetAll()
        {
            try
            {
                using (var con = GetConnection)
                {
                    return con.GetAll<Entity.Users.Users>();
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }

        public IEnumerable<Entity.Users.Users> GetAllByIsActive(bool IsActive)
        {
            try
            {
                string query = "SELECT * from Users where IsActive = @IsActive";
                DynamicParameters param = new DynamicParameters();
                param.Add("@IsActive", IsActive);
                using (var con = GetConnection)
                {
                    return con.Query<Entity.Users.Users>(query, param);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }

        public ProcessResult Update(Entity.Users.Users entity)
        {
            ProcessResult result = new ProcessResult();
            try
            {
                using (var con = GetConnection)
                {
                    bool res = con.Update(entity);
                    if (res == true)
                    {
                        result.ReturnID = entity.ID;
                        result.Message = "Hesap başarıyla güncellendi.";
                        result.State = ProcessState.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.State = ProcessState.Error;
                LogRepository.CreateLog(ex);
            }
            return result;
        }

        public ProcessResult UpdateIsActive(int ID, bool IsActive)
        {
            ProcessResult result = new ProcessResult();
            try
            {
                string query = "update Users set IsActive = @IsActive WHERE ID = @ID";
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", ID);
                param.Add("@IsActive", IsActive);
                using (var con = GetConnection)
                {
                    int res = con.Execute(query, param);
                    if (res > 0)
                    {
                        result.ReturnID = ID;
                        result.State = ProcessState.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.State = ProcessState.Error;
                LogRepository.CreateLog(ex);
            }
            return result;
        }

        public bool CheckMail(string Email)
        {
            string Query = @"Select * from Users where Email=@Email";
            DynamicParameters p = new DynamicParameters();
            p.Add("@Email", Email);
            using (var con = GetConnection)
            {
                return !(con.Query<Entity.Users.Users>(Query, p).Count() > 0);
            }
        }
        public bool CheckUsername(string Name)
        {
            string Query = @"Select * from Users where Name=@Name";
            DynamicParameters p = new DynamicParameters();
            p.Add("@Name", Name);
            using (var con = GetConnection)
            {
                return !(con.Query<Entity.Users.Users>(Query, p).Count() > 0);
            }
        }
    }
}
