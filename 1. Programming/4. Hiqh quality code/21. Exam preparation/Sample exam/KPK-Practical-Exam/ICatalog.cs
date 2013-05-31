namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface ICatalog
    {
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
