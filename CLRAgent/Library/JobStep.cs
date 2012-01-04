using System;
using System.Collections.Generic;
using System.Text;

namespace CLRAgent.Library
{
    /// <summary>
    /// Represents job step of an agent job
    /// </summary>
    class JobStep
    {
        public String JobUid { get; set; }        
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int NextStepId { get; set; }
        public Boolean StopOnError { get; set; }
        public int StepIdOnError { get; set; }
        /// <summary>
        /// Restricted to valid T-SQL
        /// </summary>
        public String Definition { get; set; }       
    }
}
