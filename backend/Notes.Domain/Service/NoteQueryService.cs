using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Notes.Domain.Port.In;
using Notes.Domain.Port.Out;

namespace Notes.Domain.Service
{
    public class NoteQueryService : INoteQueryService
    {
        private readonly INoteQueryRepository _noteQueryRepository;

        public NoteQueryService(INoteQueryRepository noteQueryRepository)
        {
            _noteQueryRepository = noteQueryRepository;
        }

        public async Task<IEnumerable<Dto.Note>> Get()
        {
            var notes = await _noteQueryRepository.Get();
            return notes;
        }

        public async Task<Dto.Note> Get(Guid id)
        {
            var note = await _noteQueryRepository.Get(id);
            return note;
        }
    }
}
