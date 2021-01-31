using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerDb
{
    public class ScheduleContext
    {
        ScheduleEntities _Ctx;
        public ScheduleContext()
        {
            _Ctx = new ScheduleEntities();
        }

        public ScheduleEntities Context
        {
            get
            {
                return this._Ctx;
            }
        }
        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }

    }
}
