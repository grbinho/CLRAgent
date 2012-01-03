using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLRAgent.Library
{
    /// <summary>
    /// Represents job step of an agent job. Implements IComparable sorting by ExecutionOrderNumber. Job with number 1 executes first.
    /// ExecutionOrderNumber constrainst are defined in database.
    /// </summary>
    class JobStep: IComparable<JobStep>
    {
        public String JobUid { get; set; }        
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int ExecutionOrderNumber { get; set; }
        /// <summary>
        /// Restricted to valid T-SQL
        /// </summary>
        public String Definition { get; set; }

        public int CompareTo(JobStep other)
        {            
            if (other == null) return 1;

            if (this.ExecutionOrderNumber < other.ExecutionOrderNumber) return -1;
            else if (this.ExecutionOrderNumber == other.ExecutionOrderNumber) return 0;
            else return 1;
        }
    }
}
