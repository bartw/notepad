using System;
using Notes.Contracts;

namespace Notes.Domain
{
    public class NoteCrudService : INoteCrudService
    {
        private readonly INoteCrudRepository _noteCrudRepository;

        public NoteCrudService(INoteCrudRepository noteCrudRepository)
        {
            _noteCrudRepository = noteCrudRepository;
        }
        public Guid Create(CreateRequest createRequest)
        {
            return _noteCrudRepository.Create(new Note(createRequest.Title, createRequest.Content));
        }
    }
}
