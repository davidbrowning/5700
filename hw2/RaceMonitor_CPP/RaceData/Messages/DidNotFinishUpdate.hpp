#ifndef DID_NOT_FINISH_UPDATE_HPP
#define DID_NOT_FINISH_UPDATE_HPP

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
class DidNotFinishUpdate : public AthleteUpdate
{
  public:
    DidNotFinishUpdate() : AthleteUpdate(AthleteRaceStatus::DidNotFinish) {}
    DidNotFinishUpdate(std::vector<std::string> properties) : AthleteUpdate(AthleteRaceStatus::DidNotFinish, properties)
    {
        if (properties.size() != 3 || Utils::StatusFromString(properties[0]) != AthleteRaceStatus::DidNotFinish)
            throw std::runtime_error("Invalid properties");
    }
};
}
}

#endif // DID_NOT_FINISH_UPDATE_HPP