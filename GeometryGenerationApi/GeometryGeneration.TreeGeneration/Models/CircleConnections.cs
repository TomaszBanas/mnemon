using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.Model.Extension;

namespace GeometryGeneration.GeometryGeneration.Models
{
    internal class CircleConnections
    {

        public Vector3D Start { get; set; }
        public Vector3D End { get; set; }
        public bool RandomizeStart { get; set; } = false;
        public bool RandomizeMiddle { get; set; } = true;
        public bool RandomizeEnd { get; set; } = false;

        public CircleConnections(Vector3D start, Vector3D end)
        {
            Start = start;
            End = end;
        }

        public IEnumerable<Vector3D> Seperate(int noOfSeperation, Random rand)
        {
            var dir = End.Clone().Substract(Start);
            var length = dir.Length();
            var partLength = length / (noOfSeperation - 1);
            var randPartLength = partLength;
            dir.Normalize();
            var randDir = dir.Clone().Add(new Vector3D((float)0.1, (float)0.1, (float)0.1));
            randDir.Normalize();
            yield return CreatePoint(dir, randDir, randPartLength, partLength, 0, rand, RandomizeStart);
            for (int i = 1; i < noOfSeperation-1; i++)
            {
                yield return CreatePoint(dir, randDir, randPartLength, partLength, i, rand, RandomizeMiddle);
            }
            yield return CreatePoint(dir, randDir, randPartLength, partLength, (noOfSeperation - 1), rand, RandomizeEnd);
        }

        private Vector3D CreatePoint(Vector3D dir, Vector3D randDir, double randPartLength, double partLength, int i, Random rand, bool randomize)
        {
            var randV = new Vector3D(0, 0, 0);
            if (randomize)
                randV = new Vector3D(rand.NextSingle(-randPartLength, randPartLength), rand.NextSingle(-randPartLength, randPartLength), rand.NextSingle(-randPartLength, randPartLength));
            return Start.Clone().Add( (dir.Clone().MultiplyScalar(partLength * i))).Add((randDir.Clone().Multiply(randV)));
        }
    }
}
