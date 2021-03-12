using System;
using System.IO;

namespace data_creation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            saveFile(4096); 
            saveFile(8192);
            saveFile(16384); 
             
        }

        private static void saveFile(int N)
        {
            string fileName = "../../data/" +N + ".txt";
            FileStream fs = null;
            
            try
            {
                fs = new FileStream(fileName, FileMode.CreateNew);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    string[] lines = new string[N];
                    Random r = new Random();

                    for (int i = 0; i < N; i++)
                    {
                        writer.WriteLine(r.Next(Int32.MinValue, Int32.MaxValue).ToString());
                    }
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }
        
    }
}