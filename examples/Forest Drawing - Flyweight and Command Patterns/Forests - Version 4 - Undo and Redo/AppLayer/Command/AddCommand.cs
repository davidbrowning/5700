﻿using System;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class AddCommand : Command
    {
        private const int NormalWidth = 80;
        private const int NormalHeight = 80;

        private readonly string _componentType;
        private Point _location;
        private readonly float _scale;
        private Component _componentAdded;
        internal AddCommand() { }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: string     tree type -- a fully qualified resource name
        ///     [2]: Point      center location for the tree, defaut = top left corner
        ///     [3]: float      scale factor</param>
        internal AddCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
                _componentType = commandParameters[0] as string;

            if (commandParameters.Length > 1)
                _location = (Point) commandParameters[1];
            else
                _location = new Point(0, 0);

            if (commandParameters.Length > 2)
                _scale = (float) commandParameters[2];
            else
                _scale = 1.0F;
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(_componentType) || TargetDrawing==null) return false;

            var treeSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(NormalWidth * _scale, 0)),
                Height = Convert.ToInt16(Math.Round(NormalHeight * _scale, 0))
            };
            var treeLocation = new Point(_location.X - treeSize.Width / 2, _location.Y - treeSize.Height / 2);

            var extrinsicState = new ComponentExtrinsicState()
            {
                ComponentType = _componentType,
                Location = treeLocation,
                Size = treeSize
            };
            _componentAdded = ComponentFactory.Instance.GetComponents(extrinsicState);
            TargetDrawing.Add(_componentAdded);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteComponent(_componentAdded);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(_componentAdded);
        }
    }
}
