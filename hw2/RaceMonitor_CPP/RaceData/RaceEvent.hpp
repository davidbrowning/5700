#ifndef RACE_EVENT_HPP
#define RACE_EVENT_HPP

// STD Libs
#include <ctime>
#include <string>

namespace RaceData
{
struct RaceEvent
{
    int Id;
    std::string Title;
    std::time_t StartDateTime;
};
}

#endif // RACE_EVENT_HPP