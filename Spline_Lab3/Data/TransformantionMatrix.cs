using System;

namespace Spline_Lab3
{
    internal class TransformantionMatrix : IMatrix
    {
        private double[,] _matrix;

        public TransformantionMatrix()
        {
            _matrix = new double[3, 3];
        }

        public void FillRotateMatrix(double rotationAngle)
        {
            rotationAngle = -Math.PI * rotationAngle / 180.0;

            _matrix[0, 0] = Math.Cos(rotationAngle);
            _matrix[0, 1] = -Math.Sin(rotationAngle);
            _matrix[0, 2] = 0;
            _matrix[1, 0] = Math.Sin(rotationAngle);
            _matrix[1, 1] = Math.Cos(rotationAngle);
            _matrix[1, 2] = 0;
            _matrix[2, 2] = 1;
        }

        public void FillScaleMatrix(Vector scaleVector)
        {
            _matrix[0, 0] = scaleVector.X;
            _matrix[0, 1] = 0;
            _matrix[0, 2] = 0;
            _matrix[1, 0] = 0;
            _matrix[1, 1] = scaleVector.Y;
            _matrix[1, 2] = 0;
            _matrix[2, 2] = scaleVector.VectorParam;
        }

        public void FillTransportMatrix(Vector transportVector)
        {
            _matrix[0, 0] = 1;
            _matrix[0, 1] = 0;
            _matrix[0, 2] = transportVector.X;
            _matrix[1, 0] = 1;
            _matrix[1, 1] = 1;
            _matrix[1, 2] = transportVector.Y; 
            _matrix[2, 2] = transportVector.VectorParam;
        }

        public double[,] GetMatrix()
        {
            return _matrix;
        }
    }
}