using DataBase.Model;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApi.Model
{
    public class ServerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IpAddress { get; set; }

        public string GrpcServiceUrl { get; set; }

        public List<DatabaseViewModel> Databases { get; set; }

        public static implicit operator ServerViewModel(Server server)
        {
            return new ServerViewModel
            {
                Id = server.Id,
                IpAddress = server.IpAddress,
                GrpcServiceUrl = server.GrpcServiceUrl,
                Name = server.Name,
                Databases = server.DatabaseDefinitions.Select(itm => (DatabaseViewModel)itm).ToList(),
            };
        }
    }
}
