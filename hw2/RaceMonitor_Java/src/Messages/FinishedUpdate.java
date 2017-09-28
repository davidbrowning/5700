/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Messages;

import Exceptions.ApplicationException;
import Racedata.AthleteRaceStatus;
import java.time.LocalDateTime;
/**
 *
 * @author Shimin
 * @author Stephen Clyde
 */
public class FinishedUpdate extends AthleteUpdate {
    private LocalDateTime officialEndTime;
    
    public FinishedUpdate() {
        super(AthleteRaceStatus.Finished);
    }
    
    public FinishedUpdate(String[] properties) throws ApplicationException {
        super (AthleteRaceStatus.Finished, properties);
        
        if (properties.length != 4 || !properties[0].equals(AthleteRaceStatus.Finished.toString()))
            throw new ApplicationException("Invalid properties");
        
        officialEndTime = LocalDateTime.parse(properties[3], dateTimeFormatter);
    }

    public String toString() { return super.toString() + "," + officialEndTime.format(dateTimeFormatter); }
    
    public void setOfficialEndTime (LocalDateTime OfficialEndTime) {
        officialEndTime = OfficialEndTime;
    }

    public LocalDateTime getOfficialEndTime () {
        return officialEndTime;
    }

}
