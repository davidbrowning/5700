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
public class StartedUpdate extends AthleteUpdate {
    private LocalDateTime officialStartTime;
    
    public StartedUpdate() {
        super(AthleteRaceStatus.Started);
    }
    
    public StartedUpdate(String[] properties) throws ApplicationException {
        super (AthleteRaceStatus.Started, properties);
        
        if (properties.length != 4 || !properties[0].equals(AthleteRaceStatus.Started.toString()))
            throw new ApplicationException("Invalid properties");

        officialStartTime = LocalDateTime.parse(properties[3], dateTimeFormatter);
    }
    
    @Override
    public String toString() { return super.toString() + "," + officialStartTime.format(dateTimeFormatter); }
    
    public void setOfficialStartTime (LocalDateTime value) {
        officialStartTime = value;
    }

    public LocalDateTime getOfficialStartTime () {
        return officialStartTime;
    }

}
