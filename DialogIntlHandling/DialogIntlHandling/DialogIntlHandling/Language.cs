using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogIntlHandling
{
    /*The class Language briefly abstracts a real-life Language, with two attributes: its usual name (on the commonName variable) and its ISO 639-1 code.
     */
    public class Language
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
