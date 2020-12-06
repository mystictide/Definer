using Dapper;
using Dapper.Contrib.Extensions;
using Definer.Core.Interface;
using Definer.Entity.Helpers;
using System;
using System.Collections.Generic;

namespace Definer.Core.Repository.Users
{
    public class UsersRepository : Connection.DbConnection, IUsers
    {
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
                Helpers.LogRepository.CreateLog(ex);
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
                Helpers.LogRepository.CreateLog(ex);
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
                Helpers.LogRepository.CreateLog(ex);
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
                Helpers.LogRepository.CreateLog(ex);
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
                Helpers.LogRepository.CreateLog(ex);
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
                Helpers.LogRepository.CreateLog(ex);
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
                Helpers.LogRepository.CreateLog(ex);
            }
            return result;
        }
    }
}
