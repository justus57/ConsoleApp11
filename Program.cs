using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp11
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            try
            {
                //get all text files in the folder
                string[] filePaths = Directory.GetFiles(@"D:\current\", "*.txt");
                List<string> value = filePaths.ToList();
                //update one by one
                for (int i1 = 0; i1 < value.Count; i1++)
                {
                    string doc = value[i1];
                    string file  = Path.GetFileName(doc);
               
                    string[] lines = System.IO.File.ReadAllLines(doc);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        // Use a tab to indent each line of the file.
                        if (line.Contains("https:"))
                        {
                            Link = line;

                        }
                        else if (line.Contains("TSIN:"))
                        {
                            TSIN = line.Substring(line.IndexOf(':') + 1).TrimEnd();

                        }
                        else if (line.Contains("DATE:"))
                        {
                            Date = line.Substring(line.IndexOf(':') + 1).TrimEnd();

                        }
                        else if (line.Contains("CUSN:"))
                        {
                            CUSN = line.Substring(line.IndexOf(':') + 1).TrimEnd();

                        }
                        else if (line.Contains("CUIN:"))
                        {
                            CUIN = line.Substring(line.IndexOf(':') + 1).TrimEnd();
                        }


                    }
                    File.Copy(Path.Combine(doc), Path.Combine(@"D:\current\New folder", file));
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
