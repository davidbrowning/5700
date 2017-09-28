package Racedata;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Shimin
 * @auther Stephen Clyde
 */

import Exceptions.ApplicationException;
import Messages.AthleteUpdate;
import java.io.BufferedReader;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

class Simulator extends Thread {
    private boolean keep_going;
    private BufferedReader f_reader;
    private int SleepTimeForSimulatedSecond = 1000;
    private IAthleteUpdateHandler Handler;
    
    public Simulator(BufferedReader f_reader, IAthleteUpdateHandler Handler) {
        this.f_reader = f_reader;
        this.Handler = Handler;
        keep_going = true;
    }
    
    @Override
    public void run() {
        while (keep_going) {
            SimulateOneSecondOfData();
            try {
                java.lang.Thread.sleep(SleepTimeForSimulatedSecond);
            } catch (InterruptedException ex) {
                Logger.getLogger(Simulator.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
    
    public void Stop() {
        keep_going = false;
    }
    
    private void SimulateOneSecondOfData() {
        String line = null;
        try {
            line = f_reader.readLine();
        } catch (IOException ex) {
            Logger.getLogger(Simulator.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        if (line == null) { keep_going = false; }
        
        while (line != null && !line.equals("---"))
        {
            try {
                Messages.AthleteUpdate msg= AthleteUpdate.Create(line);
                Handler.ProcessUpdate(msg);
                line = f_reader.readLine();
            } catch (IOException ex) {
                Logger.getLogger(Simulator.class.getName()).log(Level.SEVERE, null, ex);
            } catch (ApplicationException ex) {
                Logger.getLogger(Simulator.class.getName()).log(Level.WARNING , null, ex);
            }
        }
    }
    
    public void setSleepTimeForSimulatedSecond (int SleepTimeForSimulatedSecond) {
        this.SleepTimeForSimulatedSecond = SleepTimeForSimulatedSecond;
    }

    public int getSleepTimeForSimulatedSecond () {
        return this.SleepTimeForSimulatedSecond;
    }
}
