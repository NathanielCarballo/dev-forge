/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package companysales;

/**
 *
 * @author Nathaniel.Carballo
 */
public class Account {
    protected String accountName;
    protected int accountID;
    
    
    public Account(){
        
    }
    
    // public calculatedsales(){}
    
    public Account(String accountName, int accountID){
        this.accountName = accountName;
        this.accountID = accountID;
        
    }

    public String toString(){
        return("Account Name: " + accountName + "\n" 
                + "AccountID: " + accountID);
    }
    
}
