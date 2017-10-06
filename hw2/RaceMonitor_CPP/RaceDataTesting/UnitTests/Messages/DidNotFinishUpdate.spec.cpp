#include <gtest/gtest.h>

#include <stdexcept>
#include <string>
#include <vector>

#include "Messages/DidNotFinishUpdate.hpp"

class DidNotFinishUpdateTest : public ::testing::Test
{
  protected:
    virtual void SetUp()
    {
        message = RaceData::Messages::DidNotFinishUpdate({"DidNotFinish", "7", "8/17/2017 7:00:00 AM"});
    }

    RaceData::Messages::DidNotFinishUpdate message;
};

TEST_F(DidNotFinishUpdateTest, ToStringTest)
{
    auto actual = message.ToString();
    std::string expected = "DidNotFinish,7,08/17/2017 07:00:00 AM";
    EXPECT_EQ(expected, actual);
}

TEST_F(DidNotFinishUpdateTest, ThrowsOnBadStatus)
{
    EXPECT_THROW(RaceData::Messages::DidNotFinishUpdate({"Finished", "7", "8/12/2017 7:00:00 AM"}), std::runtime_error);
}

TEST_F(DidNotFinishUpdateTest, ThrowsOnBadDate)
{
    EXPECT_THROW(RaceData::Messages::DidNotFinishUpdate({"DidNotFinish", "7", "12/2017/8 7:00:00 AM"}), std::runtime_error);
}

TEST_F(DidNotFinishUpdateTest, ExceptsLeadingZeros)
{
    EXPECT_NO_THROW(RaceData::Messages::DidNotFinishUpdate({"DidNotFinish", "7", "08/12/2017 07:00:00 AM"}));
}

TEST_F(DidNotFinishUpdateTest, ExceptsPM)
{
    EXPECT_NO_THROW(RaceData::Messages::DidNotFinishUpdate({"DidNotFinish", "7", "08/12/2017 07:00:00 PM"}));
}

TEST_F(DidNotFinishUpdateTest, ThrowsOnWrongProperties)
{
    EXPECT_THROW(RaceData::Messages::DidNotFinishUpdate({"DidNotFinish", "7", "8/12/2017 7:00:00 AM", "8"}), std::runtime_error);
}