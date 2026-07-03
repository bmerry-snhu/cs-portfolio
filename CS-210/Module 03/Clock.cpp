/*
    Author: Blake Merry
    Date: March 26, 2026
*/

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

// Displays both clocks side by side
void displayTime(int hour, int minute, int second) {
    int hour12;
    string meridiem;

    // Convert 24-hour format to 12-hour format
    if (hour == 0) {
        hour12 = 12;
        meridiem = "A M";
    }
    else if (hour < 12) {
        hour12 = hour;
        meridiem = "A M";
    }
    else if (hour == 12) {
        hour12 = 12;
        meridiem = "P M";
    }
    else {
        hour12 = hour - 12;
        meridiem = "P M";
    }

    cout << endl;
    cout << "**************************    **************************" << endl;
    cout << "*     12-Hour Clock     *    *     24-Hour Clock     *" << endl;
    cout << "*     "
         << setw(2) << setfill('0') << hour12 << ":"
         << setw(2) << setfill('0') << minute << ":"
         << setw(2) << setfill('0') << second << " " << meridiem
         << "     *    *       "
         << setw(2) << setfill('0') << hour << ":"
         << setw(2) << setfill('0') << minute << ":"
         << setw(2) << setfill('0') << second
         << "       *" << endl;
    cout << "**************************    **************************" << endl;
}

// Displays menu options
void displayMenu() {
    cout << endl;
    cout << "************ Menu ************" << endl;
    cout << "* 1 - Add One Hour           *" << endl;
    cout << "* 2 - Add One Minute         *" << endl;
    cout << "* 3 - Add One Second         *" << endl;
    cout << "* 4 - Exit Program           *" << endl;
    cout << "******************************" << endl;
}

// Add one hour with rollover, 24:00 = 00:00
void addHour(int& hour) {
    hour++;
    if (hour > 23) {
        hour = 0;
    }
}

// Add one minute with rollover, 60+ minutes adds a hour
void addMinute(int& hour, int& minute) {
    minute++;
    if (minute > 59) {
        minute = 0;
        addHour(hour);
    }
}

// Add one second with rollover, 60+ seconds adds a minute
void addSecond(int& hour, int& minute, int& second) {
    second++;
    if (second > 59) {
        second = 0;
        addMinute(hour, minute);
    }
}

int main() {
    int hour;
    int minute;
    int second;
    int choice;

    // Get initial time
    cout << "Enter initial hour (0-23): ";
    cin >> hour;

    cout << "Enter initial minute (0-59): ";
    cin >> minute;

    cout << "Enter initial second (0-59): ";
    cin >> second;

    // Main program loop
    do {
        displayTime(hour, minute, second);
        displayMenu();

        cout << "Select an option: ";
        cin >> choice;

        // Handle menu choice
        switch (choice) {
            case 1:
                addHour(hour);
                break;

            case 2:
                addMinute(hour, minute);
                break;

            case 3:
                addSecond(hour, minute, second);
                break;

            case 4:
                cout << "Program ended." << endl;
                break;

            default:
                cout << "Invalid option. Please choose 1-4." << endl;
                break;
        }
    } while (choice != 4);

    return 0;
}