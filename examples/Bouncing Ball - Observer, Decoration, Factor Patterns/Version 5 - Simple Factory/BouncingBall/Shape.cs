using System;
using System.Threading;
using System.Drawing;

namespace BouncingBall
{
    public abstract class Shape : Subject
    {
        #region Private data members
        protected static readonly Random Randomizer = new Random();

        private static int _nextId = 1;
        private Timer _timer;
        private static readonly Color[] PossibleColors = new Color[]
        {
            Color.Aquamarine,
            Color.AntiqueWhite,
            Color.Aqua,
            Color.Bisque,
            Color.Blue,
            Color.BlueViolet,
            Color.Brown,
            Color.BurlyWood,
            Color.CadetBlue,
            Color.Chocolate,
            Color.Coral,
            Color.CornflowerBlue,
            Color.Crimson,
            Color.DarkBlue,
            Color.DarkCyan,
            Color.DarkGoldenrod,
            Color.DarkGreen,
            Color.DarkKhaki,
            Color.DarkOrange,
            Color.DarkOrchid,
            Color.DarkSalmon,
            Color.DarkSeaGreen,
            Color.DarkTurquoise,
            Color.DeepSkyBlue,
            Color.DodgerBlue,
            Color.ForestGreen,
            Color.Gold,
            Color.Goldenrod,
            Color.Green,
            Color.GreenYellow,
            Color.IndianRed,
            Color.Khaki,
            Color.LightGreen
        };
        #endregion

        #region Constructor
        protected Shape() { Id = GetNextId(); }
        #endregion

        #region Public properties
        public Box MyBox { get; private set; }
        public virtual int Id { get; }

        public virtual float X { get; set; }
        public virtual float Y { get; set; }
        public virtual float Direction { get; set; }
        public virtual float Speed { get; set; }
        public virtual float Size { get; set; }
        public virtual Color Color { get; set; } = Color.Transparent;

        // Convenient methods for working with the state and simulation
        public int DelayBetweenMovements { get; set; }
        public abstract float LeftBorder { get; }
        public abstract float BottomBorder { get; }
        public abstract float RightBorder { get; }
        public abstract float TopBorder { get; }

        // Supporting methods for measuring performance
        public int StateChanges { get; set; }

        public static Color RandomColor => PossibleColors[Randomizer.Next(0, PossibleColors.Length)];

        #endregion

        #region Public Methods
        public virtual void Start()
        {
            _timer = new Timer(Move, null, DelayBetweenMovements, DelayBetweenMovements);
        }

        public virtual void Stop()
        {
            _timer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            _timer = null;
        }

        public abstract void Draw(Graphics graphics);

        public static Shape Create(ShapeSpecification specs, Box containingBox)
        {
            Shape shape = null;
            switch (specs.MyType)
            {
                case ShapeSpecification.ShapeType.Ball:
                    shape = new Ball();
                    break;
                case ShapeSpecification.ShapeType.Square:
                    shape = new Square();
                    break;
                case ShapeSpecification.ShapeType.Triangle:
                    shape = new Triangle();
                    break;
            }

            if (shape == null) return null;

            shape.MyBox = containingBox;
            shape.X = specs.X;
            shape.Y = specs.Y;
            shape.Direction = specs.Direction;
            shape.Speed = specs.Speed;
            shape.Size = specs.Size;
            shape.Color = specs.Color;
            shape.SetupDefaults();

            return shape;
        }

        #endregion

        #region Private Methods

        private void Move(object sender)
        {
            float newX = Convert.ToSingle(X + Speed * Math.Cos(DegreeToRadian(Direction)));
            float newY = Convert.ToSingle(Y + Speed * Math.Sin(DegreeToRadian(Direction)));

            bool bouncing = true;
            while (bouncing)
            {
                bouncing = false;
                if (newX < LeftBorder)
                {
                    newX = 2 * LeftBorder - newX;
                    Direction = ReboundOnXAxis(Direction);
                    bouncing = true;
                }

                if (newX > RightBorder)
                {
                    newX = 2 * RightBorder - newX;
                    Direction = ReboundOnXAxis(Direction);
                    bouncing = true;
                }

                if (newY < BottomBorder)
                {
                    newY = 2 * BottomBorder - newY;
                    Direction = ReboundOnYAxis(Direction);
                    bouncing = true;
                }

                if (newY > TopBorder)
                {
                    newY = 2 * TopBorder - newY;
                    Direction = ReboundOnYAxis(Direction);
                    bouncing = true;
                }

            }
            X = newX;
            Y = newY;
            StateChanges++;
            Notify();
        }

        private float DegreeToRadian(float degrees)
        {
            return Convert.ToSingle(Math.PI * degrees / 180.0);
        }

        private float ReboundOnXAxis(float degrees)
        {
            float result = degrees % 360;
            if (result > 0 && result <= 180) result = 180 - result;
            else result = -180 - result;
            return result;
        }

        private float ReboundOnYAxis(float degrees)
        {
            return -(degrees % 360);
        }

        protected virtual void SetupDefaults()
        {
            if (Size < 4)
                Size = Randomizer.Next(8, Convert.ToInt32(Math.Min(MyBox.Width, MyBox.Height)) - 8);

            if (X < 0)
                X = Randomizer.Next(Convert.ToInt32(Size), Convert.ToInt32(MyBox.Width - Size));

            if (Y < 0)
                Y = Randomizer.Next(Convert.ToInt32(Size), Convert.ToInt32(MyBox.Height - Size));

            if (Direction <= 0)
                Direction = Randomizer.Next(0, 360);

            if (Speed < 1)
                Speed = Randomizer.Next(1, 10);

            if (DelayBetweenMovements == 0)
                DelayBetweenMovements = 20;

            if (Color == Color.Transparent)
                Color = RandomColor;
        }

        private int GetNextId()
        {
            int nextId = _nextId;
            if (_nextId == int.MaxValue)
                _nextId = 1;
            else
                _nextId++;
            return nextId;
        }
        #endregion

    }

}
