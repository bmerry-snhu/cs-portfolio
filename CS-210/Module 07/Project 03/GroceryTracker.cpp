#include "GroceryTracker.h"

#include <fstream>
#include <iostream>
#include <stdexcept>

using namespace std;

// Note: I used const auto& here because it avoids unnecessary copies and keeps iteration efficient.
//       The const also ensures the data isn't modified. - BM

// Loads grocery item data and counts frequency
void GroceryTracker::LoadData(const string& filename) {
    try {
        ifstream inputFile(filename);
        string item;

        if (!inputFile.is_open()) {
            throw runtime_error("Could not open input file.");
        }

        while (inputFile >> item) {
            itemFrequency[item]++;
        }

        inputFile.close();
    }
    catch (const exception& e) {
        cout << "Error loading data: " << e.what() << endl;
    }
}

// Writes frequency data to backup file
void GroceryTracker::SaveToFile(const string& filename) const {
    try {
        ofstream outFile(filename);

        if (!outFile.is_open()) {
            throw runtime_error("Could not create backup file.");
        }

        for (const auto& pair : itemFrequency) {
            outFile << pair.first << " " << pair.second << endl;
        }

        outFile.close();
    }
    catch (const exception& e) {
        cout << "Error saving data: " << e.what() << endl;
    }
}

// Prompts user for item and displays frequency
void GroceryTracker::SearchItem() const {
    try {
        string item;
        cout << "Enter item to search: ";
        cin >> item;

        auto it = itemFrequency.find(item);

        if (it != itemFrequency.end()) {
            cout << item << " appears " << it->second << " times." << endl;
        }
        else {
            cout << item << " not found." << endl;
        }
    }
    catch (const exception& e) {
        cout << "Error during search: " << e.what() << endl;
    }
}

// Displays all item frequencies
void GroceryTracker::PrintAllFrequencies() const {
    try {
        for (const auto& pair : itemFrequency) {
            cout << pair.first << " " << pair.second << endl;
        }
    }
    catch (const exception& e) {
        cout << "Error printing frequencies: " << e.what() << endl;
    }
}

// Displays histogram using asterisks
void GroceryTracker::PrintHistogram() const {
    try {
        for (const auto& pair : itemFrequency) {
            cout << pair.first << " ";

            // Print one asterisk per occurrence
            for (int i = 0; i < pair.second; ++i) {
                cout << "*";
            }

            cout << endl;
        }
    }
    catch (const exception& e) {
        cout << "Error printing histogram: " << e.what() << endl;
    }
}