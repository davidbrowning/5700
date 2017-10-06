#ifndef SIMULATED_DATASOURCE_HPP
#define SIMULATED_DATASOURCE_HPP

// Package Headers
#include "IAthleteUpdateHandler.hpp"
#include "IRaceDataSource.hpp"
#include "Messages/MessageFactory.hpp"

// STD Libs
#include <atomic>
#include <chrono>
#include <fstream>
#include <memory>
#include <string>
#include <thread>

namespace RaceData
{
class SimulatedDataSource : public IRaceDataSource
{
  public:
    std::string InputFilename() { return _inputFilename; }
    void InputFilename(std::string filename) { _inputFilename = filename; }

    std::shared_ptr<IAthleteUpdateHandler> Handler() { return _handler; }
    void Handler(std::shared_ptr<IAthleteUpdateHandler> handler) { _handler = handler; }

    int SleepTimeForSimulatedSecond() { return _sleepTime; }
    void SleepTimeForSimulatedSecond(int sleepTime) { _sleepTime = sleepTime; }

    bool IsFinished() { return _finished.load(); }

    void Start()
    {
        // Ensure we have a file to read
        if (_inputFilename.empty())
            throw std::runtime_error("Before starting a SimulatedDataSource, you must set InputFilename to path of the race data");

        // Ensure we have something to handle update messages
        if (_handler == nullptr)
            throw std::runtime_error("You must set Handler to an object in your software that can process AthleteUpdate messages before starting a simulation");

        // Open the file and init flags
        _reader.open(_inputFilename, std::ifstream::in);
        _keepGoing = true;
        _finished = false;
        _paused = false;

        // Spin up a new thread to read
        // the file line by line.
        // NOTE: "---" corresponds to a "second"
        std::thread([&]() {
            while (_keepGoing && _reader.good())
            {
                SimulateOneSecondOfData();
                std::this_thread::sleep_for(std::chrono::milliseconds(_sleepTime));
            }
            _finished = true;
        }).detach();
    }

    void Stop()
    {
        _keepGoing = false;
    }

    void Pause()
    {
        _paused = true;
    }

    void Resume()
    {
        _paused = false;
    }

  private:
    std::string _inputFilename;
    std::shared_ptr<IAthleteUpdateHandler> _handler;
    int _sleepTime = 1000;
    std::ifstream _reader;
    std::atomic<bool> _keepGoing;
    std::atomic<bool> _finished;
    std::atomic<bool> _paused;

    // Read each line of the input file
    // that is not a "---" and parse it
    // into an update message
    void SimulateOneSecondOfData()
    {
        if (_paused)
            return;
        std::string line;
        std::getline(_reader, line);
        while (line != "---" && _reader.good())
        {
            auto message = Messages::MessageFactory::Create(line);
            _handler->ProcessUpdate(message);
            std::getline(_reader, line);
        }
    }
};
}

#endif // SIMULATED_DATASOURCE_HPP