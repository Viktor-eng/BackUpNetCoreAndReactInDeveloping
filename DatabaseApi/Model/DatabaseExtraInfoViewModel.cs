using DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApi.Model
{
    public class DatabaseExtraInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }

        public string TempBackupPath { get; set; }

        public int? LastBackupId { get; set; }

        public string Drive { get; set; }

        public int? SizeLastBackUp { get; set; }

        public DateTime? DateLastBackUp { get; set; }

        public bool LastBackupStateOk { get; set; }

        public static implicit operator DatabaseExtraInfoViewModel(DatabaseDefinition databaseDefinition)
        {
            var lastBackUp = databaseDefinition.BackUpHistories?.OrderByDescending(x => x.DateTime).FirstOrDefault();
            if (lastBackUp == null)
            {
                lastBackUp = new BackUpHistory()
                {
                    Id = 0,
                    BackUpSize = 0,
                    DateTime = default,
                    BackUpHistoryLogs = new List<BackUpHistoryLogs>() { new BackUpHistoryLogs() { Id = 0, Status = "Ok" }} 
                };
            }
            return new DatabaseExtraInfoViewModel
            {
                Id = databaseDefinition.Id,
                Name = databaseDefinition.Name,
                Source = databaseDefinition.Source,
                TempBackupPath = databaseDefinition.TempBackupPath,
                Drive = databaseDefinition.Drive.Letter,
                LastBackupId = lastBackUp.Id,
                SizeLastBackUp = lastBackUp.BackUpSize,
                DateLastBackUp = lastBackUp.DateTime,
                LastBackupStateOk = !lastBackUp.BackUpHistoryLogs.Any(x => x.Status == "Fail")
            };
        }
    }
}
