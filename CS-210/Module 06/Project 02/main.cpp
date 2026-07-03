#include <iostream>
#include <string>
#include <limits>
#include "InvestmentCalculator.h"

using namespace std;

// Note: I may have gone somewhat out of scope for the input validation here by using streamsize.
//       But this was my best effort at an appropriate solution. - BM

// Validates user input to ensure a non-negative double value
double getValidDouble(const string& t_prompt) {
    double value = 0.0;

    while (true) {
        cout << t_prompt;
        cin >> value;

        if (cin.fail() || value < 0) {
            cout << "Invalid input. Please enter a non-negative number." << endl;
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Clear any bad input
        }
        else {
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Clear any leftovers from the buffer
            return value;
        }
        // Repeat until valid input is received
    }
}

// Validates user input to ensure an integer greater than zero
int getValidInt(const string& t_prompt) {
    int value = 0;

    while (true) {
        cout << t_prompt;
        cin >> value;

        if (cin.fail() || value <= 0) {
            cout << "Invalid input. Please enter a whole number greater than 0." << endl;
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Clear any bad input
        }
        else {
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Clear any leftovers from the buffer
            return value;
        }
        // Repeat until valid input is received
    }
}

int main() {
    InvestmentCalculator calc;
    char choice = 'y';

    while (choice == 'y' || choice == 'Y') {
        cout << "**********************************" << endl;
        cout << "********** Data Input ************" << endl;

        double initialInvestment = getValidDouble("Initial Investment Amount: ");
        double monthlyDeposit = getValidDouble("Monthly Deposit: ");
        double annualInterest = getValidDouble("Annual Interest: ");
        int numberOfYears = getValidInt("Number of years: ");

        calc.setInitialInvestment(initialInvestment);
        calc.setMonthlyDeposit(monthlyDeposit);
        calc.setAnnualInterest(annualInterest);
        calc.setNumberOfYears(numberOfYears);

        cout << endl;
        calc.displayInputValues();
        cout << "Press any key to continue..." << endl;
        cin.get();

        calc.displayReportWithoutMonthlyDeposits();
        calc.displayReportWithMonthlyDeposits();

        cout << endl;
        cout << "Would you like to enter another set of values? (y/n): ";
        cin >> choice;
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << endl;
    }

    cout << "Program ended." << endl;

    return 0;
}