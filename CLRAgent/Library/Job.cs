using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLRAgent.Library
{
    class Job
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string  Owner { get; set; }
        public String Description { get; set; }
        public Schedule Schedule { get; set; }        
        public DateTime DateCreated { get; set; }
        public DateTime LastRunDateTime { get; set; }
        public DateTime NextRunDateTime { get; set; }
        public ExecutionStatus LastExecutionStatus { get; set; }
        public ExecutionStatus CurrentExecutionStatus { get; set; }
        public List<JobStep> Steps { get; set; }
    }
}
