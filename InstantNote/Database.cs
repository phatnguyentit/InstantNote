using System;
using System.Collections.Generic;
using System.IO;
using InstantNote.Models;
using Newtonsoft.Json;

namespace InstantNote
{
    public class Database
    {
        public static List<Note> Notes { get; set; }

        public static void WriteJson(string filePath = "")
        {
            if (filePath == "")
            {
                filePath = Path.Combine(Constants.Folder, Helper.GetTodayFileName());
            }
            
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(JsonConvert.SerializeObject(Notes));
            }
        }

        public static List<Note> LoadJson(string fileName)
        {
            using (var streamReader = new StreamReader(Path.Combine(Constants.Folder, fileName)))
            {
                return JsonConvert.DeserializeObject<List<Note>>(streamReader.ReadToEnd());
            }
        }
    }
}