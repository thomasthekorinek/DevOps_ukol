using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps
{
    internal class FileMaker
    {
        public void CreateFile(string name,string info)
        {
            string path = name + ".txt";

            List<string> invalidChars = new List<string> { "<", ">", ":", "\\", "/", "|", "?", "*" };
            foreach (string item in invalidChars)
            {
                path = path.Replace(item,"-");
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(info);
            }
            Console.WriteLine(path + "  -> DONE!");
        }
    }
}
