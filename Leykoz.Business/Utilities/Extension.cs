using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Leykoz.Business.Utilities
{
    public static class ExtensionsClass
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
    public static class Extension
    {
        public static bool CheckFileType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

        public static bool CheckFileSize(this IFormFile file, int sizekb)
        {
            return file.Length / 1024 <= sizekb;
        }

        public async static Task<string> SaveFileAsync(this IFormFile file, string root, params string[] folder)
        {
            string filename = DateTime.Now.ToString("MMddyyyyhhmmss") + "_" + file.FileName;
            string resultPath = Path.Combine(root, folder[0], folder[1], filename);
            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filename;
        }
    }
}