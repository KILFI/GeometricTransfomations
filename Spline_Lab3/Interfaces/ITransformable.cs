using System.Collections.Generic;

namespace Spline_Lab3
{
    internal interface ITransformable
    {
        List<Vector> TransportLine(IMatrix transportMatrix, List<Vector> inputLine);
        List<Vector> ScaleLine(IMatrix scaleMatrix, List<Vector> inputLine);
        List<Vector> RotateLine(IMatrix rotationMatrix, List<Vector> inputLine);
    }
}
