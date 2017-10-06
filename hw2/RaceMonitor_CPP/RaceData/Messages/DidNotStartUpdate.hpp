#ifndef DID_NOT_START_UPDATE_HPP
#define DID_NOT_START_UPDATE_HPP

// Package Headers
#include "../AthleteRaceStatus.hpp"
#include "AthleteUpdate.hpp"

// STD Libs
#include <stdexcept>
#include <string>
#include <vector>

namespace RaceData
{
namespace Messages
{
class DidNotStartUpdate : public AthleteUpdate
{
  public:
    DidNotStartUpdate() : AthleteUpdate(AthleteRaceStatus::DidNotStart) {}
    DidNotStartUpdate(std::vector<std::string> properties) : AthleteUpdate(AthleteRaceStatus::DidNotStart, properties)
    {
        if (properties.size() != 3 || Utils::StatusFromString(properties[0]) != AthleteRaceStatus::DidNotStart)
            throw std::runtime_error("Invalid properties");
    }
};
}
}

#endif // DID_NOT_START_UPDATE_HPP