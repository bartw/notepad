using System;
using Notes.Domain.Dto;

namespace Notes.Domain.Entity
{
    internal class Note
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

        public static Note From(CreateRequest createRequest)
        {
            return new Note(createRequest.Title, createRequest.Content);
        }

        public static Dto.Note To(Note note)
        {
            return note == null ? null : new Dto.Note(note.Id, note.Title, note.Content);
        }
    }
}