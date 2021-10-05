using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {

            string[] wordFile;
            try
            {
                wordFile = File.ReadAllLines(filename);
            }
            catch(Exception e) { throw new Exception(e.Message); }
            
            return wordFile;


        }
    }
}
