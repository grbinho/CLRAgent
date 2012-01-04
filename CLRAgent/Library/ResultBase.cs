using System;
using System.Collections.Generic;
using System.Text;

namespace CLRAgent.Library
{
    class ResultBase
    {
        public Boolean IsError { get; set; }
        public List<String> Messages { get; set; }
        public ExecutionStatus Status { get; set; }
    }
}
