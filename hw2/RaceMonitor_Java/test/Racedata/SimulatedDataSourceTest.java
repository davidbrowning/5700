package Racedata;

import Messages.AthleteUpdate;
import org.junit.Test;

import java.io.FileWriter;
import java.util.ArrayList;

import static org.junit.Assert.*;

public class SimulatedDataSourceTest {
    @Test
    public void testEverything() throws Exception {
        SimulatedDataSource ds = new SimulatedDataSource();

        FileWriter fileWriter = new FileWriter("SimulatedDataSourceTest.csv");
        fileWriter.write("Registered,1,8/15/2017 7:00:00 AM,FN_F_1,LN_1,F,16\n" +
                "Registered,2,8/15/2017 7:00:00 AM,FN_M_2,LN_2,M,56\n" +
                "---\n" +
                "Started,1,8/15/2017 7:02:00 AM,8/15/2017 7:02:00 AM\n" +
                "---\n" +
                "OnCourse,1,8/15/2017 7:02:30 AM,276.098203867211\n" +
                "Started,2,8/15/2017 7:02:30 AM,8/15/2017 7:02:30 AM");
        fileWriter.close();

        ds.setInputFilename("SimulatedDataSourceTest.csv");

        TestHandler dataHandler = new TestHandler();
        ds.setHandler(dataHandler);

        ds.Start();

        // Wait for something about 1/2 second
        Thread.sleep(500);

        // Two messages should have come in
        assertEquals(2, dataHandler.NumberRecieved());
        assertEquals(AthleteRaceStatus.Registered, dataHandler.get(0).getUpdateType());
        assertEquals(AthleteRaceStatus.Registered, dataHandler.get(1).getUpdateType());

        // Wait for something less than a second
        Thread.sleep(1000);

        // Another message should have some in
        assertEquals(3, dataHandler.NumberRecieved());
        assertEquals(AthleteRaceStatus.Started, dataHandler.get(2).getUpdateType());

        // Wait for something less than a second
        Thread.sleep(1000);

        // Another message should have some in
        assertEquals(5, dataHandler.NumberRecieved());
        assertEquals(AthleteRaceStatus.OnCourse, dataHandler.get(3).getUpdateType());
        assertEquals(AthleteRaceStatus.Started, dataHandler.get(4).getUpdateType());

        ds.Stop();
        Thread.sleep(1000);
        assertEquals(5, dataHandler.NumberRecieved());

    }

    class TestHandler implements IAthleteUpdateHandler
    {
        private ArrayList<AthleteUpdate> receivedMessages = new ArrayList<>(100);

        @Override
        public void ProcessUpdate(AthleteUpdate updateMessage) {
            receivedMessages.add(updateMessage);
        }

        public int NumberRecieved() { return receivedMessages.size(); }
        public AthleteUpdate get(int index) { return receivedMessages.get(index); }
    }

}