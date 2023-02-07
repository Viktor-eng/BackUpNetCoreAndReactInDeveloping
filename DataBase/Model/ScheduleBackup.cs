using DynamicApiController;
using GenericRepository;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class ScheduleBackup : BaseEntity
    {
        public int DatabaseDefinitionId { get; set; }

        [Required]
        public string SchedulePlan { get; set; }
    }
}
