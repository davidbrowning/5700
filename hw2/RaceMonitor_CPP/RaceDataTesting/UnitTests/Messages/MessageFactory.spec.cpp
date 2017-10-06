#include <gtest/gtest.h>

#include <memory>
#include <string>

#include "Messages/MessageFactory.hpp"

TEST(MessageFactoryTest, CreatesRegisterMessage)
{
    std::string dataPoint = "Registered,14,8/15/2017 7:02:00 AM,FN_F_14,LN_14,F,16";
    auto updateMessage = RaceData::Messages::MessageFactory::Create(dataPoint);
    EXPECT_NE(nullptr, std::dynamic_pointer_cast<RaceData::Messages::RegistrationUpdate>(updateMessage));
}

TEST(MessageFactoryTest, CreatesDidNotStartMessage)
{
    std::string dataPoint = "DidNotStart,79,8/15/2017 8:14:00 AM";
    auto updateMessage = RaceData::Messages::MessageFactory::Create(dataPoint);
    EXPECT_NE(nullptr, std::dynamic_pointer_cast<RaceData::Messages::DidNotStartUpdate>(updateMessage));
}

TEST(MessageFactoryTest, CreatesStartedMessage)
{
    std::string dataPoint = "Started,12,8/15/2017 10:22:00 AM,8/15/2017 10:22:00 AM";
    auto updateMessage = RaceData::Messages::MessageFactory::Create(dataPoint);
    EXPECT_NE(nullptr, std::dynamic_pointer_cast<RaceData::Messages::StartedUpdate>(updateMessage));
}

TEST(MessageFactoryTest, CreatesLocationMessage)
{
    std::string dataPoint = "OnCourse,12,8/15/2017 10:24:00 AM,1106.4027430767";
    auto updateMessage = RaceData::Messages::MessageFactory::Create(dataPoint);
    EXPECT_NE(nullptr, std::dynamic_pointer_cast<RaceData::Messages::LocationUpdate>(updateMessage));
}

TEST(MessageFactoryTest, CreatesDidNotFinishMessage)
{
    std::string dataPoint = "DidNotFinish,45,8/15/2017 10:52:00 AM";
    auto updateMessage = RaceData::Messages::MessageFactory::Create(dataPoint);
    EXPECT_NE(nullptr, std::dynamic_pointer_cast<RaceData::Messages::DidNotFinishUpdate>(updateMessage));
}

TEST(MessageFactoryTest, CreatesFinishMessage)
{
    std::string dataPoint = "Finished,84,8/15/2017 2:34:00 PM,8/15/2017 2:34:00 PM";
    auto updateMessage = RaceData::Messages::MessageFactory::Create(dataPoint);
    EXPECT_NE(nullptr, std::dynamic_pointer_cast<RaceData::Messages::FinishedUpdate>(updateMessage));
}