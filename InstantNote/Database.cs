using System;
using System.Collections.Generic;
using System.IO;
using InstantNote.Models;

namespace InstantNote
{
    public class Database
    {
        public List<Note> Notes { get; set; }

        private const string FileDirectory = "Data";

        public static void WriteJson()
        {
            if (!Directory.Exists($"{FileDirectory}"))
            {
                Directory.CreateDirectory(FileDirectory);
            }

            var dateString = $"{DateTime.Now:yyyy-MM-dd}.json";
            File.Create(Path.Combine(FileDirectory, dateString));
        }

        public void LoadJson()
        {
            Notes = new List<Note>();
        }


    }
}