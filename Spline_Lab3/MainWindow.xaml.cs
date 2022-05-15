using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Spline_Lab3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserMatrixTB.IsEnabled = false;
            CoordoutTB.IsEnabled = false;
        }

        private TransformLine _transformLine;
        private List<Vector> _inputUserVectors;
        private List<Vector> _currentUserVectors;
        private Point _centerCanvasPoint;
        private IMatrix _matrix;

        private void DrawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickedPoint = e.GetPosition(DrawCanvas);
            _inputUserVectors.Add(new Vector(clickedPoint.X, clickedPoint.Y, 1));
            DrawLine(_inputUserVectors, PinkLine);
            CalculateCurrentUserVector();

            CoordoutTB.Text += $"X: {e.GetPosition(DrawCanvas).X}   Y:{e.GetPosition(DrawCanvas).Y}\n";
        }

        private void DrawLine(List<Vector> _vectorList, Polyline drawableLine)
        {
            drawableLine.Visibility = Visibility.Visible;
            CoordoutTB.Clear();

            PointCollection userPoints = new PointCollection();
            foreach (Vector v in _vectorList)
            {
                Point point = new Point()
                {
                    X = v.X,
                    Y = v.Y
                };
                userPoints.Add(point);

                CoordoutTB.Text += $"X: {(int)point.X}   Y:{(int)point.Y}\n";
            }

            drawableLine.Points = userPoints;
        }

        private void InterfaceWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _centerCanvasPoint = new Point(DrawCanvas.ActualWidth / 2, ActualHeight / 2);
            _transformLine = new TransformLine(_centerCanvasPoint);
            _matrix = new TransformantionMatrix();
            _currentUserVectors = new List<Vector>();
            _inputUserVectors = new List<Vector>();
        }

        private void LoadUserMatrix()
        {
            UserMatrixTB.Clear();
            double[,] data = _matrix.GetMatrix();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    UserMatrixTB.Text += $"{data[i, j]:f1}\t";
                }
                UserMatrixTB.Text += "\n\n";
            }
        }

        private void ScaleBtn_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(scaleX_TB.Text, out double scaleX);
            double.TryParse(scaleY_TB.Text, out double scaleY);

            if (scaleX != 0 && scaleY != 0) 
            {
                _matrix.FillScaleMatrix(new Vector(scaleX, scaleY, 1));
                DrawLine(_transformLine.ScaleLine(_matrix, _currentUserVectors), BlueLine);
                LoadUserMatrix();
            }
            else
            {
                MessageBox.Show("Введите числа отличающиеся от 0");
            }
        }

        private void TransportBtn_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(X_TB.Text, out double x);
            double.TryParse(Y_TB.Text, out double y);

            if (x != 0 || y != 0)
            {
                _matrix.FillTransportMatrix(new Vector(x, y, 1));
                DrawLine(_transformLine.TransportLine(_matrix, _currentUserVectors), BlueLine);
                LoadUserMatrix();
            }
            else
            {
                MessageBox.Show("Введите числа");
            }
        }

        private void RotateBtn_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(RotateTB.Text, out double _rotation);

            if(_rotation != 0)
            {
                _matrix.FillRotateMatrix(_rotation);
                DrawLine(_transformLine.RotateLine(_matrix, _currentUserVectors), BlueLine);
                LoadUserMatrix();
            }
            else
            {
                MessageBox.Show("Введите число отличающиеся от 0");
            }
        }

        private void CalculateCurrentUserVector()
        {
            _currentUserVectors.Clear();

            foreach (Vector v in _inputUserVectors)
            {
                _currentUserVectors.Add(new Vector(v.X - _centerCanvasPoint.X, _centerCanvasPoint.Y - v.Y, 1));
            }
        }

        private void ResetMatrixBtn_Click(object sender, RoutedEventArgs e)
        {
            scaleX_TB.Clear();
            scaleY_TB.Clear();
            X_TB.Clear();
            Y_TB.Clear();
            CoordoutTB.Clear();
            UserMatrixTB.Clear();
            RotateTB.Clear();
            BlueLine.Visibility = Visibility.Hidden;
            CalculateCurrentUserVector();
        }

        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueLine.Points.Clear();
            PinkLine.Points.Clear();
            scaleX_TB.Clear();
            scaleY_TB.Clear();
            X_TB.Clear();
            Y_TB.Clear();
            CoordoutTB.Clear();
            UserMatrixTB.Clear();
            RotateTB.Clear();
            _inputUserVectors.Clear();
        }
    }
}
