#ifndef GROCERYTRACKER_H
#define GROCERYTRACKER_H

#include <map>
#include <string>

class GroceryTracker {
public:
    // Loads grocery item data from input file
    void LoadData(const std::string& filename);

    // Writes frequency data to backup file
    void SaveToFile(const std::string& filename) const;

    // Prompts user for item and displays frequency
    void SearchItem() const;

    // Displays all item frequencies
    void PrintAllFrequencies() const;

    // Displays histogram of item frequencies
    void PrintHistogram() const;

private:
    std::map<std::string, int> itemFrequency;
};

#endif