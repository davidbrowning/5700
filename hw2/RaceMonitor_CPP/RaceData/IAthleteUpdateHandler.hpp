#ifndef I_ATHLETE_UPDATE_HANDLER_HPP
#define I_ATHLETE_UPDATE_HANDLER_HPP

// Package Headers
#include "Messages/AthleteUpdate.hpp"

// STD Libs
#include <memory>

namespace RaceData
{
class IAthleteUpdateHandler
{
public:
  virtual void ProcessUpdate(std::shared_ptr<Messages::AthleteUpdate> updateMessage) = 0;
};
}

#endif // I_ATHLETE_UPDATE_HANDLER_HPP