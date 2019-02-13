namespace DateApp.Models
{
    public class PersonSeeking
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string seeking { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ firstname } { lastname } { city } { state }";
            }
        }
    }
}