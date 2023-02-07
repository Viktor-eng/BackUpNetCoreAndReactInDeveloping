using DynamicApiController;
using GenericRepository;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class BackUpHistoryLogs : BaseEntity
    {
        public int BackUpHistoryId { get; set; }

        [Required]
        public string Step { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
