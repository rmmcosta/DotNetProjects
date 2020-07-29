#pragma once
#include "BaseDMA.h"
class LackDMA : public BaseDMA
{
private:
	int x;
public:
	LackDMA() :BaseDMA(), x(0) {};
	LackDMA(const char* name) :BaseDMA(name), x(0) {}
	void setX(int x) { this->x = x; }
	int getX() { return x; }
	friend ostream& operator<<(ostream&, const LackDMA&);
};
