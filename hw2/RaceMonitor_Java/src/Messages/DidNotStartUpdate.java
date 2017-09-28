/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Messages;

import Exceptions.ApplicationException;
import Racedata.AthleteRaceStatus;
/**
 *
 * @author Shimin
 * @author Stephen Clyde
 */
public class DidNotStartUpdate extends AthleteUpdate {
    public DidNotStartUpdate() {
        super(AthleteRaceStatus.DidNotStart);
    }
    
    public DidNotStartUpdate(String[] properties)  throws ApplicationException{
        super (AthleteRaceStatus.DidNotStart, properties);
        
        if (properties.length != 3 || !properties[0].equals(AthleteRaceStatus.DidNotStart.toString()))
            throw new ApplicationException("Invalid properties");
    }
}
