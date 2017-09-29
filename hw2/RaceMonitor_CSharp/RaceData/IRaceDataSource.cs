namespace RaceData
{
    interface IRaceDataSource
    {
        string InputFilename { get; set; }
        IAthleteUpdateHandler Handler { get; set; }
        int SleepTimeForSimulatedSecond { get; set; }

        void Start();
        void Stop();
    }
}
