# RaceMonitor_CPP
*A C++14 port of Dr. Clyde's C# Race Data Simulator -- by Dustin E Homan*
## Summary
This package is a header's only library. Just add the `RaceData` directory to your include paths. There is a CMake build definition for the test and example. Simply:
```bash
linus:~/path/to/project$ mkdir build && cd build
linus:~/.../build$ cmake ../
linus:~/.../build$ make
linus:~/.../build$ make test
#                  or vvvv for full gtest output
linus:~/.../build$ ./RaceData_Test
```
```bash
linus:~/.../build$ ./Example
```
CMake will download and install GTest/GMock, so you don't need to worry about installing it. Also included is an example (example.cpp) showing how to include and use the `SimulatedDataSource` class. In the example, the `IAthleteUpdateHandler` prints the update message to `stdout`.

## Deviations From Original Work
1. Moved Simple Factory from the `AthleteUpdate` class to a separate "Factory" class. This was done to handle circular dependancy issues.
2. Additional Methods on the `IRaceDataSource`:
    * `IsFinished()` -- has the simulation thread finished reading all data
    * `Pause()` -- Stop the simulation thread from reading in more lines, but not exit the read loop
    * `Resume()` -- Tell a simulation thread to resume reading lines

## Windows
I had issues getting `std::get_time` to follow the POSIX date formatting standards. Namely, `std::get_time` was requiring a leading zero for `%m`, `%d`, and `%I`. I am using `strptime()` for unix systems. For Windows, there is a conditional macro that will use `std::get_time` (as `strptime` is unix only). If you run into the leading zero issue please replace `std::get_time` with something that works.
<br>
<br>
<br>
<br>
<br>
*Last Updated: Oct 5, 2017*