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
            if (!Database.Notes.Any())
            {
                Database.Notes = LoadTodayNote();
            }

            Database.Notes.Add(new Note
            {
                Title = title,
                Content = content,
                DateTime = DateTime.Now.ToLongTimeString()
            });
            Database.WriteJson();
        }

        public List<Note> GetNotes(short days)
        {
            return new List<Note>();
        }

        private List<Note> LoadTodayNote()
        {
            return Database.LoadJson(Helper.GetTodayFileName());
        }
    }
}