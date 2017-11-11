using System;
using System.Threading.Tasks;
using Notes.Domain.Port.In;
using Notes.Domain.Port.Out;

namespace Notes.Domain.Service
{
    public class NoteCrudService : INoteCrudService
    {
        private readonly INoteCrudRepository _noteCrudRepository;

        public NoteCrudService(INoteCrudRepository noteCrudRepository)
        {
            _noteCrudRepository = noteCrudRepository;
        }
        
        public async Task<Guid> Create(Dto.CreateRequest createRequest)
        {
            var note = Entity.Note.From(createRequest);
            await _noteCrudRepository.Create(Entity.Note.To(note));
            return note.Id;
        }

        public Task Update(Dto.Note note)
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
