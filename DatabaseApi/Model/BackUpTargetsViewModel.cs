using DataBase.Model;

namespace DatabaseApi.Model
{
    public class BackUpTargetsViewModel
    {
        public int Id { get; set; }

        public string Target { get; set; }

        public string Drive { get; set; }

        public static implicit operator BackUpTargetsViewModel(BackUpTarget backUpTargets)
        {
            return new BackUpTargetsViewModel
            {
                Id = backUpTargets.Id,
                Target = backUpTargets.Target,
                Drive = backUpTargets.Drive.Letter
            };
        }
    }
}
