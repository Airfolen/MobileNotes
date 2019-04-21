using Notes.Clients.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Clients.Models
{
    public class NoteModel
    {
        public Guid NoteGuid { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public NoteCategory Category { get; set; }

        public Guid FileGuid { get; set; }
    }
}
