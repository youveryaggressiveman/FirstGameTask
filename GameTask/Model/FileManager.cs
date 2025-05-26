using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GameTask.Model
{
    public class FileManager
    {
        public readonly string _path = @"./Data/";

        public FileManager()
        {
            if (!File.Exists(Path.Combine(_path, "Results.txt")))
            {
                File.Create(Path.Combine(_path, "Results.txt")).Close();
            }
        }

        public async Task<string> ReadFile(string name)
        {
            var path = Path.Combine(_path, $"{name}.txt");

            if (!File.Exists(path))
            {
                throw new Exception();
            }

            using (StreamReader reader = new(path))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task WriteFile(GameResult gameResult, string name)
        {
            var path = Path.Combine(_path, $"{name}.txt");

            if (!File.Exists(path))
            {
                throw new Exception();
            }

            using(StreamWriter writer = new(path, true))
            {
                await writer.WriteLineAsync(!!!);
            }
        }
    }
}
