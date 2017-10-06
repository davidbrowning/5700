#ifndef REGISTRATION_UPDATE_HPP
#define REGISTRATION_UPDATE_HPP

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
class RegistrationUpdate : public AthleteUpdate
{
  public:
    std::string FirstName;
    std::string LastName;
    std::string Gender;
    int Age;

    RegistrationUpdate() : AthleteUpdate(AthleteRaceStatus::Registered) {}
    RegistrationUpdate(std::vector<std::string> properties) : AthleteUpdate(AthleteRaceStatus::Registered, properties),
                                                              FirstName(properties[3]), LastName(properties[4]), Gender(properties[5]), Age(std::stoi(properties[6]))
    {
        if (properties.size() != 7 || Utils::StatusFromString(properties[0]) != AthleteRaceStatus::Registered)
            throw std::runtime_error("Invalid properties");
    }

    virtual std::string ToString()
    {
        return AthleteUpdate::ToString() + "," + FirstName + "," + LastName + "," + Gender + "," + std::to_string(Age);
    }
};
}
}

#endif // REGISTRATION_UPDATE_HPP