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
public class LocationUpdate extends AthleteUpdate {
    private double locationOnCourse;
    
    public LocationUpdate() {
        super(AthleteRaceStatus.OnCourse);
    }
    
    public LocationUpdate(String[] properties) throws ApplicationException {
        super (AthleteRaceStatus.OnCourse, properties);
        
        // the cs file LocationUpdate.cs on line 14 might have a bug here
        if (properties.length != 4 || !properties[0].equals(AthleteRaceStatus.OnCourse.toString()))
            throw new ApplicationException("Invalid properties");
        
        locationOnCourse = Double.parseDouble(properties[3]);
    }
    
    @Override
    public String toString() {
        return super.toString() + "," + locationOnCourse;
    }
    
    public void setLocationOnCourse (double value) { locationOnCourse = value; }

    public double getLocationOnCourse () {
        return locationOnCourse;
    }
}
