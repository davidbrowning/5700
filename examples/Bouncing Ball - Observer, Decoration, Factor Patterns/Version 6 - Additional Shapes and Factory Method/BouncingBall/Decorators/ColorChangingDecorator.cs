using System;
using System.Drawing;
using System.Threading;
using Shapes;

namespace BouncingBall.Decorators
{
    public class ColorChangingDecorator : ShapeDecorator
    {
        private enum ChangeDirection
        {
            ToAlt,
            ToNormal
        };
        private Timer _changeTimer;
        private ChangeDirection _changeType = ChangeDirection.ToAlt;
        private Color _normalColor;

        public Color AltColor { get; set; }
        public int DelayBetweenChanges { get; set; }

        public override void Start()
        {
            if (DecoratedShape == null) return;

            base.Start();

            _normalColor = DecoratedShape.Color;

            if (DelayBetweenChanges == 0)
                DelayBetweenChanges = 10;

            _changeTimer = new Timer(ChangeColor, null, DelayBetweenChanges, DelayBetweenChanges);
        }

        public override void Stop()
        {
            _changeTimer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            _changeTimer = null;
            base.Stop();
        }

        private void ChangeColor(object sender)
        {
            if (_changeType == ChangeDirection.ToAlt)
            {
                DecoratedShape.Color = NextColor(DecoratedShape.Color, AltColor);
                if (ColorAreEquivilent(DecoratedShape.Color, AltColor))
                    _changeType = ChangeDirection.ToNormal;
            }
            else
            {
                DecoratedShape.Color = NextColor(DecoratedShape.Color, _normalColor);
                if (ColorAreEquivilent(DecoratedShape.Color, _normalColor))
                    _changeType = ChangeDirection.ToAlt;
            }
            Notify();
        }

        private bool ColorAreEquivilent(Color c1, Color c2)
        {
            return (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B && c1.A == c2.A);
        }

        private Color NextColor(Color currentColor, Color goalColor)
        {
            byte r = NextColorByte(currentColor.R, goalColor.R);
            byte g = NextColorByte(currentColor.G, goalColor.G);
            byte b = NextColorByte(currentColor.B, goalColor.B);
            byte a = NextColorByte(currentColor.A, goalColor.A);
            return Color.FromArgb(a, r, g, b);
        }

        private byte NextColorByte(byte currentByte, byte goalByte)
        {
            int different = goalByte - currentByte;

            if (different > 0)
                currentByte = Convert.ToByte(Math.Min(currentByte + 1, goalByte));
            else if (different < 0)
                currentByte = Convert.ToByte(Math.Max(currentByte - 1, goalByte));

            return currentByte;
        }
    }
}
