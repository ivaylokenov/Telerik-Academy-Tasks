using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            // standart blocks

            #region Standart Blocks

            for (int row = 2; row < 5; row++)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    Block standartBlock = new Block(new MatrixCoords(row, col));
                    engine.AddObject(standartBlock);
                }
            }

            #endregion

            #region GameField Walls

            for (int row = 0; row < WorldRows - 2; row++)
            {
                IndestructibleBlock leftWallBlock = new IndestructibleBlock(new MatrixCoords(row + 2, startCol - 2));
                IndestructibleBlock rightWallBlock = new IndestructibleBlock(new MatrixCoords(row + 2, endCol + 1));
                engine.AddObject(rightWallBlock);
                engine.AddObject(leftWallBlock);
            }

            for (int col = 0; col < WorldCols; col++)
            {
                IndestructibleBlock topWallBlock = new IndestructibleBlock(new MatrixCoords(startRow - 2, col));
                engine.AddObject(topWallBlock);
            }

            #endregion

            #region Impassable Blocks

            for (int col = 1; col < WorldCols - 1; col++)
            {
                //if (col == 1 || col == 2) continue;
                ImpassableBlock imBlock = new ImpassableBlock(new MatrixCoords(11, col));
                engine.AddObject(imBlock);
            }

            #endregion

            #region Explosion Blocks

            for (int col = 2; col < WorldCols - 1; col += 1)
            {
                ExplodingBlock expBlock = new ExplodingBlock(new MatrixCoords(5, col));
                engine.AddObject(expBlock);
            }

            #endregion

            #region Gift Blocks

            for (int col = 1; col < WorldCols-1; col+=5)
            {
                GiftBlock giftBlocks = new GiftBlock(new MatrixCoords(6, col));
                engine.AddObject(giftBlocks);
            }

            #endregion

            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new EngineShootRacket(renderer, keyboard, 50);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
