#include "duck.h"
#include <iostream>

void Duck::presentDuck()
{
	cout << "I'm a Duck from " << origin << " with " << weight << "kg." << endl;
}

void Duck::addWeight(double x)
{
	weight += x;
}

Duck::~Duck()
{
	//do nothing for now
}