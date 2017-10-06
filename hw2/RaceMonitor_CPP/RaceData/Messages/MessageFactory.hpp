#ifndef MESSAGE_FACTORY_HPP
#define MESSAGE_FACTORY_HPP

// Package Headers
#include "../AthleteRaceStatus.hpp"
#include "AthleteUpdate.hpp"
#include "RegistrationUpdate.hpp"
#include "DidNotStartUpdate.hpp"
#include "StartedUpdate.hpp"
#include "LocationUpdate.hpp"
#include "DidNotFinishUpdate.hpp"
#include "FinishedUpdate.hpp"

// STD Libs
#include <string>
#include <vector>

namespace RaceData
{
namespace Messages
{
class MessageFactory
{
  public:
    static std::shared_ptr<AthleteUpdate> Create(std::string simulationData)
    {
        if (simulationData.empty())
            return nullptr;

        std::vector<std::string> fields = MessageFactory::Split(simulationData, ',');
        AthleteRaceStatus objectType = Utils::StatusFromString(fields[0]);

        switch (objectType)
        {
        case AthleteRaceStatus::Registered:
            return std::make_shared<RegistrationUpdate>(fields);
        case AthleteRaceStatus::DidNotStart:
            return std::make_shared<DidNotStartUpdate>(fields);
        case AthleteRaceStatus::Started:
            return std::make_shared<StartedUpdate>(fields);
        case AthleteRaceStatus::OnCourse:
            return std::make_shared<LocationUpdate>(fields);
        case AthleteRaceStatus::DidNotFinish:
            return std::make_shared<DidNotFinishUpdate>(fields);
        case AthleteRaceStatus::Finished:
            return std::make_shared<FinishedUpdate>(fields);
        default:
            throw std::runtime_error("Invalid AthleteUpdate type");
        }
    }

  private:
    static std::vector<std::string> Split(const std::string &s, char delim)
    {
        std::vector<std::string> split_string;
        std::string::size_type prev_pos = 0, pos = 0;
        while ((pos = s.find(delim, pos)) != std::string::npos)
        {
            std::string sub(s.substr(prev_pos, pos - prev_pos));
            split_string.push_back(sub);
            prev_pos = ++pos;
        }

        split_string.push_back(s.substr(prev_pos, pos - prev_pos));
        return split_string;
    }
};
}
}

#endif // MESSAGE_FACTORY_HPP