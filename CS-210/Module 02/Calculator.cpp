/*
 * Calculator.cpp
 *
 *  Date: 03/15/2026
 *  Author: Blake Merry
 */

#include <iostream>
using namespace std;

//	Changed void to int as standard in C++
int main()
{
	//	Changed int to double to handle both whole and decimal values
	double op1, op2;
	char operation;
	//	Initialized with single quotes as appropriate for char types
	char answer = 'y';

	//	Used a do-while loop to ensure first execution
	do {
		//	Fixed white space
		cout << "Enter expression" << endl;
		//	Fixed input statement to use >>
		cin >> op1 >> operation >> op2;

		//	Ensured operation was compared to a char '+'
		if (operation == '+') {
			cout << op1 << " + " << op2 << " = " << op1 + op2 << endl;
		}
		else if (operation == '-') {
			//	Fixed the output statement to use <<
			cout << op1 << " - " << op2 << " = " << op1 - op2 << endl;
		}
		else if (operation == '*') {
			//	Ensured output statement operator matched the actual operation
			cout << op1 << " * " << op2 << " = " << op1 * op2 << endl;
		}
		else if (operation == '/') {
			//	Ensured outpout statement operator match the actual operation
			cout << op1 << " / " << op2 << " = " << op1 / op2 << endl;
		}
		else {
			//	Added default case
			cout << "Invalid operator." << endl;
		}

		cout << "Do you wish to evaluate another expression? " << endl;
		cin >> answer;
	} while (answer == 'y' || answer == 'Y');

	//	Added temination message
	cout << "Program Finished." << endl;

	//	Added program termination
	return 0;
}







