using System;
using System.Threading.Tasks;

namespace Notes.Domain.Port.In
{
    public interface INoteCrudService
    {
        Task<Guid> Create(Dto.CreateRequest createRequest);
        Task Update(Dto.Note note);
        Task Delete(Guid id);
    }
}
