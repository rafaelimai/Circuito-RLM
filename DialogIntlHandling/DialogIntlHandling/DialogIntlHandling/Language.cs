using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogIntlHandling
{
    class Language
    {
        private string commonName;
        private string isoCode;

        public Language(string commonName, string isoCode)
        {
            this.commonName = commonName;
            this.isoCode = isoCode;

        }

        public string getCommonName()
        {
            return commonName;
        }

        public string getISOCode()
        {
            return isoCode;
        }
    }
}
