using System;
using Xunit;
using NSubstitute;
using Notes.Contracts;
using Notes.Domain;
using FluentAssertions;
using System.Threading.Tasks;
using Notes.Contracts;

namespace Notes.Domain.Test
{
    public class NoteCrudServiceTest
    {
        private readonly INoteCrudRepository _noteCrudRepository;

        public NoteCrudServiceTest()
        {
            _noteCrudRepository = Substitute.For<INoteCrudRepository>();
        }

        [Fact]
        public async Task GivenACreateRequest_WhenCreate_ThenANoteIsCreatedAndTheGeneratedIdIsReturned()
        {
            var createRequest = new CreateRequest("title", "content");

            var sut = GetSut();
            var id = await sut.Create(createRequest);

            await _noteCrudRepository.Received(1).Create(Arg.Is<Contracts.Note>(n => n.Title == "title" && n.Content == "content"));
            id.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenNull_WhenUpdate_ThenAnExceptionIsThrown()
        {
            var sut = GetSut();
            Func<Task> update = async () => await sut.Update(null);
            
            update.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task GivenANote_WhenUpdate_ThenTheNoteIsUpdated()
        {
            var id = Guid.NewGuid();
            var note = new Contracts.Note(id, "title", "content");

            var sut = GetSut();
            await sut.Update(note);
            
            await _noteCrudRepository.Received(1).Update(Arg.Is<Contracts.Note>(n => n.Id == id && n.Title == "title" && n.Content == "content"));
        }

        [Fact]
        public async Task GivenAnId_WhenDelete_ThenTheNoteIsDeleted()
        {
            var sut = GetSut();
            await sut.Delete(Guid.Empty);

            await _noteCrudRepository.Received(1).Delete(Guid.Empty);
        }

        private INoteCrudService GetSut()
        {
            return new NoteCrudService(_noteCrudRepository);
        }
    }
}
