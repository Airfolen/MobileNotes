using Notes.Clients.Enums;

namespace Notes.Clients.Models
{
    /// <summary>
    /// Входная модель заметки
    /// </summary>
    public class NoteInfo
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public NoteCategory Category { get; set; }
    }
}