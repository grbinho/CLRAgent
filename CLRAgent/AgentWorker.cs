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
        private AgentDb _db;

        public AgentWorker(Job job, ManualResetEvent doneEvent)
        {
            this._db = new AgentDb();
            this._job = job;
            this._doneEvent = doneEvent;
        }


        public void RunJobCallback(Object threadContext)
        {
            //Run job
            _job.CurrentExecutionStatus = ExecutionStatus.Starting;
            JobResult result = RunJob(_job);            
            _db.LogJob(result);
            _db.SetJobStatus(_job.CurrentExecutionStatus, _job.Uid);
            _doneEvent.Set();            
        }

        private JobResult RunJob(Job job)
        {            
            int startJobStep = 1;
            int currentJobStep = startJobStep;
            job.CurrentExecutionStatus = ExecutionStatus.Running;

            while(currentJobStep > 0)
            {
                JobStep step = job.Steps.Find(x => x.Id == currentJobStep);                
                JobStepResult result = RunJobStep(step);
                _db.LogJobStep(result);

                if (result.IsError)
                {
                    if (step.StepIdOnError > 0)
                        currentJobStep = step.StepIdOnError;
                    job.CurrentExecutionStatus = ExecutionStatus.Error;
                }
                else
                {
                    currentJobStep = step.NextStepId;
                }
            }

            job.CurrentExecutionStatus = ExecutionStatus.Finished;            
            //Log result
            return null;
        }

        private JobStepResult RunJobStep(JobStep step)
        {            
            //Run job step          
            //Change job step status
            return null;
        }
    }
}
