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

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            for (int i = startCol + 10; i < endCol- 5; i++)
            {
                UnpassableBlock currBlock = new UnpassableBlock(new MatrixCoords(startRow + 5, i));

                engine.AddObject(currBlock);
            }

            for (int i = startCol + 12; i < endCol - 7; i+=3)
            {
                ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow + 3, i));

                engine.AddObject(currBlock);
            }

            for (int i = startCol; i < endCol; i += 3)
            {
                GiftBlock currBlock = new GiftBlock(new MatrixCoords(startRow + 8, i));

                engine.AddObject(currBlock);
            }

            UnstopableBall theBall = new UnstopableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            //Task 1
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock indBlock = new IndestructibleBlock(new MatrixCoords(i,WorldCols - 1));
                engine.AddObject(indBlock);

                indBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(indBlock);
            }

            for (int i = 1; i < WorldCols - 1; i++)
            {
                IndestructibleBlock indBlock = new IndestructibleBlock(new MatrixCoords(0,i));
                engine.AddObject(indBlock);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine gameEngine = new Engine(renderer, keyboard, 100);
            EngineExtensions gameEngine = new EngineExtensions(renderer, keyboard, 100);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
