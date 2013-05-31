using System;

namespace AcademyPopcorn
{
    //Task 4
    class EngineExtensions : Engine
    {
        public EngineExtensions(IRenderer renderer, IUserInterface userInterface, int sleepTimeout)
            : base(renderer, userInterface, sleepTimeout)
        {
        }

        public void ShootWithPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
