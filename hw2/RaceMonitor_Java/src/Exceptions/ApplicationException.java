/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Exceptions;

/**
 *
 * @author Shimin
 */
public class ApplicationException extends Exception {

    private static final long serialVersionUID = 106163635L;
            
    /**
     * Creates a new instance of <code>ApplicationException</code> without
     * detail message.
     */
    public ApplicationException() {
    }

    /**
     * Constructs an instance of <code>ApplicationException</code> with the
     * specified detail message.
     *
     * @param msg the detail message.
     */
    public ApplicationException(String msg) {
        super(msg);
    }
}
