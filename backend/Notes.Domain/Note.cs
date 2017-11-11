using System;

namespace Notes.Domain
{
    public class Note
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Content { get; }

        public Note(string title, string content) : this(Guid.NewGuid(), title, content)
        {
        }

        public Note(Guid id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}