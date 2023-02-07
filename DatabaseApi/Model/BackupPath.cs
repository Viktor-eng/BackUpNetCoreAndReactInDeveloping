public class BackupPath
{
    public int Id { get; set; }

    public string Disk { get; set; }

    public string Target { get; set; }

    public string GrpcServiceUrl { get; set; }

    public int StorageId { get; set; }

    public static implicit operator BackupPath(DataBase.Model.BackUpTarget backUpTarget)
    {
        return new BackupPath
        {
            Id = backUpTarget.Id,
            GrpcServiceUrl = backUpTarget.Storage.GrpcServiceUrl,
            Disk = backUpTarget.Drive.Letter,
            Target = backUpTarget.Target,
            StorageId = backUpTarget.StorageId
        };
    }
}
