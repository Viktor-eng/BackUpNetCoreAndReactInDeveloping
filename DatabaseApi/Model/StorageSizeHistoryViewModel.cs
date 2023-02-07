using DataBase.Model;
using System;

namespace DatabaseApi.Model
{
    public class StorageSizeHistoryViewModel
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int StorageToDriveId { get; set; }

        public int FreeSpace { get; set; }

        public int TotalSpace { get; set; }

        public DateTime DateTime { get; set; }

        public static implicit operator StorageSizeHistoryViewModel(StorageSizeHistory storageSizeHistories)
        {
            return new StorageSizeHistoryViewModel
            {
                Id = storageSizeHistories.Id,
                StorageId = storageSizeHistories.StorageId,
                StorageToDriveId = storageSizeHistories.StorageToDriveId,
                FreeSpace = storageSizeHistories.FreeSpace,
                TotalSpace = storageSizeHistories.TotalSpace,
                DateTime = storageSizeHistories.DateTime
            };
        }
    }
}

