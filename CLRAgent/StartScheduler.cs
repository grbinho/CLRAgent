using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Threading;
using System.Timers;
using CLRAgent.Library;
using CLRAgent;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void StartScheduler(string databaseName, int waitTimeMs)
    {
        //Declare scheduler timer
        System.Timers.Timer scheduleTimer = new System.Timers.Timer(waitTimeMs);
        scheduleTimer.Elapsed += new ElapsedEventHandler(scheduleTimer_Elapsed);        
        scheduleTimer.AutoReset = true;
        scheduleTimer.Start();
        GC.KeepAlive(scheduleTimer);
        //Start scheduler with wait set to waitTimeMs
            //Check the view for jobs ready for execution
        //Execute those jobs in parallel
        //SqlPipe pipe = SqlContext.Pipe;
        //SqlConnection connection = new SqlConnection("context connection=true");
        //String connectionString = connection.ConnectionString;
        //pipe.Send("Test pipe result");
        //pipe.Send(connectionString);
        //testconnectionclass t = new testconnectionclass();
        //t.openconnection();     
        //agent objects are defined in databaseName

        while(true)
        {                       
        }
    }

    //Check for pending agent jobs
    static void scheduleTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        throw new NotImplementedException();
    }
};
