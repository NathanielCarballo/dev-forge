/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package activities;

import javax.swing.JOptionPane;

/**
 *
 * @author Nathaniel.Carballo
 */
public class Activities {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // labeling the loop to establish a target to break
        UserInput:

        while (true) {
            // ask the user to enter a day via GUI
            String answer = JOptionPane.showInputDialog("Enter a day of the"
                    + " week to view its activity");

            // tells the user to enter a day instead of clicking cancel
            if (answer == null) {
                JOptionPane.showMessageDialog(null, "You clicked Cancel,"
                        + " please answer instead");

                // tells the user to enter a day instead of integer
            } else if (answer.trim().length() == 0) {

                JOptionPane.showMessageDialog(null, "You must enter a day");

            } else {
                // trims any whitespaces in the answer
                String trimmedAnswer = answer.trim();

                switch (trimmedAnswer) {

                    // case for each day of the week and activity connected to them
                    default:

                        JOptionPane.showMessageDialog(null, "Please enter"
                                + " a day of the week");
                        break;

                    case "Monday":
                        JOptionPane.showMessageDialog(null, "Activity for "
                                + answer + " is jogging");
                        break UserInput;
                    case "Tuesday":
                        JOptionPane.showMessageDialog(null, "Activity for "
                                + answer + " is lifting weights");
                        break UserInput;
                    case "Wednesday":
                        JOptionPane.showMessageDialog(null, "Activity for "
                                + answer + " is stretching");
                        break UserInput;
                    case "Thursday":
                        JOptionPane.showMessageDialog(null, "Activity for "
                                + answer + " is swimming");
                        break UserInput;
                    case "Friday":
                        JOptionPane.showMessageDialog(null, "Activity for "
                                + answer + " is a resting day");
                        break UserInput;
                    case "Saturday":
                        JOptionPane.showMessageDialog(null, "Activity for "
                                + answer + " are squats");
                        break UserInput;
                    case "Sunday":
                        JOptionPane.showMessageDialog(null, "Activity for "
                                + answer + " is Basketball");
                        break UserInput;

                }
            }

        }
    }

}
