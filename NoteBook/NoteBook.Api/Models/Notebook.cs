using System;
using System.Collections.Generic;

namespace NoteBook.Api.Models
{
    public class Notebook
    {
        private static readonly ISet<NoteObject> _notes = new HashSet<NoteObject>();

        public IReadOnlySet<NoteObject> AllNotes = new HashSet<NoteObject>(_notes);

        public static readonly ISet<Student> _users = new HashSet<Student>();

        public IReadOnlySet<Student> Contributors = new HashSet<Student>(_users);

        public Notebook()
        {
            _notes.Add(new() { NoteID = 1, Text = "Interesting Science Notes", Tags = new List<NoteTag>(), Written = DateTime.Now, UserID = 1 });
            _notes.Add(new() { NoteID = 2, Text = "Exciting Math Notes", Tags = new List<NoteTag>(), Written = DateTime.Now, UserID = 2 });
            _notes.Add(new() { NoteID = 3, Text = "Lame Java Notes", Tags = new List<NoteTag>(), Written = DateTime.Now, UserID = 3 });

            _users.Add(new() { ID = 1, Name = "Daniel Grant" });
            _users.Add(new() { ID = 2, Name = "Damien Bevins" });
            _users.Add(new() { ID = 3, Name = "Matthew Goodman" });

        }

        public bool AddNote(NoteObject note)
        {
            if (note.NoteID == default)
            {
                return false;
            }
            return false;
        }
    }
}
