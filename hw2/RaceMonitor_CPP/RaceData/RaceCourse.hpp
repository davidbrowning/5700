#ifndef RACE_COURSE_HPP
#define RACE_COURSE_HPP

// STD Libs
#include <string>

namespace RaceData
{
struct RaceCourse
{
    int Id;
    std::string Name;
    int TotalDistance;
};
}

#endif // RACE_COURSE_HPP