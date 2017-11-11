namespace Notes.Domain
{
    public class Note
    {
        public string Title { get; }
        public string Content { get; }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}