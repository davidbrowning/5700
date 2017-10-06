#ifndef LOCATION_UPDATE_HPP
#define LOCATION_UPDATE_HPP

// Package Headers
#include "../AthleteRaceStatus.hpp"
#include "AthleteUpdate.hpp"

// STD Libs
#include <iomanip>
#include <stdexcept>
#include <sstream>
#include <string>
#include <vector>

namespace RaceData
{
namespace Messages
{
class LocationUpdate : public AthleteUpdate
{
  public:
    double LocationOnCourse;

    LocationUpdate() : AthleteUpdate(AthleteRaceStatus::OnCourse) {}
    LocationUpdate(std::vector<std::string> properties) : AthleteUpdate(AthleteRaceStatus::OnCourse, properties), LocationOnCourse(std::stod(properties[3]))
    {
        if (properties.size() != 4 || Utils::StatusFromString(properties[0]) != AthleteRaceStatus::OnCourse)
            throw std::runtime_error("Invalid properties");
    }

    virtual std::string ToString()
    {
        std::stringstream ss;
        ss << std::setprecision(16);
        ss << LocationOnCourse;
        return AthleteUpdate::ToString() + "," + ss.str();
    }
};
}
}

#endif // LOCATION_UPDATE_HPP