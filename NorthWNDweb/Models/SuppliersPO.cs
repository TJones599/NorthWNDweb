namespace NorthWNDweb.Models
{
    public class SuppliersPO
    {
        public int SupplierID { get; set; }

        private string _CompanyName;
        public string CompanyName
        {
            get
            {
                string temp = _CompanyName;

                if (temp is null)
                {
                    temp = "";
                }

                return temp;
            }
            set
            {
                _CompanyName = value;
            }
        }

        private string _ContactName;
        public string ContactName
        {
            get
            {
                string temp = _ContactName;
                if(temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _ContactName = value;
            }
        }

        private string _ContactTitle;
        public string ContactTitle
        {
            get
            {
                string temp = _ContactTitle;
                if(temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _ContactTitle = value;
            }
        }

        private string _Address;
        public string Address
        {
            get
            {
                string temp = _Address;
                if(temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _Address = value;
            }
        }

        private string _City;
        public string City
        {
            get
            {
                string temp = _City;
                if(temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _City = value;
            }
        }

        private string _Region;
        public string Region
        {
            get
            {
                string temp = _Region;
                if (temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _Region = value;
            }
        }

        private string _PostalCode;
        public string PostalCode
        {
            get
            {
                string temp = _PostalCode;
                if (temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _PostalCode = value;
            }
        }

        private string _Country;
        public string Country
        {
            get
            {
                string temp = _Country;
                if (temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _Country = value;
            }
        }

        private string _Phone;
        public string Phone
        {
            get
            {
                string temp = _Phone;
                if(temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _Phone = value;
            }
        }

        private string _Fax;
        public string Fax
        {
            get
            {
                string temp = _Fax;
                if (temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _Fax = value;
            }
        }

        private string _HomePage;
        public string HomePage
        {
            get
            {
                string temp = _HomePage;
                if(temp is null)
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                _HomePage = value;
            }
        }
    }
}
