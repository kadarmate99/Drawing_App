﻿using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.Presenter.Commands
{
    internal class DrawRhombusCommand : IDrawingCommand
    {
        private Node _startPoint;
        private Color _currentColor;

        public DrawRhombusCommand(Color currentColor, Node startPoint)
        {
            _startPoint = startPoint;
            _currentColor = currentColor;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            if (_startPoint != null)
            {
                ShapeRhombus rhombus = new ShapeRhombus(_currentColor, _startPoint, new Node(_currentColor, x, y));
                model.AddShape(rhombus);
            }
        }
    }
}
