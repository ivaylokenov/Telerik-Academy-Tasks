using System;

namespace GSMCharacteristics
{
    class Display
    {
        private int? size;
        private int? colors;

        public int? Size
        {
            get { return this.size; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Display size cannot be less than 0.");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int? Colors
        {
            get { return this.colors; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Display size cannot be less than 0.");
                }
                else
                {
                    this.colors = value;
                }
            }
        }

        public Display() : this(null)
        {
        }

        public Display(int? size) : this(size, null)
        {
        }

        public Display(int? size, int? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
    }
}
