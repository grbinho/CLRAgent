using System;
using System.Collections.Generic;
using System.Text;

namespace CLRAgent.Library
{
    class JobStepResult : ResultBase
    {       
        public String JobUid { get; set; }
        public int StepId { get; set; }
        public int NextStepId { get; set; }
        public int OnErrorStepId { get; set; }
    }
}
