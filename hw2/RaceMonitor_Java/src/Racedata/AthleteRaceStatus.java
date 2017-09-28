package Racedata;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Shimin
 * @author Stephen Clyde
 */
public enum AthleteRaceStatus {
    Registered,
    DidNotStart,
    Started,
    OnCourse,
    DidNotFinish,
    Finished;

    public static AthleteRaceStatus ConvertFrom(String value)
    {
        if (value==null) return null;

        value = value.trim().toLowerCase();
        switch (value) {
            case "registered":
                return Registered;
            case "didnotstart":
                return DidNotStart;
            case "started":
                return Started;
            case "oncourse":
                return OnCourse;
            case "didnotfinish":
                return DidNotFinish;
            case "finished":
                return Finished;
        }

        return null;
    }
}
