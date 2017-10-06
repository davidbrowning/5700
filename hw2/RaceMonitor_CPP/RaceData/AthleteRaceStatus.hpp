#ifndef ATHLETE_RACE_STATUS_HPP
#define ATHLETE_RACE_STATUS_HPP

#include <stdexcept>
#include <string>

namespace RaceData
{
enum class AthleteRaceStatus
{
  Registered = 1,
  DidNotStart = 2,
  Started = 3,
  OnCourse = 4,
  DidNotFinish = 5,
  Finished = 6
};

class Utils
{
public:
  static AthleteRaceStatus StatusFromString(std::string type)
  {
    if (type == "Registered")
      return AthleteRaceStatus::Registered;
    else if (type == "DidNotFinish")
      return AthleteRaceStatus::DidNotFinish;
    else if (type == "DidNotStart")
      return AthleteRaceStatus::DidNotStart;
    else if (type == "Started")
      return AthleteRaceStatus::Started;
    else if (type == "Finished")
      return AthleteRaceStatus::Finished;
    else if (type == "OnCourse")
      return AthleteRaceStatus::OnCourse;
    else
      throw std::runtime_error("Invalid AthleteUpdate type");
  }

  static std::string StatusToString(AthleteRaceStatus status)
  {
    switch (status)
    {
    case AthleteRaceStatus::Registered:
      return "Registered";
    case AthleteRaceStatus::DidNotFinish:
      return "DidNotFinish";
    case AthleteRaceStatus::DidNotStart:
      return "DidNotStart";
    case AthleteRaceStatus::Started:
      return "Started";
    case AthleteRaceStatus::Finished:
      return "Finished";
    case AthleteRaceStatus::OnCourse:
      return "OnCourse";
    default:
      throw std::runtime_error("Invalid AthleteUpdate type");
    }
  }
};
}

#endif // ATHLETE_RACE_STATUS_HPP