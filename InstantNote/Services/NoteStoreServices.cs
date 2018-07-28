using System.Collections.Generic;
using InstantNote.Models;

namespace InstantNote.Services
{
    public class NoteStoreServices
    {
        public void SaveNote(string title, string content)
        {
            Database.WriteJson();
        }

        public List<Note> GetNotes(short size)
        {
           return new List<Note>();
        }


    }
}