using System;
using Notes.Contracts;

namespace Notes.Domain
{
    public interface INoteCrudService
    {
        Guid Create(CreateRequest createRequest);
    }
}
