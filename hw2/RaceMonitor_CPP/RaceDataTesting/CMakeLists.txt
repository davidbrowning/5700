set(test_srcs
main.cpp
)
source_group("RaceDataTesting" FILES ${test_srcs})

set(unittests
UnitTests/AthleteRaceStatus.spec.cpp
)
source_group("RaceDataTesting/UnitTests" FILES ${unittests})
list(APPEND test_srcs ${unittests})

set(messages
UnitTests/Messages/MessageFactory.spec.cpp
UnitTests/Messages/DidNotFinishUpdate.spec.cpp
UnitTests/Messages/DidNotStartUpdate.spec.cpp
UnitTests/Messages/FinishedUpdate.spec.cpp
UnitTests/Messages/LocationUpdate.spec.cpp
UnitTests/Messages/RegistrationUpdate.spec.cpp
UnitTests/Messages/StartedUpdate.spec.cpp
)
source_group("RaceDataTesting/UnitTests/Messages" FILES ${messages})
list(APPEND test_srcs ${messages})

set(integrationtests
IntegrationTests/SimulatedDataSource.spec.cpp
)
source_group("RaceDataTesting/IntegrationTests" FILES ${integrationtests})
list(APPEND test_srcs ${integrationtests})

# Copy test data to build dir
configure_file(${CMAKE_CURRENT_SOURCE_DIR}/IntegrationTests/Data/test.csv ${CMAKE_CURRENT_BINARY_DIR}/../Data/test.csv)

# Append subdir path
set(path-prefix "RaceDataTesting")
set(listVar "")
foreach(f ${test_srcs})
list(APPEND listVar "${path-prefix}/${f}")
endforeach(f)
set(testing_export_srcs ${listVar} PARENT_SCOPE)