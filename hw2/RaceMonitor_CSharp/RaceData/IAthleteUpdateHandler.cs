using System;
using RaceData.Messages;

namespace RaceData
{
    public interface IAthleteUpdateHandler
    {
        void ProcessUpdate(AthleteUpdate updateMessage);
    }
}
