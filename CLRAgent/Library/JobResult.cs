using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLRAgent.Library
{
    class JobResult : ResultBase
    {
        public String JobUid { get; set; }
        public List<JobStepResult> StepResults { get; set; }
    }
}
