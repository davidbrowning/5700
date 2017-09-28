package Messages;

import Racedata.AthleteRaceStatus;
import org.junit.Test;

import java.rmi.server.ExportException;
import java.time.LocalDateTime;

import static org.junit.Assert.*;

public class DidNotFinishUpdateTest {
    @Test
    public void testCreate() throws Exception {
        DidNotFinishUpdate dnfUpdate = (DidNotFinishUpdate) AthleteUpdate.Create("DidNotFinish,45,8/15/2017 10:52:00 AM");
        assertNotNull(dnfUpdate);

        assertEquals(AthleteRaceStatus.DidNotFinish, dnfUpdate.getUpdateType());
        assertEquals(45, dnfUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15, 10, 52, 0), dnfUpdate.getTimestamp());

        try {
            AthleteUpdate msg = AthleteUpdate.Create("DidNotFinish,45");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("DidNotFinish");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("DidNotFinish,45,bad,8/15/2017 10:52:00 AM");
            fail("Exception expected");
        } catch (Exception e) {}
    }

    @Test
    public void testToString() throws Exception {
        DidNotFinishUpdate dnfUpdate = new DidNotFinishUpdate();
        dnfUpdate.setBibNumber(45);
        dnfUpdate.setTimestamp(LocalDateTime.of(2017, 8, 15, 10, 52, 0));
        assertEquals("DidNotFinish,45,8/15/2017 10:52:00 AM", dnfUpdate.toString());
    }

    @Test
    public void testSettersAndGetters() throws Exception {
        DidNotFinishUpdate dnfUpdate = new DidNotFinishUpdate();
        dnfUpdate.setBibNumber(45);
        dnfUpdate.setTimestamp(LocalDateTime.of(2017, 8, 15, 10, 52, 0));

        assertEquals(AthleteRaceStatus.DidNotFinish, dnfUpdate.getUpdateType());
        assertEquals(45, dnfUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,10, 52, 0), dnfUpdate.getTimestamp());
    }
}