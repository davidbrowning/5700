package Messages;

import Racedata.AthleteRaceStatus;
import org.junit.Test;

import java.time.LocalDateTime;

import static org.junit.Assert.*;

public class DidNotStartUpdateTest {
    @Test
    public void create() throws Exception {
        DidNotStartUpdate dnsUpdate = (DidNotStartUpdate) AthleteUpdate.Create("DidNotStart,35,8/15/2017 8:51:00 AM");

        assertEquals(AthleteRaceStatus.DidNotStart, dnsUpdate.getUpdateType());
        assertEquals(35, dnsUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017, 8, 15, 8, 51, 0), dnsUpdate.getTimestamp());

        try {
            AthleteUpdate msg = AthleteUpdate.Create("DidNotStart,35");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("DidNotStart");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("DidNotStart,35,bad,8/15/2017 8:51:00 AM");
            fail("Exception expected");
        } catch (Exception e) {}
    }

    @Test
    public void testToString() throws Exception {
        DidNotStartUpdate dnsUpdate = new DidNotStartUpdate();
        dnsUpdate.setBibNumber(35);
        dnsUpdate.setTimestamp(LocalDateTime.of(2017, 8, 15, 8 , 51, 0));

        assertEquals("DidNotStart,35,8/15/2017 8:51:00 AM", dnsUpdate.toString());
    }

    @Test
    public void testSettersAndGetters() throws Exception {
        DidNotStartUpdate dnsUpdate = new DidNotStartUpdate();
        dnsUpdate.setBibNumber(35);
        dnsUpdate.setTimestamp(LocalDateTime.of(2017, 8, 15, 8 , 51, 0));

        assertEquals(AthleteRaceStatus.DidNotStart, dnsUpdate.getUpdateType());
        assertEquals(35, dnsUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017, 8, 15, 8, 51, 0), dnsUpdate.getTimestamp());
    }
}