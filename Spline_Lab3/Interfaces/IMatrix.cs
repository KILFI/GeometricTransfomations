namespace Spline_Lab3
{
    internal interface IMatrix
    {
        void FillTransportMatrix(Vector transportVector);
        void FillScaleMatrix(Vector scaleVector);
        void FillRotateMatrix(double rotationAngle);

        double[,] GetMatrix();
    }
}
