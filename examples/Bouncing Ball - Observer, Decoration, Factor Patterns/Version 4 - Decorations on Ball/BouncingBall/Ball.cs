using System;
using System.Threading;
using System.Drawing;

namespace BouncingBall
{
    public class Ball : Subject
    {
        #region Private data members
        protected static readonly Random Randomizer = new Random();
        private static int _nextBallId = 1;
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
        public Ball() { Id = GetNextId(); }
        #endregion

        #region Public properties
        public virtual int Id { get; }
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Radius { get; set; }
        public virtual double Direction { get; set; }
        public virtual double Speed { get; set; }
        public virtual Color Color { get; set; } = Color.Transparent;

        // Convenient methods for working with the state and simulation
        public int DelayBetweenMovements { get; set; }
        protected double LeftBoarder => Radius;
        protected double BottomBoarder => Radius;
        protected double RightBoarder => Box.Width - Radius;
        protected double TopBoarder => Box.Height - Radius;

        // Supporting method for measuring performance
        public int StateChanges { get; set; }

        // Supporting method for choosing a random color
        public static Color RandomColor => PossibleColors[Randomizer.Next(0, PossibleColors.Length)];

        #endregion

        #region Public Methods
        public virtual void Start()
        {
            SetupDefaults();
            _timer = new Timer(Move, null, DelayBetweenMovements, DelayBetweenMovements);
        }

        public virtual void Stop()
        {
            _timer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            _timer = null;
        }

        #endregion

        #region Private Methods
        private void Move(object sender)
        {
            double newX = X + Speed * Math.Cos(DegreeToRadian(Direction));
            double newY = Y + Speed * Math.Sin(DegreeToRadian(Direction));

            bool bouncing = true;
            while (bouncing)
            {
                bouncing = false;
                if (newX < LeftBoarder)
                {
                    newX = 2 * LeftBoarder - newX;
                    Direction = ReboundOnXAxis(Direction);
                    bouncing = true;
                }

                if (newX > RightBoarder)
                {
                    newX = 2 * RightBoarder - newX;
                    Direction = ReboundOnXAxis(Direction);
                    bouncing = true;
                }

                if (newY < BottomBoarder)
                {
                    newY = 2 * BottomBoarder - newY;
                    Direction = ReboundOnYAxis(Direction);
                    bouncing = true;
                }

                if (newY > TopBoarder)
                {
                    newY = 2 * TopBoarder - newY;
                    Direction = ReboundOnYAxis(Direction);
                    bouncing = true;
                }

            }
            X = newX;
            Y = newY;
            StateChanges++;
            Notify();
        }

        private double DegreeToRadian(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        private double ReboundOnXAxis(double degrees)
        {
            double result = degrees % 360;
            if (result > 0 && result <= 180) result = 180 - result;
            else result = -180 - result;
            return result;
        }

        private double ReboundOnYAxis(double degrees)
        {
            return -(degrees % 360);
        }

        private void SetupDefaults()
        {
            if (Radius <= 0)
                Radius = Randomizer.Next(3, Math.Min(20,Math.Min(Box.Width/2,Box.Height/2)));

            if (X <= 0)
                X = Randomizer.Next(Convert.ToInt32(Radius), Box.Width - Convert.ToInt32(Radius));

            if (Y <= 0)
                Y = Randomizer.Next(Convert.ToInt32(Radius), Box.Height - Convert.ToInt32(Radius));

            if (Direction <= 0)
                Direction = Randomizer.Next(0, 360);

            if (Speed <= 0)
                Speed = Randomizer.Next(1, 10);

            if (DelayBetweenMovements == 0)
                DelayBetweenMovements = 20;

            if (Color == Color.Transparent)
                Color = RandomColor;

        }

        private int GetNextId()
        {
            int nextId = _nextBallId;
            if (_nextBallId == Int32.MaxValue)
                _nextBallId = 1;
            else
                _nextBallId++;
            return nextId;
        }
        #endregion
    }
}
