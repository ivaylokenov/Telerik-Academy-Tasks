namespace GameFifteen
{
    using System;

    internal static class Turn
    {
        private static int count;

        public static int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }
    }
}
