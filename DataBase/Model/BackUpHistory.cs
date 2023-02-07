using DynamicApiController;
using GenericRepository;
using System;
using System.Collections.Generic;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class BackUpHistory : BaseEntity
    {
        public int DatabaseDefinitionId { get; set; }

        public DateTime DateTime { get; set; }

        public int BackUpSize { get; set; }

        public List<BackUpHistoryLogs> BackUpHistoryLogs { get; set; }
    }
}
