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
        public int Prof { get; set; }
        public int Status { get; set; }
        public string Seeking { get; set; }
        public byte[] Picture { get; set; }

        // Default contructor.
        public Person()
        {

        }

        // Contructor for query purposes.
        public Person(string firstname, string lastname, string birthday, char gender, string mail, int area, int prof, string seeking)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthday = birthday;
            this.Gender = gender;
            this.Mail = mail;
            this.Area = area;
            this.Prof = prof;
            this.Seeking = seeking;
        }

        // Contructor for insert purposes.
        public Person(string firstname, string lastname, string birthday, char gender, string mail, int area, int prof, int status, string seeking, byte[] picture)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthday = birthday;
            this.Gender = gender;
            this.Mail = mail;
            this.Area = area;
            this.Prof = prof;
            this.Status = status;
            this.Seeking = seeking;
            this.Picture = picture;
        }

        // Contructor for detailed inser purposes.
        public Person(string firstname, string lastname, string birthday, char gender, string mail, int phone, int area, int prof, int status, string seeking, byte[] picture)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthday = birthday;
            this.Gender = gender;
            this.Mail = mail;
            this.Phone = phone;
            this.Area = area;
            this.Prof = prof;
            this.Status = status;
            this.Seeking = seeking;
            this.Picture = picture;
        }

        // Full contructor.
        public Person(int personID, string firstname, string lastname, string birthday, char gender, string mail, int area, int prof, int status, string seeking, byte[] picture)
        {
            this.PersonID = personID;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthday = birthday;
            this.Gender = gender;
            this.Mail = mail;
            this.Phone = Phone;
            this.Area = area;
            this.Prof = prof;
            this.Status = status;
            this.Seeking = seeking;
            this.Picture = picture;
        }

        // Full contructor.
        public Person(int personID, string firstname, string lastname, string birthday, char gender, string mail, int phone, int area, int prof, int status, string seeking, byte[] picture)
        {

        }

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