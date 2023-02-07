using System.Collections.Generic;

namespace DatabaseApi.Model
{
    public class StorageSizeHistoriesPageViewModel
    {
        public int PageCurrent { get; set; }

        public int PageCount { get; set; }

        public List<StorageSizeHistoryViewModel> StorageSizeHistoryViewModels { get; set; }
    }
}
