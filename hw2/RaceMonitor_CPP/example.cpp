#include <cstdlib>
#include <iostream>
#include <memory>
#include <thread>

#include "RaceData/SimulatedDataSource.hpp"
#include "RaceData/IAthleteUpdateHandler.hpp"

// A simple Observer to print out the received message to the console
class Handler : public RaceData::IAthleteUpdateHandler
{
  public:
    virtual void ProcessUpdate(std::shared_ptr<RaceData::Messages::AthleteUpdate> updateMessage)
    {
        switch (updateMessage->UpdateType)
        {
        case RaceData::AthleteRaceStatus::DidNotFinish:
            std::cout << "DidNotFinishUpdate: " << updateMessage->ToString() << std::endl;
            break;
        case RaceData::AthleteRaceStatus::DidNotStart:
            std::cout << "DidNotStartUpdate: " << updateMessage->ToString() << std::endl;
            break;
        case RaceData::AthleteRaceStatus::Finished:
            std::cout << "FinishedUpdate: " << updateMessage->ToString() << std::endl;
            break;
        case RaceData::AthleteRaceStatus::OnCourse:
            std::cout << "LocationUpdate: " << updateMessage->ToString() << std::endl;
            break;
        case RaceData::AthleteRaceStatus::Registered:
            std::cout << "RegistrationUpdate: " << updateMessage->ToString() << std::endl;
            break;
        case RaceData::AthleteRaceStatus::Started:
            std::cout << "StartedUpdate: " << updateMessage->ToString() << std::endl;
            break;
        }
    }
};

int main()
{
    const int SLEEP_FOR = 1000;

    // 1. Instantiate the SimulatedDataSource and Handler
    RaceData::SimulatedDataSource dataSource;
    auto handler = std::make_shared<Handler>();

    // 2. Set SimulatedDataSource options
    //   * InputFilename and Handler are required
    dataSource.InputFilename("../../SimulationData/Short Race Simulation-01.csv");
    dataSource.Handler(handler);
    dataSource.SleepTimeForSimulatedSecond(SLEEP_FOR);

    // Start the simulation (runs on separate thread)
    dataSource.Start();

    // Wait for the simulation to finish
    //   NOTE: Print out "Waiting..." every "second"
    while (!dataSource.IsFinished())
    {
        std::cout << "Waiting..." << std::endl;
        std::this_thread::sleep_for(std::chrono::milliseconds(SLEEP_FOR));
    }

    // Stop the simulation thread if it is not stopped
    dataSource.Stop();

    return EXIT_SUCCESS;
}