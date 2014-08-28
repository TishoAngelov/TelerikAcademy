using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "explodingBlock";

        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft)
        {
            base.body = new char[,] { { 'B' } };
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();

            if (this.IsDestroyed)
            {
                produceObjects.Add(new Shrapnel(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(-1, 0)));
                produceObjects.Add(new Shrapnel(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(1, 0)));
                produceObjects.Add(new Shrapnel(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(0, 1)));
                produceObjects.Add(new Shrapnel(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(0, -1)));
            }

            return produceObjects;
        }
    }
}