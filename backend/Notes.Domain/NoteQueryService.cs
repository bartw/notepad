using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Contracts;
using System.Linq;

namespace Notes.Domain
{
    public class NoteQueryService : INoteQueryService
    {
        private readonly INoteQueryRepository _noteQueryRepository;

        public NoteQueryService(INoteQueryRepository noteQueryRepository)
        {
            _noteQueryRepository = noteQueryRepository;
        }

        public async Task<IEnumerable<Contracts.Note>> Get()
        {
            var notes = await _noteQueryRepository.Get();
            return notes.Select(n => new Contracts.Note(n.Id, n.Title, n.Content));
        }
    }
}
