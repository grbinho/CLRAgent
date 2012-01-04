using System;
using System.Collections.Generic;
using System.Text;
using CLRAgent.Library;
using System.Threading;
using Microsoft.SqlServer.Server;

namespace CLRAgent
{
    class Agent
    {
        public delegate void JobSetCompletedDelegate();
        public event JobSetCompletedDelegate JobSetCompleted;

        private void OnJobSetCompleted()
        {
            if (JobSetCompleted != null)
                JobSetCompleted();
        }

        //Private members required for job thread pooling
        ManualResetEvent[] _doneEvents;
        AgentWorker[] _workerArray;
        List<Job> _jobs;

        //Constructor
        public Agent(List<Job> jobs, ManualResetEvent doneEvent)
        {
            if (jobs != null)
            {
                this._jobs = jobs;
                if (jobs.Count > 1)
                {
                    this._doneEvents = new ManualResetEvent[_jobs.Count];
                    this._workerArray = new AgentWorker[_jobs.Count];
                }
            }
        }
        
        //Thread method
        public void RunJobsAsync()
        {
            RunJobs(_jobs);
            OnJobSetCompleted();
        }

        private void RunJobs(List<Job> jobs)
        {                        
            RunWorkers();
        }

        //Run one AgentWorker for each job
        private void RunWorkers()
        {
            for (int i = 0; i < _jobs.Count; i++)
            {
                _doneEvents[i] = new ManualResetEvent(false);
                AgentWorker w = new AgentWorker(_jobs[i], _doneEvents[i]);
                _workerArray[i] = w;
                ThreadPool.QueueUserWorkItem(w.RunJobCallback, i); //umjesto i moze ici bilo koji objekt
            }
            
            WaitHandle.WaitAll(_doneEvents);

            //done with all jobs in this set...
        }        
    }
}
