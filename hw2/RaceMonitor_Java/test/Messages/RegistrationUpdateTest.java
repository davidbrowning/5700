package Messages;

import Racedata.AthleteRaceStatus;
import org.junit.Test;

import java.time.LocalDateTime;

import static org.junit.Assert.*;

public class RegistrationUpdateTest {
    @Test
    public void create() throws Exception {
        RegistrationUpdate rUpdate = (RegistrationUpdate) AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F,16");
        assertNotNull(rUpdate);

        assertEquals(AthleteRaceStatus.Registered, rUpdate.getUpdateType());
        assertEquals(14, rUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,7, 2, 5), rUpdate.getTimestamp());
        assertEquals("Jane", rUpdate.getFirstName());
        assertEquals("Jones", rUpdate.getLastName());
        assertEquals("F", rUpdate.getGender());
        assertEquals(16, rUpdate.getAge());

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Registered,14");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Registered");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F,16,bad");
            fail("Exception expected");
        } catch (Exception e) {}

    }

    @Test
    public void testToString() throws Exception {
        RegistrationUpdate rUpdate = new RegistrationUpdate();
        rUpdate.setBibNumber(14);
        rUpdate.setTimestamp(LocalDateTime.of(2017,8,15,7,2,5));
        rUpdate.setFirstName("Jane");
        rUpdate.setLastName("Jones");
        rUpdate.setGender("F");
        rUpdate.setAge(16);

        assertEquals("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F,16", rUpdate.toString());
    }

    @Test
    public void testSettersAndGetters() throws Exception {
        RegistrationUpdate rUpdate = new RegistrationUpdate();
        rUpdate.setBibNumber(14);
        rUpdate.setTimestamp(LocalDateTime.of(2017,8,15,7,2,5));
        rUpdate.setFirstName("Jane");
        rUpdate.setLastName("Jones");
        rUpdate.setGender("F");
        rUpdate.setAge(16);

        assertEquals(AthleteRaceStatus.Registered, rUpdate.getUpdateType());
        assertEquals(14, rUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,7, 2, 5), rUpdate.getTimestamp());
        assertEquals("Jane", rUpdate.getFirstName());
        assertEquals("Jones", rUpdate.getLastName());
        assertEquals("F", rUpdate.getGender());
        assertEquals(16, rUpdate.getAge());
    }
}