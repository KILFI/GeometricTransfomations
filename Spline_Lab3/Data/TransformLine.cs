using System.Collections.Generic;
using System.Windows;

namespace Spline_Lab3
{
    internal class TransformLine : ITransformable
    {
        private Point _centerCanvasPoint;

        public TransformLine(Point centerPoint)
        {
            _centerCanvasPoint = centerPoint;
        }
        public List<Vector> TransportLine(IMatrix inputMatrix, List<Vector> inputVectors)
        {
            double[,] transportMatrix = inputMatrix.GetMatrix();
            List<Vector> vectorList = new List<Vector>(); 
            Vector bufVector;

            foreach (Vector v in inputVectors) 
            {
                bufVector = new Vector(); 

                v.X += transportMatrix[0, 2];
                v.Y += transportMatrix[1, 2]; 
                v.VectorParam = 1;

                bufVector.X = v.X + _centerCanvasPoint.X; 
                bufVector.Y = _centerCanvasPoint.Y - v.Y; 
                bufVector.VectorParam = 1;

                vectorList.Add(bufVector);
            }

            return vectorList;
        }

        public List<Vector> ScaleLine(IMatrix inputMatrix, List<Vector> inputVectors)
        {
            double[,] scaleMatrix = inputMatrix.GetMatrix();
            List<Vector> vectorList = new List<Vector>(); 
            Vector bufVector;

            foreach (Vector v in inputVectors)
            {
                bufVector = new Vector();

                v.X *= scaleMatrix[0, 0];
                v.Y *= scaleMatrix[1, 1];
                v.VectorParam = 1;

                bufVector.X = v.X + _centerCanvasPoint.X; 
                bufVector.Y = _centerCanvasPoint.Y - v.Y;
                bufVector.VectorParam = 1;

                vectorList.Add(bufVector);
            }

            return vectorList;
        }

        public List<Vector> RotateLine(IMatrix inputMatrix, List<Vector> inputVectors)
        {
            double[,] rotationMatrix = inputMatrix.GetMatrix();
            List<Vector> vectorList = new List<Vector>();
            Vector bufVector;

            foreach (Vector v in inputVectors) 
            {
                bufVector = new Vector();

                double x = v.X * rotationMatrix[0, 0] + v.Y * rotationMatrix[0, 1]; 
                double y = v.X * rotationMatrix[1, 0] + v.Y * rotationMatrix[1, 1]; 

                v.X = x;
                v.Y = y;
                v.VectorParam = 1;

                bufVector.X = v.X + _centerCanvasPoint.X; 
                bufVector.Y = _centerCanvasPoint.Y - v.Y; 
                bufVector.VectorParam = 1;

                vectorList.Add(bufVector);
            }

            return vectorList;
        }
    }
}
