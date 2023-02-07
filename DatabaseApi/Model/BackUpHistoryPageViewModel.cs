using System.Collections.Generic;

namespace DatabaseApi.Model
{
    public class BackUpHistoryPageViewModel
    {
        public int PageCurrent { get; set; }

        public int PageCount { get; set; }

        public List<BackUpHistoryViewModel> BackUpHistoryViewModels { get; set; }
    }
}
