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
public class DidNotFinishUpdate extends AthleteUpdate {
    public DidNotFinishUpdate() {
        super(AthleteRaceStatus.DidNotFinish);
    }
    
    public DidNotFinishUpdate(String[] properties) throws ApplicationException {
        super (AthleteRaceStatus.DidNotFinish, properties);
        
        if (properties.length != 3 || !properties[0].equals(AthleteRaceStatus.DidNotFinish.toString()))
            throw new ApplicationException("Invalid properties");
    }
}
