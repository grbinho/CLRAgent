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
        private SqlPipe _pipe = SqlContext.Pipe;
        private SqlConnection _connection = new SqlConnection("context connection=true");

        #region SQL command wrappers
        private SqlCommand GetSQLCommandObject(string database)
        {
            _connection.Open();
            _connection.ChangeDatabase(database);
            return _connection.CreateCommand();
        }

        private void ExecuteNonQuery(string command, string database)
        {
            SqlCommand cmd = GetSQLCommandObject(database);
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private void ExecuteScalar(string command, string database)
        {
            SqlCommand cmd = GetSQLCommandObject(database);
            cmd.CommandText = command;
            cmd.ExecuteScalar();
            cmd.Connection.Close();
        }

        private SqlDataReader ExecuteQuery(string command, string database, SqlParameter[] parameters)
        {
            SqlCommand cmd = GetSQLCommandObject(database);
            cmd.CommandText = command;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteReader();            
        }
        #endregion

        public void WriteStatusMessage(string message)
        {
            _pipe.Send(message);
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
