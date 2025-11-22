package average;


import java.util.Scanner;
public class Average {
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        /*(allows the scanner utililty to read user input
        and decide the size of array to store integers for averaging
        */
        System.out.println("Declare amount of integers to average: ");
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        
        //declares an array size according to user input
         double[] array = new double[n];
         double total = 0;
         
         //gathers integers from user input
         for(int i=0; i<array.length; i++){
             System.out.println("Enter Integer No."+(i+1)+": ");
             array[i] = scanner.nextDouble();
         }
         //takes the integers and adds them together.
         scanner.close();
         for(int i=0; i<array.length; i++){
             total = total + array[i];
         }
         //returns given integers to user
         System.out.println("\nIntegers given were:");
         for (double element: array){
             System.out.println(element);
         }
        
         //takes integers totals and divides them by length of array    
         double average = total / array.length;
         
         System.out.format("The average of given integers:\n%.2f", average);
         }
    }
    
