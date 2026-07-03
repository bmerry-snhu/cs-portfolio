#include <iostream>
#include <limits>
#include "GroceryTracker.h"

using namespace std;

int main() {
    GroceryTracker tracker;
    int choice = 0;

    // Load input data and create backup file
    tracker.LoadData("CS210_Project_Three_Input_File.txt");
    tracker.SaveToFile("frequency.dat");

    while (choice != 4) {
        cout << endl;
        cout << "========== MENU ==========" << endl;
        cout << "1. Search for item" << endl;
        cout << "2. Print all item frequencies" << endl;
        cout << "3. Print histogram" << endl;
        cout << "4. Exit program" << endl;
        cout << "Enter choice: ";

        cin >> choice;

        if (cin.fail()) {
            cout << "Invalid option. Please enter a number from 1 to 4." << endl;
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            continue;
        }

        switch (choice) {
            case 1:
                tracker.SearchItem();
                break;

            case 2:
                tracker.PrintAllFrequencies();
                break;

            case 3:
                tracker.PrintHistogram();
                break;

            case 4:
                cout << "Program ended." << endl;
                break;

            default:
                cout << "Invalid option. Please try again." << endl;
                break;
        }
    }

    return 0;
}