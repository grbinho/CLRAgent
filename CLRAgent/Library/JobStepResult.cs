using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLRAgent.Library
{
    class JobStepResult : ResultBase
    {
       
        public String JobUid { get; set; }
        public int StepId { get; set; }
    }
}
