using System;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public interface INoteCrudRepository
    {
        Task Create(Note note);
    }
}