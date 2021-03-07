namespace BusinessLayer
{
    public class Email
    {
        private string mailname;
        public string MailName
        {
            get { return mailname; }
            set { mailname = value; }
        }

        private string domain;
        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        public override string ToString()
        {
            return mailname + "@" + domain;
        }

        public Email(string mailname, string domain)
        {
            MailName = mailname;
            Domain = domain;
        }
    }
}
