using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class EngineShootRacket : Engine
    {
        public EngineShootRacket(IRenderer renderer, IUserInterface userInterface, int gameSpeed)
            : base(renderer, userInterface, gameSpeed)
        {
        }

        public void ShootPlayerRacket()
        {

            this.RemoveRacket();
        }
    }
}
