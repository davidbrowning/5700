#include <gtest/gtest.h>

#include "Messages/FinishedUpdate.hpp"

class FinishedUpdateTest : public ::testing::Test
{
  protected:
    virtual void SetUp()
    {
        message = RaceData::Messages::FinishedUpdate({"Finished", "7", "8/17/2017 8:00:00 PM", "8/17/2017 7:58:01 PM"});
    }

    RaceData::Messages::FinishedUpdate message;
};

TEST_F(FinishedUpdateTest, ToStringTest)
{
    auto actual = message.ToString();
    std::string expected = "Finished,7,08/17/2017 08:00:00 PM,08/17/2017 07:58:01 PM";
    EXPECT_EQ(expected, actual);
}

TEST_F(FinishedUpdateTest, ThrowsOnBadStatus)
{
    EXPECT_THROW(RaceData::Messages::FinishedUpdate({"OnCourse", "7", "8/12/2017 7:00:00 AM", "8/17/2017 7:58:01 PM"}), std::runtime_error);
}

TEST_F(FinishedUpdateTest, ThrowsOnBadDate)
{
    EXPECT_THROW(RaceData::Messages::FinishedUpdate({"Finished", "7", "12/2017/8 7:00:00 AM", "8/17/2017 7:58:01 PM"}), std::runtime_error);
}

TEST_F(FinishedUpdateTest, ExceptsLeadingZeros)
{
    EXPECT_NO_THROW(RaceData::Messages::FinishedUpdate({"Finished", "7", "08/12/2017 07:00:00 AM", "08/17/2017 07:58:01 PM"}));
}

TEST_F(FinishedUpdateTest, ThrowsOnWrongProperties)
{
    EXPECT_THROW(RaceData::Messages::FinishedUpdate({"Finished", "7", "8/12/2017 7:00:00 AM", "8/17/2017 7:58:01 PM", "8"}), std::runtime_error);
}