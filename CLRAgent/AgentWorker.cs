using System;
using System.Collections.Generic;
using System.Text;
using CLRAgent.Library;
using System.Threading;

namespace CLRAgent
{
    class AgentWorker
    {
        private Job _job;
        private ManualResetEvent _doneEvent;

        public AgentWorker(Job job, ManualResetEvent doneEvent)
        {
            this._job = job;
            this._doneEvent = doneEvent;
        }


        public void RunJobCallback(Object threadContext)
        {
            //Run job
            JobResult result = RunJob(_job);
            //Log result
            _doneEvent.Set();            
        }

        private JobResult RunJob(Job job)
        {
            foreach(JobStep step in job.Steps)
            {
                RunJobStep(step);
            }
            //Log result
            return null;
        }

        private JobStepResult RunJobStep(JobStep step)
        {
            //Run job step            
            return null;
        }
    }
}
