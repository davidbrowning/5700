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
public class RegistrationUpdate extends AthleteUpdate {
    private String firstName;
    private String lastName;
    private String gender;
    private int age;
    
    public RegistrationUpdate() {
        super(AthleteRaceStatus.Registered);
    }
    
    public RegistrationUpdate(String[] properties) throws ApplicationException {
        super (AthleteRaceStatus.Registered, properties);
        
        if (properties.length != 7 || !properties[0].equals(AthleteRaceStatus.Registered.toString()))
            throw new ApplicationException("Invalid properties");

        firstName = properties[3];
        lastName = properties[4];
        gender = properties[5];
        age = Integer.parseInt(properties[6]);
    }
    
    @Override
    public String toString() {
        return super.toString() + "," + firstName + "," + lastName + "," + gender + "," + age;
    }
    
    public void setFirstName (String value) {
        firstName = value;
    }

    public String getFirstName () {
        return firstName;
    }
    
    public void setLastName (String value) {
        lastName = value;
    }

    public String getLastName () {
        return lastName;
    }
    
    public void setGender (String value) {
        gender = value;
    }

    public String getGender () {
        return gender;
    }

    public void setAge (int value) {
        age = value;
    }

    public int getAge () {
        return age;
    }
}
