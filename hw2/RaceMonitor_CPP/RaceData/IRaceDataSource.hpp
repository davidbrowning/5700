#ifndef I_RACE_DATA_SOURCE_HPP
#define I_RACE_DATA_SOURCE_HPP

namespace RaceData
{
class IRaceDataSource
{
public:
  virtual void Start() = 0;
  virtual void Stop() = 0;
  virtual void Pause() = 0;
  virtual void Resume() = 0;
  virtual bool IsFinished() = 0;
};
}

#endif // I_DATA_SOURCE_HPP