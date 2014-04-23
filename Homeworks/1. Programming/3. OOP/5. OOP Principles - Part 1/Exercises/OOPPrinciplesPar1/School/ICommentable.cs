using System.Collections.Generic;

namespace School
{
    interface ICommentable
    {
        List<string> Comments { get; }
        void AddComment(string comment);
    }
}
