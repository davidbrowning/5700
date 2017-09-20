using System;
using System.Threading;

namespace BouncingBall
{
    public class Ball : Subject
    {
        #region Private data members
        private static readonly Random Randomizer = new Random();
        private static int _nextBallId = 1;
        private int _id;
        private Timer _timer;
        #endregion

        public Ball() { _id = GetNextId(); }

        #region Public properties
        public int Id { get { return _id; } }
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public double Direction { get; set; }
        public double Speed { get; set; }

        // Convenient methods for working with the state and simulation
        public int DelayBetweenMovements { get; set; }
        public double LeftBoarder { get { return Radius; } }
        public double BottomBoarder { get { return Radius; } }
        public double RightBoarder { get { return Box.Width - Radius; } }
        public double TopBoarder { get { return Box.Height - Radius; } }

        // Supporting methods for measuring performance
        public int StateChanges { get; set; }
        #endregion

        #region Public Methods
        public void Start()
        {
            SetupDefaults();
            _timer = new Timer(Move, null, DelayBetweenMovements, DelayBetweenMovements);
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

        private int ChooseRandomInteger(int min, int exclusiveMax)
        {
            return Randomizer.Next(min, exclusiveMax);
        }

        private void SetupDefaults()
        {
            if (Radius <= 0)
                Radius = ChooseRandomInteger(3, Math.Min(20,Math.Min(Box.Width/2,Box.Height/2)));

            if (X <= 0)
                X = ChooseRandomInteger(Convert.ToInt32(Radius), Box.Width - Convert.ToInt32(Radius));

            if (Y <= 0)
                Y = ChooseRandomInteger(Convert.ToInt32(Radius), Box.Height - Convert.ToInt32(Radius));

            if (Direction <= 0)
                Direction = ChooseRandomInteger(0, 360);

            if (Speed <= 0)
                Speed = ChooseRandomInteger(1, 10);

            if (DelayBetweenMovements == 0)
                DelayBetweenMovements = 10;

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
