#include <iostream>
#include <iomanip>
using namespace std;
int main()
{
	int num1, num2;
	char opr;
	cout << "Enter two integers: ";			                                                                   //asking for user input of two integers
	cin >> num1 >> num2;
	cout << endl;
	cout << "Enter operator: + (addition), - (subtraction)," << " * (multiplication), / (division): ";		   //asking how to deal with numbers
	cin >> opr;	                                                                                               //takes operator
	cout << endl;
	cout << num1 << " " << opr << " " << num2 << " = ";
	switch (opr) {		                                                                                       //begins to switch through the operators to find a match and give a result
	case '+':
		cout << num1 + num2 << endl;
		break;
	case'-':
		cout << num1 - num2 << endl;
		break;
	case'*':
		cout << num1 * num2 << endl;
		break;
	case'/':
		if (num2 != 0)
			cout << num1 / num2 << endl;
		else
			cout << "ERROR \nCannot divide by zero" << endl;		                                          //error for illegal division
		break;
	default:
		cout << "Illegal operation" << endl;			                                                      //error for wrong operator
	}
	return 0;
}