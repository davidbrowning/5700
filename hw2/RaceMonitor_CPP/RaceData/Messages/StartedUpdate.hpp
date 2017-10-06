#ifndef STARTED_UPDATE_HPP
#define STARTED_UPDATE_HPP

// Package Headers
#include "../AthleteRaceStatus.hpp"
#include "AthleteUpdate.hpp"

// STD Libs
#include <ctime>
#include <iomanip>
#include <sstream>
#include <stdexcept>
#include <string>
#include <vector>

namespace RaceData
{
namespace Messages
{
class StartedUpdate : public AthleteUpdate
{
  public:
    std::time_t OfficialStartTime;

    StartedUpdate() : AthleteUpdate(AthleteRaceStatus::Started) {}
    StartedUpdate(std::vector<std::string> properties) : AthleteUpdate(AthleteRaceStatus::Started, properties), OfficialStartTime(AthleteUpdate::TimeFromString(properties[3]))
    {
        if (properties.size() != 4 || Utils::StatusFromString(properties[0]) != AthleteRaceStatus::Started)
            throw std::runtime_error("Invalid properties");
    }

    virtual std::string ToString()
    {
        return AthleteUpdate::ToString() + "," + AthleteUpdate::TimeToString(OfficialStartTime);
    }
};
}
}

#endif // STARTED_UPDATE_HPP