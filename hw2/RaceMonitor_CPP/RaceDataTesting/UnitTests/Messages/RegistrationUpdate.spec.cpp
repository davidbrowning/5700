#include <gtest/gtest.h>

#include "Messages/RegistrationUpdate.hpp"

class RegistrationUpdateTest : public ::testing::Test
{
  protected:
    virtual void SetUp()
    {
        message = RaceData::Messages::RegistrationUpdate({"Registered", "7", "8/12/2017 7:00:00 AM", "FN_F_4", "LN_4", "F", "39"});
    }

    RaceData::Messages::RegistrationUpdate message;
};

TEST_F(RegistrationUpdateTest, ToStringTest)
{
    auto actual = message.ToString();
    std::string expected = "Registered,7,08/12/2017 07:00:00 AM,FN_F_4,LN_4,F,39";
    EXPECT_EQ(expected, actual);
}

TEST_F(RegistrationUpdateTest, ThrowsOnBadStatus)
{
    EXPECT_THROW(RaceData::Messages::RegistrationUpdate({"Registration", "7", "8/12/2017 7:00:00 AM", "FN_F_4", "LN_4", "F", "39"}), std::runtime_error);
}

TEST_F(RegistrationUpdateTest, ThrowsOnBadDate)
{
    EXPECT_THROW(RaceData::Messages::RegistrationUpdate({"Registered", "7", "12/2017/8 7:00:00 AM", "FN_F_4", "LN_4", "F", "39"}), std::runtime_error);
}

TEST_F(RegistrationUpdateTest, ExceptsLeadingZeros)
{
    EXPECT_NO_THROW(RaceData::Messages::RegistrationUpdate({"Registered", "7", "08/12/2017 07:00:00 AM", "FN_F_4", "LN_4", "F", "39"}));
}

TEST_F(RegistrationUpdateTest, ExceptsPM)
{
    EXPECT_NO_THROW(RaceData::Messages::RegistrationUpdate({"Registered", "7", "08/12/2017 07:00:00 PM", "FN_F_4", "LN_4", "F", "39"}));
}

TEST_F(RegistrationUpdateTest, ThrowsOnWrongProperties)
{
    EXPECT_THROW(RaceData::Messages::RegistrationUpdate({"Registered", "7", "8/12/2017 7:00:00 AM", "FN_F_4", "LN_4", "F", "39", "2.3434034"}), std::runtime_error);
}