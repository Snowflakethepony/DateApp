namespace DateApp.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
        public char Gender { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public int Area { get; set; }
        public string Profession { get; set; }
        public string Status { get; set; }
        public string Seeking { get; set; }
        public byte[] Picture { get; set; }

        /// <summary>
        /// Outputs most relevant info.
        /// </summary>
        public string FullInfo
        {
            get
            {
                return $"{Firstname} {Lastname} ";
            }
        }
    }
}