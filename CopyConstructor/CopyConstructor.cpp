// CopyConstructor.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "duck.h"
#include "Animal.h"
#include <iostream>

int main()
{
	Duck d1(5.0, "Portugal");
	d1.presentDuck();
	const Duck d2(10.0, "Albania");
	Duck d3(d2);//copy constructor is auto generated when needed
	d3.presentDuck();
	d3.addWeight(1.1);
	d3.presentDuck();
	Animal a1(17);
	a1.printAge();
	cout << a1.getIsCopy() << endl;
	const Animal a2(20);
	a2.printAge();
	cout << a2.getIsCopy() << endl;
	Animal a3(a2);//explicit copy constructor
	a3.printAge();
	cout << a3.getIsCopy() << endl;
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
