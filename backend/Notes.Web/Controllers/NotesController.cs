using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Dto;
using Notes.Domain.Port.In;

namespace Notes.Web.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private readonly INoteCrudService _noteCrudService;
        private readonly INoteQueryService _noteQueryService;

        public NotesController(INoteCrudService notesCrudService, INoteQueryService notesQueryService)
        {
            _noteCrudService = notesCrudService;
            _noteQueryService = notesQueryService;
        }

        [HttpGet]
        public Task<IEnumerable<Note>> Get()
        {
            return _noteQueryService.Get();
        }

        [HttpGet("{id}")]
        public Task<Note> Get(Guid id)
        {
            return _noteQueryService.Get(id);
        }

        [HttpPost]
        public Task<Guid> Post([FromBody]CreateRequest createRequest)
        {
            return _noteCrudService.Create(createRequest);
        }

        [HttpPut("{id}")]
        public Task Put(Guid id, [FromBody]Note note)
        {
            return _noteCrudService.Update(note);
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _noteCrudService.Delete(id);
        }
    }
}
