package Messages;

import Racedata.AthleteRaceStatus;
import org.junit.Test;

import java.time.LocalDateTime;

import static org.junit.Assert.*;

public class LocationUpdateTest {
    @Test
    public void create() throws Exception {
        LocationUpdate locationUpdate = (LocationUpdate) AthleteUpdate.Create("OnCourse,47,8/15/2017 10:26:00 AM,680.067495971265");
        assertNotNull(locationUpdate);

        assertEquals(AthleteRaceStatus.OnCourse, locationUpdate.getUpdateType());
        assertEquals(47, locationUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,10, 26, 0), locationUpdate.getTimestamp());
        assertEquals(680.067495971265, locationUpdate.getLocationOnCourse(), 0.0001);

        try {
            AthleteUpdate msg = AthleteUpdate.Create("OnCourse,47,8/15/2017 10:26:00 AM");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("OnCourse,47");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("OnCourse");
            fail("Exception expected");
        } catch (Exception e) {}

        try {
            AthleteUpdate msg = AthleteUpdate.Create("OnCourse,47,8/15/2017 10:26:00 AM,680.067495971265,bad");
            fail("Exception expected");
        } catch (Exception e) {}

    }

    @Test
    public void testToString() throws Exception {
        LocationUpdate locationUpdate = new LocationUpdate();
        locationUpdate.setBibNumber(47);
        locationUpdate.setTimestamp(LocalDateTime.of(2017,8,15,10,26,0));
        locationUpdate.setLocationOnCourse(680.067495971265);

        assertEquals("OnCourse,47,8/15/2017 10:26:00 AM,680.067495971265", locationUpdate.toString());
    }


    @Test
    public void testSettersAndGetters() throws Exception {
        LocationUpdate locationUpdate = new LocationUpdate();
        locationUpdate.setBibNumber(47);
        locationUpdate.setTimestamp(LocalDateTime.of(2017,8,15,10,26,0));
        locationUpdate.setLocationOnCourse(680.067495971265);

        assertEquals(AthleteRaceStatus.OnCourse, locationUpdate.getUpdateType());
        assertEquals(47, locationUpdate.getBibNumber());
        assertEquals(LocalDateTime.of(2017,8,15,10, 26, 0), locationUpdate.getTimestamp());
        assertEquals(680.067495971265, locationUpdate.getLocationOnCourse(), 0.0001);
    }

}