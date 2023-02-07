using DataBase.Model;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApi.Model
{
    public class DatabaseViewModel
    {
        public int Id { get; set; }

        public string DatabaseName { get; set; }

        public string Disk { get; set; }

        public string TempBackupFilePath { get; set; }

        public List<BackupPath> BackupPath { get; set; }

        public List<SchedulePlan> SchedulePlan { get; set; }

        public static implicit operator DatabaseViewModel(DatabaseDefinition database)
        {
            return new DatabaseViewModel
            {
                Id = database.Id,
                DatabaseName = database.Name,
                TempBackupFilePath = database.TempBackupPath,
                Disk = database.Drive.Letter,
                BackupPath = database.BackUpTargets.Select(itm => (BackupPath)itm).ToList(),
                SchedulePlan = database.ScheduleBackups.Select(itm => (SchedulePlan)itm).ToList()
            };
        }
    }
}
