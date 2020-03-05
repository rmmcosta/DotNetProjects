public void MssParallelCallApi(string ssGuid, RLApisRecordList ssRequestApis)
        {
            GenericExtendedActions.LogMessage(AppInfo.GetAppInfo().OsContext, "Parallelized initialized!", "ParallelApiCall");

            List<Task> taskList = new List<Task>();

            GenericExtendedActions.LogMessage(AppInfo.GetAppInfo().OsContext, "List of tasks created!", "ParallelApiCall");

            foreach (RCApisRecord recRequest in ssRequestApis)
            {
                GenericExtendedActions.LogMessage(AppInfo.GetAppInfo().OsContext, string.Format("New call, original url:{0}, response url: {1}",recRequest.ssSTApis.ssOriginalApiUrl,recRequest.ssSTApis.ssResponseApiUrl), "ParallelApiCall");
                taskList.Add(Task.Factory.StartNew(() => beginAsyncCall(recRequest.ssSTApis.ssOriginalApiUrl,recRequest.ssSTApis.ssResponseApiUrl,ssGuid)));
                GenericExtendedActions.LogMessage(AppInfo.GetAppInfo().OsContext, "Task added!", "ParallelApiCall");
            }
            GenericExtendedActions.LogMessage(AppInfo.GetAppInfo().OsContext, "Begin waiting for tasks!", "ParallelApiCall");
            Task.WaitAll(taskList.ToArray());
            GenericExtendedActions.LogMessage(AppInfo.GetAppInfo().OsContext, "Finished!", "ParallelApiCall");
        } // MssParallelCallApi