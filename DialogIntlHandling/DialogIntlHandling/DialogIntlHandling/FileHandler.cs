using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace DialogIntlHandling
{
    /*
     * The class FileHandler centralize the functions needed to read and write DialogList objects to a XML file.
     */
    public class FileHandler
    {
        private XmlSerializer x;

        /*SINGLETON-START
         * The class FileHandler uses a Singleton (for further information, search about Design Patterns).
         * Speaking briefly, Singleton is a design pattern that allows only one object instance from the given class.
         * The method getInstance returns the instance from FileHandler. Calls of the FileHandler method shall be done normally, except the fact that it won't be able to instantiate
         * directly a FileHandler-type object. 
         * Instead of:
         * 
         * FileHandler fh = new FileHandler();
         * fh.readFromFile("foo.txt");
         * 
         * one should use:
         * 
         * FileHandler.getInstance().readFromFile("foo.txt");
         *
         */
        private static FileHandler fh = null;
        

        public static FileHandler getInstance()
        {
            if (fh == null)
            {
                fh = new FileHandler();
            }

            return fh;
        }
        /*SINGLETON-END
         */
        public FileHandler()
        {
            DialogList d = new DialogList();
            x = new XmlSerializer(d.GetType());
        }


        /*Converts the object DialogList to a file, recording it in the given path.
         */
        public void dialogListToFile(DialogList d, string path)
        {
            
            StreamWriter sw = new StreamWriter(path, false);
            x.Serialize(sw, d);
        }

        /*Retrieve a DialogList from a given file.
         */
        public DialogList readFromFile(string path)
        {
            StreamReader sr = new StreamReader(path); 
            DialogList result = (DialogList)x.Deserialize(sr);
            return result;
        }
    }

   
}
