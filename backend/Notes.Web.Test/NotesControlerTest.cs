using System;
using Xunit;
using NSubstitute;
using FluentAssertions;
using Notes.Web.Controllers;
using Notes.Domain.Port.In;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Web.Test
{
    public class NotesControllerTest
    {
        private readonly INoteCrudService _noteCrudService;
        private readonly INoteQueryService _noteQueryService;

        public NotesControllerTest()
        {
            _noteCrudService = Substitute.For<INoteCrudService>();
            _noteQueryService = Substitute.For<INoteQueryService>();
        }

        [Fact]
        public async Task GivenAnIdThatDoesNotExist_WhenGet_ThenNotFoundIsReturned()
        {
            _noteQueryService.Get(Arg.Any<Guid>()).Returns(Task.FromResult<Notes.Domain.Dto.Note>(null));

            var sut = GetSut();
            var result = await sut.Get(Guid.NewGuid());

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GivenAnExistingId_WhenGet_ThenOkAndTheNoteIsReturned()
        {
            var id = Guid.NewGuid();
            var note = new Notes.Domain.Dto.Note(id, "title", "contnet");

            _noteQueryService.Get(id).Returns(note);

            var sut = GetSut();
            var result = await sut.Get(id);

            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.ShouldBeEquivalentTo(note);
        }

        private NotesController GetSut()
        {
            return new NotesController(_noteCrudService, _noteQueryService);
        }
    }
}
