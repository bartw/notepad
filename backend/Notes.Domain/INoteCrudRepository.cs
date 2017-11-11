using System;

namespace Notes.Domain
{
    public interface INoteCrudRepository
    {
        Guid Create(Note note);
    }
}