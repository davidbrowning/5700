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

import Exceptions.ApplicationException;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.logging.Level;
import java.util.logging.Logger;

public class SimulatedDataSource {
    private BufferedReader f_reader;
    private Thread simulatorThread;
    private Simulator simulator;
    
    private String InputFilename;
    private IAthleteUpdateHandler Handler;
    
    public void Start() throws ApplicationException {
        if (InputFilename == null || InputFilename.trim().isEmpty())
            throw new Exceptions.ApplicationException(
                            "Before starting a SimulatedDataSource,"+
                            "you must set InputFilename to path of the race data");

        if (Handler==null)
            throw new Exceptions.ApplicationException(
                            "You must set Handler to an object in your software "+
                            "that can process AthleteUpdate messages before starting a simulation");

        try {
            f_reader = new BufferedReader(new FileReader(InputFilename));
        } catch (FileNotFoundException ex) {
            Logger.getLogger(SimulatedDataSource.class.getName()).log(Level.SEVERE, null, ex);
        }
        simulator = new Simulator(f_reader, Handler);
        simulatorThread = new Thread(simulator);
        simulatorThread.start();
    }

    public void Stop() { simulator.Stop(); }
    
    public void setInputFilename (String InputFilename) {
        this.InputFilename = InputFilename;
    }

    public String getInputFilename () {
        return this.InputFilename;
    }
    
    public void setHandler (IAthleteUpdateHandler Handler) {
        this.Handler = Handler;
    }

    public IAthleteUpdateHandler getHandler () {
        return this.Handler;
    }
}
