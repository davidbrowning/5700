#ifndef FINISHED_UPDATE_HPP
#define FINISHED_UPDATE_HPP

// Package Headers
#include "../AthleteRaceStatus.hpp"
#include "AthleteUpdate.hpp"

// STD Libs
#include <ctime>
#include <locale>
#include <iomanip>
#include <sstream>
#include <stdexcept>
#include <string>
#include <vector>

namespace RaceData
{
namespace Messages
{
class FinishedUpdate : public AthleteUpdate
{
  public:
    std::time_t OfficialEndTime;

    FinishedUpdate() : AthleteUpdate(AthleteRaceStatus::Finished) {}
    FinishedUpdate(std::vector<std::string> properties) : AthleteUpdate(AthleteRaceStatus::Finished, properties), OfficialEndTime(AthleteUpdate::TimeFromString(properties[3]))
    {
        if (properties.size() != 4 || Utils::StatusFromString(properties[0]) != AthleteRaceStatus::Finished)
            throw std::runtime_error("Invalid properties");
    }

    virtual std::string ToString()
    {
        return AthleteUpdate::ToString() + "," + AthleteUpdate::TimeToString(OfficialEndTime);
    }
};
}
}

#endif // FINISHED_UPDATE_HPP