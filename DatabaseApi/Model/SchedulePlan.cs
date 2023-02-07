using DataBase.Model;

namespace DatabaseApi.Model
{
    public class SchedulePlan
    {
        public int Id { get; set; }

        public string Schedule { get; set; }

        public static implicit operator SchedulePlan(ScheduleBackup scheduleBackup)
        {
            return new SchedulePlan
            {
                Id = scheduleBackup.Id,
                Schedule = scheduleBackup.SchedulePlan
            };
        }
    }
}
