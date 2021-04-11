using System;

namespace g4m4nez.Models
{
    [Serializable]
    public struct Email
    {
        private string _mailName;
        public string MailName
        {
            get => _mailName;
            set => _mailName = value;
        }

        private string _domain;
        public string Domain
        {
            get => _domain;
            set => _domain = value;
        }

        public override string ToString()
        {
            return _mailName + "@" + _domain;
        }

        public Email(string mailname, string domain)
        {
            if (!CheckEmail(mailname + "@" + domain))
            {
                throw new System.ArgumentException("Invalid email");
            }
            _mailName = mailname;
            _domain = domain;
        }
        public Email(string email)
        {
            if (!CheckEmail(email))
            {
                throw new System.ArgumentException("Invalid email");
            }
            string[] spl = email.Split('@');
            _mailName = spl[0];
            _domain = spl[1];
        }

        private static bool CheckEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
