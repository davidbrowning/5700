#include <gtest/gtest.h>

#include <string>

#include "AthleteRaceStatus.hpp"

TEST(AthleteRaceStatusTest, RegisteredToFromString)
{
    std::string expected = "Registered";
    EXPECT_EQ(expected, RaceData::Utils::StatusToString(RaceData::AthleteRaceStatus::Registered));
    EXPECT_EQ(RaceData::AthleteRaceStatus::Registered, RaceData::Utils::StatusFromString(expected));
}

TEST(AthleteRaceStatusTest, DidNotFinishToFromString)
{
    std::string expected = "DidNotFinish";
    EXPECT_EQ(expected, RaceData::Utils::StatusToString(RaceData::AthleteRaceStatus::DidNotFinish));
    EXPECT_EQ(RaceData::AthleteRaceStatus::DidNotFinish, RaceData::Utils::StatusFromString(expected));
}

TEST(AthleteRaceStatusTest, DidNotStartToFromString)
{
    std::string expected = "DidNotStart";
    EXPECT_EQ(expected, RaceData::Utils::StatusToString(RaceData::AthleteRaceStatus::DidNotStart));
    EXPECT_EQ(RaceData::AthleteRaceStatus::DidNotStart, RaceData::Utils::StatusFromString(expected));
}

TEST(AthleteRaceStatusTest, StartedFromString)
{
    std::string expected = "Started";
    EXPECT_EQ(expected, RaceData::Utils::StatusToString(RaceData::AthleteRaceStatus::Started));
    EXPECT_EQ(RaceData::AthleteRaceStatus::Started, RaceData::Utils::StatusFromString(expected));
}

TEST(AthleteRaceStatusTest, FinishedFromString)
{
    std::string expected = "Finished";
    EXPECT_EQ(expected, RaceData::Utils::StatusToString(RaceData::AthleteRaceStatus::Finished));
    EXPECT_EQ(RaceData::AthleteRaceStatus::Finished, RaceData::Utils::StatusFromString(expected));
}

TEST(AthleteRaceStatusTest, OnCourseFromString)
{
    std::string expected = "OnCourse";
    EXPECT_EQ(expected, RaceData::Utils::StatusToString(RaceData::AthleteRaceStatus::OnCourse));
    EXPECT_EQ(RaceData::AthleteRaceStatus::OnCourse, RaceData::Utils::StatusFromString(expected));
}