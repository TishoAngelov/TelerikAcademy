using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            base.body = new char[,] { { 'G' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();

            if (this.IsDestroyed)
            {
                produceObjects.Add(new Gift(this.topLeft));
            }
            return produceObjects;
        }
    }
}