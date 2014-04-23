using System;

namespace RangeException
{
    class InvalidRangeException<T> : ApplicationException
    {
        //fields
        private T start;
        private T end;

        //properties
        public T Start
        {
            get { return this.start; }
        }

        public T End
        {
            get { return this.end; }
        }

        //constructors
        public InvalidRangeException(T start, T end)
            : this(null, start, end, null)
        {
        }

        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {
        }

        public InvalidRangeException(string message, T start, T end, Exception exception)
            : base(message, exception)
        {
            this.start = start;
            this.end = end;
        }
    }
}
