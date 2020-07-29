// ostream.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>
using namespace std;

void fileIn(ostream&, const string, const int[], const int size);

int main()
{
	ofstream fout;
	fout.open("myFile.txt");
	if (!fout.is_open()) {
		cout << "Error openning file..." << endl;
		exit(EXIT_FAILURE);
	}
	int myValues[] = { 1,3,5,6,7 };
	fileIn(fout, "This is just a bunch of values", myValues, 5);
	fileIn(cout, "Print them", myValues, 5);
}

void fileIn(ostream& out, const string title, const int values[], const int size)
{
	out << "-----------------------------" << endl;
	out << "---- " << title << " ----" << endl;
	for (int i = 0; i < size; i++)
	{
		out << i << endl;
	}
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
