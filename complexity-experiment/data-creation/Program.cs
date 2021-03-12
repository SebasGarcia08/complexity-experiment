using System;
using System.IO;

namespace data_creation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            saveFile(49152); // 49152 - 1.5 MB
            saveFile(327680); //  327,680 - 10 MB
            saveFile(491520); // 491,520 -  15 MB 
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