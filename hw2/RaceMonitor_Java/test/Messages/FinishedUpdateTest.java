package Messages;

import Racedata.AthleteRaceStatus;
import org.junit.Test;

import java.time.LocalDateTime;

import static org.junit.Assert.*;

public class FinishedUpdateTest {
    @Test
    public void create() throws Exception {
        FinishedUpdate fUpdate = (FinishedUpdate) AthleteUpdate.Create("Finished,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM");
        assertNotNull(fUpdate);

        assertEquals(AthleteRaceStatus.Finished, fUpdate.getUpdateType());
        assertEquals(84, fUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,14, 34, 0), fUpdate.getTimestamp());
        assertEquals(LocalDateTime.of(2017,8,15,14, 33, 45), fUpdate.getOfficialEndTime());

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Finished,84,8/15/2017 2:34:00 PM");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Finished,84");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Finished");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Finished,84,bad,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM");
            fail("Exception expected");
        } catch (Exception e) {}

    }

    @Test
    public void testToString() throws Exception {
        FinishedUpdate fUpdate = new FinishedUpdate();
        fUpdate.setBibNumber(84);
        fUpdate.setTimestamp(LocalDateTime.of(2017,8,15,14,34,0));
        fUpdate.setOfficialEndTime(LocalDateTime.of(2017, 8, 15, 14,33,45));

        assertEquals("Finished,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM", fUpdate.toString());
    }

    @Test
    public void testSettersAndGetters() throws Exception {
        FinishedUpdate fUpdate = new FinishedUpdate();
        fUpdate.setBibNumber(84);
        fUpdate.setTimestamp(LocalDateTime.of(2017,8,15,14,34,0));
        fUpdate.setOfficialEndTime(LocalDateTime.of(2017, 8, 15, 14,33,45));

        assertEquals(AthleteRaceStatus.Finished, fUpdate.getUpdateType());
        assertEquals(84, fUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,14, 34, 0), fUpdate.getTimestamp());
        assertEquals(LocalDateTime.of(2017,8,15,14, 33, 45), fUpdate.getOfficialEndTime());
    }

}