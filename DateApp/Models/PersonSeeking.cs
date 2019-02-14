namespace DateApp.Models
{
    public class PersonSeeking
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Seeking { get; set; }
        public byte[] BitImage { get; set; }

        /// <summary>
        /// Outputs most relevant info.
        /// </summary>
        public string FullInfo
        {
            get
            {
                return $"{ Firstname } { Lastname } { City } { State }";
            }
        }
    }
}