using System;
using Xunit;
using NSubstitute;
using Notes.Contracts;
using Notes.Domain;
using FluentAssertions;

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
        public void GivenACreateRequest_WhenCreate_ThenANoteIsCreatedAndTheGeneratedIdIsReturned()
        {
            var createdId = Guid.NewGuid();
            var createRequest = new CreateRequest("title", "content");
            
            _noteCrudRepository.Create(Arg.Is<Note>(n => n.Title == "title" && n.Content == "content")).Returns(createdId);

            var sut = GetSut();
            var id = sut.Create(createRequest);

            id.Should().Be(createdId);
        }

        private INoteCrudService GetSut()
        {
            return new NoteCrudService(_noteCrudRepository);
        }
    }
}
