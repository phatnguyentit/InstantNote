using System;
using System.Collections.Generic;
using System.Linq;
using InstantNote.Models;

namespace InstantNote.Services
{
    public class NoteServices
    {
        public NoteServices()
        {
            Database.Notes = new List<Note>();
        }

        public void SaveNote(string title, string content)
        {
            GetNotes(1);
            Database.Notes.Add(new Note
            {
                Title = title,
                Content = content,
                DateTime = DateTime.Now.Date
            });
            Database.WriteFile();
        }

        public List<Note> GetNotes(short days)
        {
            var fileNames = Enumerable.Range(0, days)
                .Select(day => $"{DateTime.Now.AddDays(-day).ToString(Constants.DateFormat)}.json").ToList();
            Database.Clean();
            Database.VerifyTodayFile();

            foreach (var fileName in fileNames)
            {
                Database.LoadFile(fileName);
            }
            
            return Database.Notes;
        }
        
    }
}