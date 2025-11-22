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
public class CompanySales {
    
    public static void main(String[] args) {
        Account Crusader = new Account("Crusaders inc", 01);
        System.out.println(Crusader);
        
        Services Warriors = new Services("Warrior inc", 02, 50, 100);
        System.out.println(Warriors);
        
        Supplies Mages = new Supplies("Mage Guild", 03, 7, 10);
        System.out.println(Mages);
       
    }   
}
