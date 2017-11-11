using System;

namespace Notes.Contracts
{
    public class CreateRequest
    {
        public string Title { get; }
        public string Content { get; }

        public CreateRequest(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
