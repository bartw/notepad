using System;
using Xunit;
using NSubstitute;
using Notes.Contracts;
using Notes.Domain;
using FluentAssertions;
using System.Threading.Tasks;

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

            await _noteCrudRepository.Received(1).Create(Arg.Is<Note>(n => n.Title == "title" && n.Content == "content"));
            id.Should().NotBeEmpty();
        }

        private INoteCrudService GetSut()
        {
            return new NoteCrudService(_noteCrudRepository);
        }
    }
}
