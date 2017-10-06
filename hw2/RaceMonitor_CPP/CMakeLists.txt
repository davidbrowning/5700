cmake_minimum_required(VERSION 3.0.2)
project(RaceData)

# A function download and unpack an external project
function(download configFile dest title)
  message("Downloading and unpacking ${title} using config at ${configFile} with destination ${dest}")
  configure_file(${configFile} ${dest}/CMakeLists.txt)
  execute_process(COMMAND ${CMAKE_COMMAND} -G "${CMAKE_GENERATOR}" .
    RESULT_VARIABLE result
    WORKING_DIRECTORY ${CMAKE_BINARY_DIR}/${dest} )
  if(result)
    message(FATAL_ERROR "CMake step for ${title} failed: ${result}")
  endif()
  execute_process(COMMAND ${CMAKE_COMMAND} --build .
    RESULT_VARIABLE result
    WORKING_DIRECTORY ${CMAKE_BINARY_DIR}/${dest} )
  if(result)
    message(FATAL_ERROR "Build step for ${title} failed: ${result}")
  endif()
endfunction(download)

include(CheckIncludeFileCXX)

# Download and unpack googletest at configure time
download(cmake_external_projects/CMakeLists.txt.gtest.in googletest-download googletest)

# Prevent overriding the parent project's compiler/linker
# settings on Windows
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)

# Add googletest directly to our build. This defines
# the gtest and gtest_main targets.
add_subdirectory(${CMAKE_BINARY_DIR}/googletest-src
                 ${CMAKE_BINARY_DIR}/googletest-build)

# Set up gmock includes
target_include_directories(gmock_main SYSTEM BEFORE INTERFACE
  "${gtest_SOURCE_DIR}/include" "${gmock_SOURCE_DIR}/include")

enable_testing()
include_directories(
    ${CMAKE_CURRENT_BINARY_DIR}
    ${CMAKE_CURRENT_SOURCE_DIR}
    ${CMAKE_CURRENT_SOURCE_DIR}/RaceData
    ${CMAKE_CURRENT_SOURCE_DIR}/RaceDataTesting
)

set(EXTRA_COMPILE_FLAGS "-std=c++14 -Wall -pedantic-errors -pthread")
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} ${EXTRA_COMPILE_FLAGS}")

add_executable(Example example.cpp)

# Setup testing srcs
add_subdirectory(RaceDataTesting)

message(STATUS "Testing src: ${testing_export_srcs}")

# Create 'RaceData_Test' and link
add_executable(RaceData_Test ${testing_export_srcs})
target_link_libraries(RaceData_Test gmock_main)

add_test(NAME UnitTests COMMAND RaceData_Test)