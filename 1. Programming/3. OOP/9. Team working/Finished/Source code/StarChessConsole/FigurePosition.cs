namespace StarChessConsole
{
    public class FigurePositions
    {
        private FigureProperties[,] position = new FigureProperties[8, 8];

        public FigureProperties[,] Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
    }
}
