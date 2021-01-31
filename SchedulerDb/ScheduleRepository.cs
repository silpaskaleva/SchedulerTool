using SchedulerDb.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerDb
{
    public class ScheduleRepository:IScheduler
    {
        ScheduleContext _ctx;
        public ScheduleRepository(ScheduleContext Context)
        {
            _ctx = Context;
            _ctx.Context.Configuration.LazyLoadingEnabled = false;
            _ctx.Context.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<ScheduleTbl> GetSchedule()
        {
            IQueryable<ScheduleTbl> test = null;
            try
            {
                test =_ctx.Context.ScheduleTbls;
            }catch(Exception e)
            {
                //
            }
            return test;
        }
        public bool AddSchedule(string _FlightNumber, string _DaysOfOperation, string _PeriodOfOperation, string _DepartureTime, string _OriginalStation, string _DestinationStation, string _Aircraft)
        {

            bool IsInserted = true;
            try
            {
                _ctx.Context.ScheduleTbls.Add(new ScheduleTbl()
                {
                    FlightNumber = _FlightNumber,
                    DaysOfOperation =_DaysOfOperation,
                    PeriodOfOperation = _PeriodOfOperation,
                    DepartureTime = Convert.ToDateTime(_DepartureTime).TimeOfDay,
                    OriginalStation=_OriginalStation,
                    DestinationStation = _DestinationStation,
                    Aircraft = _Aircraft
                    
                });
                _ctx.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                IsInserted = false;
            }
            return IsInserted;

            return true;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
        }
    }
}
