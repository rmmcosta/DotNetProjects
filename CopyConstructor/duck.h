#pragma once
#include <string>
using namespace std;
#ifndef DUCK_H
#define DUCK_H
class Duck
{
protected:
	double weight;
	string origin;
public:
	Duck(double w = 0.0, string o = "unknown") :weight(w), origin(o) {}
	~Duck();
	void presentDuck();
	void addWeight(double);
};
#endif // !DUCK_H

