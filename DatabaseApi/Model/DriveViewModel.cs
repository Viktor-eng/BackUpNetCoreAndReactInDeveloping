using DataBase.Model;

namespace DatabaseApi.Model
{
    public class DriveViewModel
    {
        public int Id { get; set; }

        public string Letter { get; set; }

        public static implicit operator DriveViewModel(Drive drive)
        {
            return new DriveViewModel
            {
                Id = drive.Id,
                Letter = drive.Letter
            };
        }
    }
}
