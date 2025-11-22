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
public class Services extends Account {
    
    protected double numberOfHours;
    protected double ratePerHour;
    protected double calculatedServSales;
    
    public Services(){}
    
    //public calculatedsales(){}
    
    public Services(String accountName, int accountID,
            double numberOfHours , double ratePerHour){
        super(accountName,accountID);
        
        this.numberOfHours = numberOfHours;
        this.ratePerHour = ratePerHour;
        this.calculatedServSales = ratePerHour * numberOfHours;
           
    }
    public double getNumberOfHours(){
        return(numberOfHours);
    }
    
    public void setNumberOfHours(double newNumberOfHours){
        numberOfHours = newNumberOfHours;
    
    }
    
    public double getRatePerHour(){
        return(ratePerHour);
    }
    
    public void setRatePerHour(double newRatePerHour){
        ratePerHour = newRatePerHour;
    }
    
    public double getCalculatedServSales(){
        return(calculatedServSales);
  
    }
    
    public void setCalculatedServSales(double newServSale){
        calculatedServSales = newServSale;
    }
    
    public String toString(){
        return(super.toString() + "\nNumber of hours logged: " + numberOfHours
                + "\nRate per hour: " + ratePerHour +
                "\nTotal Charge: " + calculatedServSales);
    }
    
}
