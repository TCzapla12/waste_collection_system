namespace PDI.DataServiceDumpsters.Rest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.DataServiceDumpsters.Model;
    using PDI.DataServiceDumpsters.Rest.Model;

    [ApiController]
    [Route("[controller]")]
    public class DumpstersDatabaseController : ControllerBase, IDumpstersDatabaseService, ITestsService
    {
        private readonly ILogger<DumpstersDatabaseController> logger;

        private readonly IDumpstersDatabase dumpstersDatabase;

        public DumpstersDatabaseController(IDumpstersDatabase dumpstersDatabase, ILogger<DumpstersDatabaseController> logger)
        {
            this.logger = logger;

            this.dumpstersDatabase = dumpstersDatabase;
        }

        [HttpPost]
        [Route("AddDumpster")]
        public string AddDumpster(DumpsterData dumpster)
        {
            dumpster.Id = this.dumpstersDatabase.GetNewId();

            return this.dumpstersDatabase.AddDumpster(dumpster.ConvertToDumpster());
        }
        [HttpPut]
        [Route("EditDumpster")]
        public string EditDumpster(DumpsterData dumpster)
        {
            return this.dumpstersDatabase.EditDumpster(dumpster.ConvertToDumpster());   
        }
        [HttpPut]
        [Route("ChangeDumpsterUsage/{id}")]
        public string ChangeDumpsterUsage(string id, int usage)
        {
            return this.dumpstersDatabase.ChangeDumpsterUsage(id, usage);
        }
        [HttpPut]
        [Route("ChangeDumpstersState")]
        public string ChangeDumpstersState(ChangeStateData data)
        {
            return this.dumpstersDatabase.ChangeDumpstersState(data.Ids, (State)Enum.Parse(typeof(State), data.State));
        }
        [HttpDelete]
        [Route("DeleteDumpster/{id}")]
        public string DeleteDumpster(string id)
        {
            return this.dumpstersDatabase.DeleteDumpster(id);
        }
        [HttpGet]
        [Route("GetDumpsters")]
        public DumpsterData[] GetDumpsters()
        {
            Dumpster[] dumpsters = this.dumpstersDatabase.GetDumpsters();

            return dumpsters.Select(dumpster => dumpster.ConvertToDumpsterData()).ToArray();
        }
        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host, int port)
        {
            ITestsService tests = new Tests.Tests(this.dumpstersDatabase);

            return tests.RunTests(host, port);
        }
        [HttpPut]
        [Route("EmptyDumpsters")]
        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters)
        {
            return this.dumpstersDatabase.EmptyDumpsters(emptyDumpsters.Ids);
        }
        
    }
}
