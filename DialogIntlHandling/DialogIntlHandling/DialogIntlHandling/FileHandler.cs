using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace DialogIntlHandling
{
    class FileHandler
    {
        private static FileHandler fh = null;
        private XmlSerializer x;

        public static FileHandler getInstance()
        {
            if (fh == null)
            {
                fh = new FileHandler();
            }

            return fh;
        }

        public FileHandler()
        {
            DialogList d = new DialogList();
            x = new XmlSerializer(d.GetType());
        }


        public void dialogListToFile(DialogList d, string path)
        {
            
            StreamWriter sw = new StreamWriter(path, false);
            x.Serialize(sw, d);
        }

        public DialogList readFromFile(string path)
        {
            StreamReader sr = new StreamReader(path); 
            DialogList result = (DialogList)x.Deserialize(sr);
            return result;
        }
    }

   
}
