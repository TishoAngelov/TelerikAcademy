using System;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifeTime;

        public TrailObject(int lifeTime, MatrixCoords topLeft, char[,] body) : base(topLeft, body)
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            this.lifeTime--;

            if (lifeTime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}