#ifndef ATHLETE_UDPATE_HPP
#define ATHLETE_UDPATE_HPP

// Package Headers
#include "../AthleteRaceStatus.hpp"

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
class AthleteUpdate
{
public:
  AthleteRaceStatus UpdateType;
  int BibNumber;
  std::time_t Timestamp;

  // SEE MESSAGE FACTORY FOR CREATE METHOD

  virtual std::string ToString()
  {
    return Utils::StatusToString(UpdateType) + "," + std::to_string(BibNumber) + "," + TimeToString(Timestamp);
  }

protected:
  AthleteUpdate(AthleteRaceStatus type) : UpdateType(type) {}
  AthleteUpdate(AthleteRaceStatus type, std::vector<std::string> properties) : UpdateType(type), BibNumber(std::stoi(properties[1])), Timestamp(TimeFromString(properties[2])) {}

  // Parse out a std::time_t from a std::string
  // NOTE: Don't use std::get_time() as it has a
  //   bug that requires the leading zeros on hour and month
  std::time_t TimeFromString(std::string time_string)
  {
    std::tm tm = {};

/** !!!!!!!!! WARNING !!!!!!!!!! **/
/** std::get_time has issues on some platforms
     *  with parsing months, dates, and hours without
     *  leading zeros (8/1/2017 vs 08/01/2017). */
#ifdef _WIN32
    std::stringstream ss(time_string);
    ss.imbue(std::locale("en_US.utf-8"));
    ss >> std::get_time(&tm, "%m/%d/%Y %I:%M:%S %p");
    if (ss.fail())
      throw std::runtime_error("DateTime parse failed on string: " + ss.str());
#else
    if (strptime(time_string.c_str(), "%m/%d/%Y %I:%M:%S %p", &tm) == NULL)
      throw std::runtime_error("DateTime parse failed on string: " + time_string);
#endif

    tm.tm_isdst = -1; // Tell std::mktime to figure out the timezone
    return std::mktime(&tm);
  }

  // Convert std::time_t to std::string
  std::string TimeToString(std::time_t t)
  {
    std::stringstream ss;
    ss.imbue(std::locale("en_US.utf-8"));
    ss << std::put_time(std::localtime(&t), "%m/%d/%Y %I:%M:%S %p");
    return ss.str();
  }
};
}
}

#endif // ATHLETE_UDPATE_HPP