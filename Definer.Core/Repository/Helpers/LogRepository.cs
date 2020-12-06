using Dapper.Contrib.Extensions;
using Definer.Core.Interface.Helpers;
using Definer.Entity;
using System;
using System.Diagnostics;
using System.Linq;

namespace Definer.Core.Repository.Helpers
{
    public class LogRepository : Connection.DbConnection, ILog
    {
        public int Add(Log entity)
        {
            try
            {
                using (var con = GetConnection)
                {
                    return (int)con.Insert(entity);
                }
            }
            catch (Exception exception)
            {
                string a = exception.Message;
                return 0;
            }
        }

        public static void CreateLog(Exception ex, int UserId = 0)
        {
            try
            {
                var st = new StackTrace(ex, true);
                if (st != null)
                {
                    st.GetFrames().Where(k => k.GetFileLineNumber() > 0).ToList().ForEach(k =>
                    {
                        new LogRepository().Add(new Log()
                        {
                            CreatedDate = DateTime.Now,
                            UserId = UserId,
                            Message = ex.Message,
                            Source = ex.Source + " | " + k,
                            Line = k.GetFileLineNumber()
                        });
                    });
                }
                else
                {
                    new LogRepository().Add(new Log()
                    {
                        CreatedDate = DateTime.Now,
                        UserId = UserId,
                        Message = ex.Message,
                        Source = ex.Source,
                        Line = 0
                    });
                }
            }
            catch (Exception exception)
            {
                new LogRepository().Add(new Log()
                {
                    CreatedDate = DateTime.Now,
                    UserId = 0,
                    Message = exception.Message,
                    Source = exception.Source + " - Error at CreateLog.",
                    Line = 0
                });
            }


        }
    }
}
