using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjetoIDEIntl
{
    class TranslationFileHandler
    {
        private static TranslationFileHandler auto;


        private TranslationFileHandler()
        {
        }

        public static TranslationFileHandler getInstance()
        {
            if (auto == null)
            {
                auto = new TranslationFileHandler();
            }
            return auto;
        }

        public string processFile(Stream s)
        {
            return null;
        }




    }
}
