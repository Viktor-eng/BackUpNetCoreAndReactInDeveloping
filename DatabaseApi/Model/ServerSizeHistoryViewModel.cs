using DataBase.Model;
using System;

namespace DatabaseApi.Model
{
    public class ServerSizeHistoryViewModel
    {
        public int FreeSpace { get; set; }

        public int TotalSpace { get; set; }

        public string Drive { get; set; }

        public DateTime DateTime { get; set; }

        public static implicit operator ServerSizeHistoryViewModel(ServerSizeHistory serverSizeHistories)
        {
            return new ServerSizeHistoryViewModel
            {
                FreeSpace = serverSizeHistories.FreeSpace,
                TotalSpace = serverSizeHistories.TotalSpace,
                DateTime = serverSizeHistories.DateTime,
                Drive = serverSizeHistories.ServerToDrive.Drive.Letter
            };
        }
    }
}
