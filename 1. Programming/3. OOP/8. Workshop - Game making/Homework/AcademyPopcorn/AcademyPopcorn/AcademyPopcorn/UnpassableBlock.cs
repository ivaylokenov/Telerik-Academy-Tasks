namespace AcademyPopcorn
{
    class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "UnpasableBlock";
        public new const char Symbol = '@';

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }
    }
}
