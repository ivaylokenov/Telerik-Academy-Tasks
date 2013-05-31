namespace StarChessConsole
{
    public struct FigureProperties
    {
        private Names name;
        private Colors color;

        public Names Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Colors Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public FigureProperties(Names name, Colors color)
        {
            this.name = name;
            this.color = color;
        }
    }
}
