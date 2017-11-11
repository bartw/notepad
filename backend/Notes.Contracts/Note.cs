using System;

namespace Notes.Contracts
{
    public class Note
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Content { get; }

        public Note(Guid id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}