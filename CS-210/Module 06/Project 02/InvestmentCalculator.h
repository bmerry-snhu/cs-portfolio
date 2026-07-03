#ifndef INVESTMENTCALCULATOR_H_
#define INVESTMENTCALCULATOR_H_

#include <string>

class InvestmentCalculator {
public:
    InvestmentCalculator();

    void setInitialInvestment(double t_initialInvestment);
    void setMonthlyDeposit(double t_monthlyDeposit);
    void setAnnualInterest(double t_annualInterest);
    void setNumberOfYears(int t_numberOfYears);

    double getInitialInvestment() const;
    double getMonthlyDeposit() const;
    double getAnnualInterest() const;
    int getNumberOfYears() const;

    void displayInputValues() const;
    void displayReportWithoutMonthlyDeposits() const;
    void displayReportWithMonthlyDeposits() const;

private:
    double m_initialInvestment;
    double m_monthlyDeposit;
    double m_annualInterest;
    int m_numberOfYears;

    void displayReportHeader(const std::string& t_title) const;
};

#endif