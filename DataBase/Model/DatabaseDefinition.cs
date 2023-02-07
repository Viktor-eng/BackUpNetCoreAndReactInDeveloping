using DynamicApiController;
using GenericRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class DatabaseDefinition : BaseEntity
    {
        public int ServerId { get; set; }

        public int DriveId { get; set; }

        public Drive Drive { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string TempBackupPath { get; set; }

        public List<BackUpHistory> BackUpHistories { get; set; }

        public List<BackUpTarget> BackUpTargets { get; set; }

        public List<ScheduleBackup> ScheduleBackups { get; set; }
    }
}
