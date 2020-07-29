#include "Animal.h"
#include <iostream>
using namespace std;

Animal::Animal(const Animal& a)
{
	age = a.age;
	isCopy = true;
}
const void Animal::printAge() const
{
	cout << age << endl;
}
const bool Animal::getIsCopy() const
{
	return isCopy;
}