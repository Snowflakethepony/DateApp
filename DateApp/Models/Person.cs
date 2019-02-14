namespace DateApp.Models
{
    public class Person
    {
        public int personID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mailAddress { get; set; }
        public char gender { get; set; }
        public string birthday { get; set; }
        public string profession { get; set; }
        public int area { get; set; }
        public string status { get; set; }
        public string seeking { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{firstname} {lastname} ";
            }
        }
    }
}