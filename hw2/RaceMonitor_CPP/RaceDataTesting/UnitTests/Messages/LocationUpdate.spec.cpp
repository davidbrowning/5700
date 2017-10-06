#include <gtest/gtest.h>

#include "Messages/LocationUpdate.hpp"

class LocationUpdateTest : public ::testing::Test
{
  protected:
    virtual void SetUp()
    {
        message = RaceData::Messages::LocationUpdate({"OnCourse", "7", "8/12/2017 7:00:00 AM", "2.3434034"});
    }

    RaceData::Messages::LocationUpdate message;
};

TEST_F(LocationUpdateTest, ToStringTest)
{
    auto actual = message.ToString();
    std::string expected = "OnCourse,7,08/12/2017 07:00:00 AM,2.3434034";
    EXPECT_EQ(expected, actual);
}

TEST_F(LocationUpdateTest, ThrowsOnBadStatus)
{
    EXPECT_THROW(RaceData::Messages::LocationUpdate({"Location", "7", "8/12/2017 7:00:00 AM", "2.3434034"}), std::runtime_error);
}

TEST_F(LocationUpdateTest, ThrowsOnBadDate)
{
    EXPECT_THROW(RaceData::Messages::LocationUpdate({"OnCourse", "7", "12/2017/8 7:00:00 AM", "2.3434034"}), std::runtime_error);
}

TEST_F(LocationUpdateTest, ExceptsLeadingZeros)
{
    EXPECT_NO_THROW(RaceData::Messages::LocationUpdate({"OnCourse", "7", "08/12/2017 07:00:00 AM", "2.3434034"}));
}

TEST_F(LocationUpdateTest, ExceptsPM)
{
    EXPECT_NO_THROW(RaceData::Messages::LocationUpdate({"OnCourse", "7", "08/12/2017 07:00:00 PM", "2.3434034"}));
}

TEST_F(LocationUpdateTest, ThrowsOnWrongProperties)
{
    EXPECT_THROW(RaceData::Messages::LocationUpdate({"OnCourse", "7", "8/12/2017 7:00:00 AM", "8", "2.3434034"}), std::runtime_error);
}