#include "InvestmentCalculator.h"
#include <iostream>
#include <iomanip>

using namespace std;

InvestmentCalculator::InvestmentCalculator() {
    m_initialInvestment = 0.0;
    m_monthlyDeposit = 0.0;
    m_annualInterest = 0.0;
    m_numberOfYears = 0;
}

// Setters
void InvestmentCalculator::setInitialInvestment(double t_initialInvestment) {
    m_initialInvestment = t_initialInvestment;
}

void InvestmentCalculator::setMonthlyDeposit(double t_monthlyDeposit) {
    m_monthlyDeposit = t_monthlyDeposit;
}

void InvestmentCalculator::setAnnualInterest(double t_annualInterest) {
    m_annualInterest = t_annualInterest;
}

void InvestmentCalculator::setNumberOfYears(int t_numberOfYears) {
    m_numberOfYears = t_numberOfYears;
}

// Getters
double InvestmentCalculator::getInitialInvestment() const {
    return m_initialInvestment;
}

double InvestmentCalculator::getMonthlyDeposit() const {
    return m_monthlyDeposit;
}

double InvestmentCalculator::getAnnualInterest() const {
    return m_annualInterest;
}

int InvestmentCalculator::getNumberOfYears() const {
    return m_numberOfYears;
}

// Displays the entered values
void InvestmentCalculator::displayInputValues() const {
    cout << "**********************************" << endl;
    cout << "********** Data Input ************" << endl;
    cout << fixed << setprecision(2);
    cout << "Initial Investment Amount: $" << m_initialInvestment << endl;
    cout << "Monthly Deposit: $" << m_monthlyDeposit << endl;
    cout << "Annual Interest: %" << m_annualInterest << endl;
    cout << "Number of years: " << m_numberOfYears << endl;
}

// Displays the shared table header used by both reports
void InvestmentCalculator::displayReportHeader(const string& t_title) const {
    cout << endl;
    cout << "  " << t_title << endl;
    cout << "==============================================================" << endl;
    cout << left
         << setw(10) << "Year"
         << setw(22) << "Year End Balance"
         << setw(25) << "Year End Earned Interest" << endl;
    cout << "--------------------------------------------------------------" << endl;
}

// Displays the report without additional monthly deposits
void InvestmentCalculator::displayReportWithoutMonthlyDeposits() const {
    double balance = m_initialInvestment;
    double monthlyInterestRate = (m_annualInterest / 100.0) / 12.0;

    displayReportHeader("Balance and Interest Without Additional Monthly Deposits");

    for (int year = 1; year <= m_numberOfYears; year++) {
        double yearlyInterestEarned = 0.0;

        for (int month = 1; month <= 12; month++) {
            double monthlyInterest = balance * monthlyInterestRate;
            balance += monthlyInterest;
            yearlyInterestEarned += monthlyInterest;
        }

        cout << left << setw(10) << year;
        cout << "$" << setw(21) << fixed << setprecision(2) << balance;
        cout << "$" << fixed << setprecision(2) << yearlyInterestEarned << endl;
    }
}

// Displays the report with additional monthly deposits
void InvestmentCalculator::displayReportWithMonthlyDeposits() const {
    double balance = m_initialInvestment;
    double monthlyInterestRate = (m_annualInterest / 100.0) / 12.0;

    displayReportHeader("Balance and Interest With Additional Monthly Deposits");

    for (int year = 1; year <= m_numberOfYears; year++) {
        double yearlyInterestEarned = 0.0;

        for (int month = 1; month <= 12; month++) {
            // Add the monthly deposit first, then calculate interest.
            balance += m_monthlyDeposit;

            double monthlyInterest = balance * monthlyInterestRate;
            balance += monthlyInterest;
            yearlyInterestEarned += monthlyInterest;
        }

        cout << left << setw(10) << year;
        cout << "$" << setw(21) << fixed << setprecision(2) << balance;
        cout << "$" << fixed << setprecision(2) << yearlyInterestEarned << endl;
    }
}