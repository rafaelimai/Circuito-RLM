using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using DialogIntlHandling;

namespace ProjetoIDEIntl
{
    class TranslationFileHandler
    {
        private static TranslationFileHandler auto;
        private XmlSerializer x;

        private TranslationFileHandler()
        {
            
            DialogList d = new DialogList();
            x = new XmlSerializer(d.GetType());
        }

        public static TranslationFileHandler getInstance()
        {
            if (auto == null)
            {
                auto = new TranslationFileHandler();
            }
            return auto;
        }

        public DialogList readTranslationFile(Stream s)
        {             
            DialogList result = (DialogList)x.Deserialize(s);
            return result;   
        }

        public void writeFile(DialogList d, string path)
        {
            StreamWriter sw = new StreamWriter(path, false);
            x.Serialize(sw, d);
        }




    }
}
