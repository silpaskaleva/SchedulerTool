using SchedulerDb.Interface;
using SchedulerDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scheduler.Controllers
{
    public class HomeController : Controller
    {
        IScheduler _Repo;
        ModelMapping _ModelMapping;

        public HomeController(IScheduler Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping; 
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetScheduler(int pageIndex, int pageSize,string sortField = "DepartureTime", string sortOrder = "desc")
        {
            IEnumerable < SchedulerDb.ScheduleTbl > ScheduleList = null;
            IQueryable<SchedulerDb.ScheduleTbl> Query = null;
            IEnumerable<SchedulerDb.Model.Schedule> ResultList = null;

            int itemCount = 0;
            var param = sortField;
            var propertyInfo = typeof(SchedulerDb.ScheduleTbl).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {
                    Query = _Repo.GetSchedule();
                    itemCount = Query.Count();

                    switch (sortField)
                    {
                        case "DepartureTime":
                            if(sortOrder == "asc")
                            {
                                ScheduleList = Query.OrderBy(S => S.DepartureTime);
                            }else if(sortOrder == "desc")
                            {
                                ScheduleList = Query.OrderByDescending(S => S.DepartureTime);
                            }
                            break;
                        default:
                            ScheduleList = Query.OrderByDescending(S => S.DepartureTime);
                            break;

                    }

                    ResultList = ScheduleList.Skip(skip)
                        .Take(pageSize).ToList().Select(T => _ModelMapping.GetSchedule(T));
                }
            }
            catch (Exception ex)
            {

            }

            var Result = new { data = ResultList, itemCount = itemCount };
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddSchedule(string FlightNumber, string DaysOfOperation, string PeriodOfOperation, string DepartureTime, string OriginalStation, string DestinationStation, string Aircraft)
        {
            GlobalResult ResultObj = new GlobalResult();

            try
            {

                using (_Repo)
                {

                    ResultObj.IsValid = _Repo.AddSchedule(FlightNumber,DaysOfOperation, PeriodOfOperation, DepartureTime, OriginalStation,DestinationStation,Aircraft);

                    if (!ResultObj.IsValid)
                    {
                        ResultObj.Message = "Unexpected error occurred";
                    }
                }
            }
            catch (Exception ex)
            {
                ResultObj.IsValid = false;
                ResultObj.Message = "Unexpected error occurred";
            }


            return Json(ResultObj, JsonRequestBehavior.AllowGet);
        }
    }
}