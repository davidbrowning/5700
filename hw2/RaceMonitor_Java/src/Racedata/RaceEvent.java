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

import java.time.LocalTime;

public class RaceEvent {
    private int Id;
    private String Title;
    private LocalTime StartDateTime;
    
    public void setId (int Id) {
        this.Id = Id;
    }

    public int getId () {
        return this.Id;
    }
    
    public void setTitle (String Title) {
        this.Title = Title;
    }

    public String getTitle () {
        return this.Title;
    }
    
    public void setStartDateTime (LocalTime StartDateTime) {
        this.StartDateTime = StartDateTime;
    }

    public LocalTime getStartDateTime () {
        return this.StartDateTime;
    }
}
