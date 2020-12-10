using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NoteBook.Api.Models
{
    public class NoteObject
    {
        public NoteObject()
        {
        }

        [BindNever]
        public int NoteID { get; set; }

        public string Text { get; set; }

        public DateTime Written { get; set; }

        public IEnumerable<NoteTag> Tags { get; set; }

        public int UserID { get; set; }

    }
}
