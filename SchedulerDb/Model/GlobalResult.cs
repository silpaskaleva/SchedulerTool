using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerDb.Model
{
    public class GlobalResult
    {
        public object Result { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
