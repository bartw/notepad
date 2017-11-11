using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Contracts;

namespace Notes.Domain
{
    public interface INoteQueryService
    {
        Task<IEnumerable<Contracts.Note>> Get();
    }
}
