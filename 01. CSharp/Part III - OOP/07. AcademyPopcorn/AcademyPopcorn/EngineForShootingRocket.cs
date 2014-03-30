using System;

namespace AcademyPopcorn
{
    public class EngineForShootingRocket : Engine
    {
        public EngineForShootingRocket(int sleepTime, IRenderer renderer, IUserInterface userInterface) : base(sleepTime, renderer, userInterface)
        {
        }

        public void ShootPlayerRacket()
        {
            if (base.playerRacket is ShoothingRacket)
            {
                (base.playerRacket as ShoothingRacket).Shoot();
            }
        }
    }
}