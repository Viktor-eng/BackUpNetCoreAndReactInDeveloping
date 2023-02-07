using System.Collections.Generic;

namespace DatabaseApi.Model
{ 
    public class ServerSizeHistoryPageViewModel
    {
        public int PageCurrent { get; set; }

        public int PageCount { get; set; }

        public List<ServerSizeHistoryViewModel> ServerSizeHistoryViewModels { get; set; }
    }
}
