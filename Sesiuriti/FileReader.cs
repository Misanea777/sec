using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesiuriti
{
    class FileReader
    {
        public string FileName { get; private set; }
        private TextReader textReader;
        public string currentLine { get; private set; }

        public FileReader(string fileName)
        {
            FileName = fileName;
            textReader = new StreamReader(FileName);
            currentLine = textReader.ReadLine();
        }

        public void getNextLine()
        {
            currentLine = textReader.ReadLine();
        }

        public string getText()
        {
            return new StreamReader(FileName).ReadToEnd();
        }
    }
}
