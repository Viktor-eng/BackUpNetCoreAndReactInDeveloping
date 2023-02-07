using DataBase.Model;
using System;

namespace DatabaseApi.Model
{
    public class BackUpHistoryViewModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int BackUpSize { get; set; }

        public static implicit operator BackUpHistoryViewModel(BackUpHistory backUpHistory)
        {
            return new BackUpHistoryViewModel
            {
                Id = backUpHistory.Id,
                DateTime = backUpHistory.DateTime,
                BackUpSize = backUpHistory.BackUpSize
            };
        }
    }
}
