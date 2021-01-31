using SchedulerDb.Interface;
using SchedulerDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Scheduler.Controllers.Api
{
    public class CrewSchedulerController : ApiController
    {
        IScheduler _Repo;
        ModelMapping _ModelMapping;

        public CrewSchedulerController(IScheduler Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Scheduler/GetSchedule")]
        public IHttpActionResult GetSchedule()
        {
            List<SchedulerDb.Model.Schedule> sch = new List<SchedulerDb.Model.Schedule>();
            IQueryable<SchedulerDb.ScheduleTbl> Query = null;
            IEnumerable<SchedulerDb.Model.Schedule> ResultList = null;
            try
            {
                Query = _Repo.GetSchedule();
                ResultList = Query.ToList().Select(T => _ModelMapping.GetSchedule(T));

            }catch(Exception ex)
            {

            }


            var res = ResultList.AsQueryable();
            return Ok(new { results = res });

        }
    }
}
