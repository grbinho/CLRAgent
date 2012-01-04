using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Server;
using CLRAgent.Library;
using System.Data.SqlClient;

namespace CLRAgent
{
    class AgentDb
    {
        SqlPipe pipe = SqlContext.Pipe;
        SqlConnection connection = new SqlConnection("context connection=true");

        public void WriteStatusMessage(string message)
        {
            pipe.Send(message);
        }

        public List<Job> CheckSchedule()
        {            
            return null;
        }

        public void LogJobStep(JobStepResult result)
        {
        }

        public void SetJobStatus(ExecutionStatus status, string jobUid)
        {
        }

        public void SetJobStepStatus(ExecutionStatus status, string jobUid, int stepId)
        {
        }


        public void LogJob(JobResult result)
        {
        }

        private List<Operator> GetJobOperators(string jobUid)
        {
            return null;
        }

        private List<JobStep> GetJobSteps(string jobUid)
        {
            return null;
        }
        
    }
}
