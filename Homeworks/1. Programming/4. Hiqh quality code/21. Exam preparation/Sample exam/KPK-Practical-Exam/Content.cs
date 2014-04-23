namespace FreeContentCatalog
{
    using System;

    public class Content : IComparable, IContent
    {
        private string url;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentProperties.Title];
            this.Author = commandParams[(int)ContentProperties.Author];
            this.Size = long.Parse(commandParams[(int)ContentProperties.Size]);
            this.Url = commandParams[(int)ContentProperties.Url];
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Content otherContent = obj as Content;

            if (otherContent != null)
            {
                return this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);
        }
    }
}
