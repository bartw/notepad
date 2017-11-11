using System;
using System.Threading.Tasks;
using Notes.Contracts;

namespace Notes.Domain
{
    public interface INoteCrudService
    {
        Task<Guid> Create(CreateRequest createRequest);
    }
}
