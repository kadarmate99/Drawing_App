using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Drawing_App_v01.View
{
    /// <summary>
    /// A specialized panel for rendering drawings with zoom and pan capabilities.
    /// Handles mouse interactions for drawing and navigation.
    /// </summary>
    public class CanvasPanel : Panel
    {
        private float _zoom = 1.0f; // Current zoom level
        private PointF _offset = new PointF(0, 0); // Position shift (for panning)
        private Point _lastMousePosition; // The previous mouse position during panning
        private bool _isPanning = false; // Whether the user is actively dragging the canvas

        public float Zoom => _zoom;
        public PointF Offset => _offset;
        public bool IsPanning => _isPanning;

        public CanvasPanel()
        {
            this.DoubleBuffered = true;
            this.MouseWheel += OnMouseWheel;
            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;
            this.Resize += OnResize;
        }

        // Handles zooming in and out with mouse wheel
        private void OnMouseWheel(object? sender, MouseEventArgs e)
        {
            float scaleFactor = (e.Delta > 0) ? 1.1f : 0.9f; // Scroll up → Zoom in, Scroll down → Zoom out
            float newZoom = _zoom * scaleFactor;

            if (newZoom < 0.2f || newZoom > 5.0f) return; // Prevent extreme zooming

            // Adjust offset to zoom around the mouse position
            _offset.X = e.X - scaleFactor * (e.X - _offset.X);
            _offset.Y = e.Y - scaleFactor * (e.Y - _offset.Y);

            _zoom = newZoom;
            Invalidate();
        }
        // Starts panning when middle mouse button is pressed
        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                _isPanning = true;
                _lastMousePosition = e.Location;
                Cursor = Cursors.SizeAll;
            }
        }
        // Moves the canvas while panning
        private void OnMouseMove(object? sender, MouseEventArgs e)
        {
            if (_isPanning)
            {
                _offset.X += (e.X - _lastMousePosition.X);
                _offset.Y += (e.Y - _lastMousePosition.Y);
                _lastMousePosition = e.Location;
                Invalidate();
            }
        }
        // Stops panning when middle mouse button is released
        private void OnMouseUp(object? sender, MouseEventArgs e)
        {
            _isPanning = false;
            Cursor = Cursors.Default;
        }
        // Applies transformations (panning & zooming) during rendering
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Apply transformations
            Matrix transform = new Matrix(); //  Identity matrix for 2D transformations
            transform.Translate(_offset.X, _offset.Y); // Move the canvas
            transform.Scale(_zoom, _zoom); // Zoom in/out
            e.Graphics.Transform = transform;
        }
        // Keeps the center position stable during resize
        private void OnResize(object? sender, EventArgs e)
        {
            _offset.X = (Width / 2) - ((_zoom * Width) / 2);
            _offset.Y = (Height / 2) - ((_zoom * Height) / 2);
            Invalidate();

        }


        /// <summary>
        /// Converts screen coordinates to world (drawing) coordinates, accounting for zoom and pan.
        /// </summary>
        /// <param name="screenPoint">The screen coordinates to convert.</param>
        /// <returns>The corresponding world coordinates.</returns>
        public Point ScreenToWorld(Point screenPoint)
        {
            using (Matrix inverseTransform = (Matrix)TransformationMatrix.Clone())
            {
                inverseTransform.Invert();
                Point[] points = { screenPoint };
                inverseTransform.TransformPoints(points);
                return points[0];
            }

        }

        /// <summary>
        /// Converts world (drawing) coordinates to screen coordinates, accounting for zoom and pan.
        /// </summary>
        /// <param name="worldPoint">The world coordinates to convert.</param>
        /// <returns>The corresponding screen coordinates.</returns>
        public Point WorldToScreen(Point worldPoint)
        {
            Point[] points = { worldPoint };
            TransformationMatrix.TransformPoints(points);
            return points[0]; // Return the transformed point
        }

        // Gets the current transformation matrix
        public Matrix TransformationMatrix
        {
            get
            {
                Matrix matrix = new Matrix();
                matrix.Translate(_offset.X, _offset.Y);
                matrix.Scale(_zoom, _zoom);
                return matrix;
            }
        }

        /// <summary>
        /// Configures the canvas view with specified zoom level and offset.
        /// </summary>
        /// <param name="savedZoom">The zoom level to apply.</param>
        /// <param name="savedOffset">The pan offset to apply.</param>
        public void SetView(float savedZoom, PointF savedOffset)
        {
            _offset = savedOffset;
            _zoom = savedZoom;
            Invalidate();
        }

    }
}
