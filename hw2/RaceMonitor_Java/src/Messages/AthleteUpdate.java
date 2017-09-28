/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Messages;

import Exceptions.ApplicationException;
import Racedata.AthleteRaceStatus;
import java.time.format.DateTimeFormatter;
import java.time.LocalDateTime;

/**
 *
 * @author Shimin
 * @auther Stephen Clyde
 */
public abstract class AthleteUpdate {
    protected DateTimeFormatter dateTimeFormatter = DateTimeFormatter.ofPattern("M/d/yyyy h:mm:ss a");

    private AthleteRaceStatus updateType;
    private int bibNumber;
    private LocalDateTime timestamp;

    public AthleteUpdate(AthleteRaceStatus type) {
        updateType = type;
    }
    
    public AthleteUpdate(AthleteRaceStatus type, String[] properties) {
        updateType = type;
        bibNumber = Integer.parseInt(properties[1]);
        timestamp = LocalDateTime.parse(properties[2], dateTimeFormatter);
    }
    
    public static AthleteUpdate Create(String simulationData) throws ApplicationException {
        if (simulationData==null || simulationData.trim().isEmpty())
            throw new ApplicationException("Data required to create an AthleteUpdate");
        
        String[] fields = simulationData.split(",");
        if (fields.length<3)
            throw new ApplicationException("At least 3 data fields required to create an AthleteUpdate");


        AthleteRaceStatus objectType = AthleteRaceStatus.ConvertFrom(fields[0]);
        if (objectType==null)
            throw new ApplicationException("Invalid AthleteUpdate type");

        AthleteUpdate result=null;
        switch (objectType) {
            case Registered:
                result = new RegistrationUpdate(fields);
                break;
            case DidNotStart:
                result = new DidNotStartUpdate(fields);
                break;
            case Started:
                result = new StartedUpdate(fields);
                break;
            case OnCourse:
                result = new LocationUpdate(fields);
                break;
            case DidNotFinish:
                result = new DidNotFinishUpdate(fields);
                break;
            case Finished:
                result = new FinishedUpdate(fields);
                break;
            default:
                throw new ApplicationException("Invalid AthleteeUpdate type");
        }
        return result;
    }

    @Override
    public String toString() {
        return String.valueOf(updateType) + "," +bibNumber + "," + timestamp.format(dateTimeFormatter);
    }

    public AthleteRaceStatus getUpdateType () {
        return updateType;
    }
    
    public void setBibNumber (int value) {
        bibNumber = value;
    }

    public int getBibNumber () {
        return bibNumber;
    }

    public void setTimestamp (LocalDateTime value) { timestamp = value; }

    public LocalDateTime getTimestamp () {
        return timestamp;
    }
}
