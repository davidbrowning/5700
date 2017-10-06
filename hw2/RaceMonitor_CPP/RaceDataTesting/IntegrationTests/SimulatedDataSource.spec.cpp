#include <gtest/gtest.h>
#include <gmock/gmock.h>

// Package Headers
#include "SimulatedDataSource.hpp"
#include "IAthleteUpdateHandler.hpp"
#include "Messages/AthleteUpdate.hpp"

// STD Libs
#include <memory>

class MockHandler : public RaceData::IAthleteUpdateHandler
{
  public:
    MOCK_METHOD1(ProcessUpdate, void(std::shared_ptr<RaceData::Messages::AthleteUpdate> updateMessage));
};

class SimulatedDataSourceTest : public ::testing::Test
{
  protected:
    virtual void SetUp()
    {
        dataSource.InputFilename("Data/test.csv");
        handler = std::make_shared<MockHandler>();
        dataSource.Handler(handler);
        dataSource.SleepTimeForSimulatedSecond(1);
    }

    RaceData::SimulatedDataSource dataSource;
    std::shared_ptr<MockHandler> handler;
};

TEST_F(SimulatedDataSourceTest, GeneratesUpdateMessagesFromSimData)
{
    // Expect only 6 calls as there is only 6 data points
    //  in the test data.
    EXPECT_CALL(*handler, ProcessUpdate(::testing::_))
        .Times(6);

    dataSource.Start();
    while (!dataSource.IsFinished())
    {
        // Wait...
    }
    dataSource.Stop();
}
