namespace Spline_Lab3
{
    internal class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double VectorParam { get; set; }

        public Vector(double X, double Y, double VectorParam)
        {
            this.X = X;
            this.Y = Y;
            this.VectorParam = VectorParam;
        }

        public Vector()
        {
            X = 0;
            Y = 0;
            VectorParam = 1;
        }
    }
}
