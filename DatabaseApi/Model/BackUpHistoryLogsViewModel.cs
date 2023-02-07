using DataBase.Model;
using System;

namespace DatabaseApi.Model
{
    public class BackUpHistoryLogsViewModel
    {
        public string Step { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        public string Status { get; set; }

        public static implicit operator BackUpHistoryLogsViewModel(BackUpHistoryLogs backUpHistoryLogs)
        {
            return new BackUpHistoryLogsViewModel
            {
               Step = backUpHistoryLogs.Step,
               DateBegin = backUpHistoryLogs.DateBegin,
               DateEnd = backUpHistoryLogs.DateEnd,
               Status = backUpHistoryLogs.Status
            };
        }
    }
}
