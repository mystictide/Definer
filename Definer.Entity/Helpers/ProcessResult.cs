using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Entity.Helpers
{
    public class ProcessResult
    {
        public ProcessState State { get; set; }
        public string Message { get; set; }
        public int ReturnID { get; set; }

    }
    public enum ProcessState
    {
        Success = 1,
        Warning = 2,
        Error = 3
    }
}
