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

        public static void WriteFile(string filePath = "")
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

        public static void LoadFile(string fileName)
        {
            var filePath = Path.Combine(Constants.Folder, fileName);
            if (File.Exists(filePath))
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    var jsonString = streamReader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonString))
                        Notes.AddRange(JsonConvert.DeserializeObject<List<Note>>(jsonString));
                }
            }
        }

        public static void VerifyTodayFile()
        {
            var filePath = Path.Combine(Constants.Folder, Helper.GetTodayFileName());
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public static void Clean()
        {
            Notes = new List<Note>();
        }
    }
}