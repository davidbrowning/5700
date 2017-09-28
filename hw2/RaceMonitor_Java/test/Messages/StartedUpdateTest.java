package Messages;

import Racedata.AthleteRaceStatus;
import org.junit.Test;

import java.time.LocalDateTime;

import static org.junit.Assert.*;

public class StartedUpdateTest {
    @Test
    public void create() throws Exception {
        StartedUpdate sUpdate = (StartedUpdate) AthleteUpdate.Create("Started,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM");
        assertNotNull(sUpdate);

        assertEquals(AthleteRaceStatus.Started, sUpdate.getUpdateType());
        assertEquals(84, sUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,14, 34, 0), sUpdate.getTimestamp());
        assertEquals(LocalDateTime.of(2017,8,15,14, 33, 45), sUpdate.getOfficialStartTime());

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Started,84,8/15/2017 2:34:00 PM");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Started,84");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Started");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Finished,84,bad,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM");
            fail("Exception expected");
        } catch (Exception e) {}

    }

    @Test
    public void testToString() throws Exception {
        StartedUpdate sUpdate = new StartedUpdate();
        sUpdate.setBibNumber(84);
        sUpdate.setTimestamp(LocalDateTime.of(2017,8,15,14,34,0));
        sUpdate.setOfficialStartTime(LocalDateTime.of(2017, 8, 15, 14,33,45));

        assertEquals("Started,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM", sUpdate.toString());
    }

    @Test
    public void testSettersAndGetters() throws Exception {
        StartedUpdate sUpdate = new StartedUpdate();
        sUpdate.setBibNumber(84);
        sUpdate.setTimestamp(LocalDateTime.of(2017,8,15,14,34,0));
        sUpdate.setOfficialStartTime(LocalDateTime.of(2017, 8, 15, 14,33,45));

        assertEquals(AthleteRaceStatus.Started, sUpdate.getUpdateType());
        assertEquals(84, sUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,14, 34, 0), sUpdate.getTimestamp());
        assertEquals(LocalDateTime.of(2017,8,15,14, 33, 45), sUpdate.getOfficialStartTime());
    }

}