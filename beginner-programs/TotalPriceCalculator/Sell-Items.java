/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sellitems;

import java.util.*;
/**
 *
 * @author Nathaniel.Carballo
 */
public class SellItems {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        /*allows user to declare size of array be stating amount of
        to be checked
        */
        System.out.println("Declare amount of prices to total: ");
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        
        //creates the array based of size given from user
        double[] itemPriceArray = new double[n];
        double subTotal = 0;
        
        //keeps track of items given and takes prices from user
        for(int i=0; i<itemPriceArray.length; i++){
            System.out.println("Enter Price No."+(i+1)+": ");
            itemPriceArray[i] = scanner.nextDouble();
             
        }
        //adds prices together from array to get subtotal
        scanner.close();
        for(int i=0; i<itemPriceArray.length; i++){
            subTotal = subTotal + itemPriceArray[i];
        
        }
        //returns the prices given by user
        System.out.println("\nPrices entered were:");
        for (double element: itemPriceArray){
            System.out.println(element);
        }
        
        //calculates sales tax of 7%
        double salesTax = subTotal * 0.07;
        //adds the sales tax to subtotal to get final total
        double total = subTotal + salesTax;
        
        
        //displays the sales tax calculated
        System.out.format("\nSales tax for total item prices: %.2f", salesTax);
        //displays the final total to user
        System.out.format("\nTotal price of all items including sales tax: %.2f ",
                total);
            
    
    }
    
        
        
}
     
