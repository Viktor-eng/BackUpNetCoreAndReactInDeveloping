using DataBase.Model;

namespace DatabaseApi.Model
{
    public class ScheduleBackupViewModel
    {
        public int Id { get; set; }

        public string SchedulePlan { get; set; }

        public static implicit operator ScheduleBackupViewModel(ScheduleBackup scheduleBackup)
        {
            return new ScheduleBackupViewModel
            {
                Id = scheduleBackup.Id,
                SchedulePlan = scheduleBackup.SchedulePlan
            };
        }
    }
}
