using DataBase.Model;

namespace DatabaseApi.Model
{
    public class ServerResultViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IpAddress { get; set; }

        public string GrpcServiceUrl { get; set; }

        public static implicit operator ServerResultViewModel(Server server)
        {
            return new ServerResultViewModel
            {
                Id = server.Id,
                Name = server.Name,
                IpAddress = server.IpAddress,
                GrpcServiceUrl = server.GrpcServiceUrl
            };
        }
    }
}
