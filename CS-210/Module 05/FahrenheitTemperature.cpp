#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>

using namespace std;

int main() {
    string city;
    int fahrenheit;
    double celsius;

    // Open file, input-mode
    ifstream inputFile("FahrenheitTemperature.txt");

    if (!inputFile.is_open()) {
        cout << "Error: Could not open input file." << endl;
        return 1;
    }

    // Open file, output-mode
    ofstream outputFile("CelsiusTemperature.txt");

    if (!outputFile.is_open()) {
        cout << "Error: Could not open output file." << endl;
        return 1;
    }

    // Read data from input file
    while (inputFile >> city >> fahrenheit) {
        // Convert to Celsius (use double to avoid integer division)
        celsius = (fahrenheit - 32) * (5.0 / 9.0);

        // Write to output file, rounded to 2 decimal places for easier human reading
        outputFile << city << " " << fixed << setprecision(2) << celsius << endl;
    }

    // Close both files
    inputFile.close();
    outputFile.close();

    cout << "Conversion complete. Data written to CelsiusTemperature.txt" << endl;

    return 0;
}