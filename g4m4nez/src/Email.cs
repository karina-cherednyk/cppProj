namespace BusinessLayer
{
    public struct Email
    {
        private string _mailName;
        public string MailName
        {
            get { return _mailName; }
            set { _mailName = value; }
        }

        private string _domain;
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        public override string ToString()
        {
            return _mailName + "@" + _domain;
        }

        public Email(string mailname, string domain)
        {
            _mailName = mailname;
            _domain = domain;
        }
    }
}
