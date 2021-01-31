using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerDb.Interface
{
    public interface IScheduler:IDisposable
    {
        IQueryable<ScheduleTbl> GetSchedule();
        bool AddSchedule(string FlightNumber, string DaysOfOperation, string PeriodOfOperation, string DepartureTime, string OriginalStation, string DestinationStation, string Aircraft);

    }
}
