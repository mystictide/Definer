using Dapper;
using Dapper.Contrib.Extensions;
using Definer.Core.Interface.Entries;
using Definer.Core.Repository.Helpers;
using Definer.Entity.Entries;
using Definer.Entity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Core.Repository.Entries
{
    public class ThreadRepository : Connection.DbConnection, IThreads
    {
        public ProcessResult Add(Threads entity)
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
                string query = "DELETE FROM Threads WHERE ID = @ID";
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

        public Threads Get(int ID)
        {
            try
            {
                using (var con = GetConnection)
                {
                    return con.Get<Threads>(ID);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }

        public IEnumerable<Threads> GetAll()
        {
            try
            {
                using (var con = GetConnection)
                {
                    return con.GetAll<Threads>();
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }

        public IEnumerable<Threads> GetAllByIsActive(bool IsActive)
        {
            try
            {
                string query = "SELECT * from Threads where IsActive = @IsActive";
                DynamicParameters param = new DynamicParameters();
                param.Add("@IsActive", IsActive);
                using (var con = GetConnection)
                {
                    return con.Query<Threads>(query, param);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }

        public ProcessResult Update(Threads entity)
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
                string query = "update Threads set IsActive = @IsActive WHERE ID = @ID";
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
    }
}
