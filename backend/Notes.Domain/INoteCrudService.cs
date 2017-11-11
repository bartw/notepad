using System;
using System.Threading.Tasks;
using Notes.Contracts;

namespace Notes.Domain
{
    public interface INoteCrudService
    {
        Task<Guid> Create(CreateRequest createRequest);
        Task Update(Contracts.Note note);
        Task Delete(Guid id);
    }
}
