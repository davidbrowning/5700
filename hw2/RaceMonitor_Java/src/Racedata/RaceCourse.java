package Racedata;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Shimin
 */
public class RaceCourse {
    private int Id;
    private String Name;
    private int TotalDistance;   // Total length of course in meters
    
    public void setId (int Id) {
        this.Id = Id;
    }

    public int getId () {
        return this.Id;
    }
    
    public void setName (String Name) {
        this.Name = Name;
    }

    public String getName () {
        return this.Name;
    }
    
    public void setTotalDistance (int TotalDistance) {
        this.TotalDistance = TotalDistance;
    }

    public int getTotalDistance () {
        return this.TotalDistance;
    }
}
