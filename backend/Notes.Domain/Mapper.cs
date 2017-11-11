using System;
using Notes.Contracts;

namespace Notes.Domain
{
    internal static class Mapper
    {
        public static Contracts.Note Map(Note note)
        {
            return note == null ? null : new Contracts.Note(note.Id, note.Title, note.Content);
        }
    }
}
