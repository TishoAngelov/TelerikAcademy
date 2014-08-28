using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> prodObj = new List<GameObject>();
            prodObj.Add(new TrailObject(3, base.topLeft, new char[,] { { '^' } }));

            return prodObj;
        }
    }
}