using DataBase.Model;

namespace DatabaseApi.Model
{
    public class StorageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IpAddress { get; set; }

        public string GrpcServiceUrl { get; set; }

        public static implicit operator StorageViewModel(Storage storage)
        {
            return new StorageViewModel
            {
                Id = storage.Id,
                Name = storage.Name,
                IpAddress = storage.IpAddress,
                GrpcServiceUrl = storage.GrpcServiceUrl
            };
        }
    }
}
