using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerDb.Model
{
    public class ModelMapping
    {
        public Schedule GetSchedule(SchedulerDb.ScheduleTbl sch)
        {
            return new Schedule
            {
                FlightNumber = sch.FlightNumber,
                DaysOfOperation = sch.DaysOfOperation,
                PeriodOfOperation = sch.PeriodOfOperation,
                DepartureTime = sch.DepartureTime.ToString(),
                OriginalStation = sch.OriginalStation,
                DestinationStation = sch.DestinationStation,
                Aircraft = sch.Aircraft
            };
        }
    }
}
