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
public class Supplies extends Account {
    
    protected int numberOfItems;
    protected double pricePerItem;
    protected double calculatedServSales;
    
    public Supplies(){}
    
    
    
    public Supplies(String accountName, int accountID,
            int numberOfItems , double pricePerItem){
        super(accountName,accountID);
        
        this.numberOfItems = numberOfItems;
        this.pricePerItem = pricePerItem;
        this.calculatedServSales = pricePerItem * numberOfItems;
           
    }
    public double getNumberOfItems(){
        return(numberOfItems);
    }
    
    public void setNumberOfItems(int newNumberOfItems){
        numberOfItems = newNumberOfItems;
    
    }
    
    public double getRatePerHour(){
        return(pricePerItem);
    }
    
    public void setRatePerHour(double newRatePerHour){
        pricePerItem = newRatePerHour;
    }
    
    public double getCalculatedServSales(){
        return(calculatedServSales);
  
    }
    
    public void setCalculatedServSales(double newServSale){
        calculatedServSales = newServSale;
    }
    
    public String toString(){
        return(super.toString() + "\nNumber of Items Sold: " + numberOfItems
                + "\nPrice Per Item: " + pricePerItem +
                "\nTotal Charge: " + calculatedServSales);
    
}
}