﻿using System;
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
            return notes;
        }

        public async Task<Contracts.Note> Get(Guid id)
        {
            var note = await _noteQueryRepository.Get(id);
            return note;
        }
    }
}
