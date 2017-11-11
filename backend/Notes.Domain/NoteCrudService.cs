using System;
using System.Threading.Tasks;
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
        
        public async Task<Guid> Create(CreateRequest createRequest)
        {
            var note = Note.From(createRequest);
            await _noteCrudRepository.Create(Mapper.Map(note));
            return note.Id;
        }

        public Task Update(Contracts.Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException();
            }
            return _noteCrudRepository.Update(note);
        }

        public Task Delete(Guid id)
        {
            return _noteCrudRepository.Delete(id);
        }
    }
}
