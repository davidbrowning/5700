#include <gtest/gtest.h>

#include "Messages/DidNotStartUpdate.hpp"

class DidNotStartUpdateTest : public ::testing::Test
{
  protected:
    virtual void SetUp()
    {
        message = RaceData::Messages::DidNotStartUpdate({"DidNotStart", "7", "8/17/2017 7:00:00 AM"});
    }

    RaceData::Messages::DidNotStartUpdate message;
};

TEST_F(DidNotStartUpdateTest, ToStringTest)
{
    auto actual = message.ToString();
    std::string expected = "DidNotStart,7,08/17/2017 07:00:00 AM";
    EXPECT_EQ(expected, actual);
}

TEST_F(DidNotStartUpdateTest, ThrowsOnBadStatus)
{
    EXPECT_THROW(RaceData::Messages::DidNotStartUpdate({"Finished", "7", "8/12/2017 7:00:00 AM"}), std::runtime_error);
}

TEST_F(DidNotStartUpdateTest, ThrowsOnBadDate)
{
    EXPECT_THROW(RaceData::Messages::DidNotStartUpdate({"DidNotStart", "7", "12/2017/8 7:00:00 AM"}), std::runtime_error);
}

TEST_F(DidNotStartUpdateTest, ExceptsLeadingZeros)
{
    EXPECT_NO_THROW(RaceData::Messages::DidNotStartUpdate({"DidNotStart", "7", "08/12/2017 07:00:00 AM"}));
}

TEST_F(DidNotStartUpdateTest, ExceptsPM)
{
    EXPECT_NO_THROW(RaceData::Messages::DidNotStartUpdate({"DidNotStart", "7", "08/12/2017 07:00:00 PM"}));
}

TEST_F(DidNotStartUpdateTest, ThrowsOnWrongProperties)
{
    EXPECT_THROW(RaceData::Messages::DidNotStartUpdate({"DidNotStart", "7", "8/12/2017 7:00:00 AM", "8"}), std::runtime_error);
}