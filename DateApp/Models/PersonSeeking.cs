namespace DateApp.Models
{
    /// <summary>
    /// Speciality class used to query for specific information/ special information
    /// INCLUDES OTHER TABLE VALUES.
    /// </summary>
    public class PersonSeeking
    {
        public int PersonID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string Seeking { get; set; }
        public byte[] Picture { get; set; }
        public string City { get; set; }

        /// <summary>
        /// Outputs most relevant info.
        /// </summary>
        public string FullInfo
        {
            get
            {
                return $"{ Firstname } { Lastname } { City }";
            }
        }
    }
}