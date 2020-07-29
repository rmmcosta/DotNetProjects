#pragma once
#include "BaseDMA.h"

class HasDMA : public BaseDMA
{
private:
	char* otherName;
public:
	HasDMA() :BaseDMA() {};
	HasDMA(const char*, const char*);
	HasDMA(const HasDMA&);
	HasDMA(const char*, const BaseDMA&);
	HasDMA& operator=(const HasDMA&);
	~HasDMA();
	friend ostream& operator<<(ostream&, HasDMA&);
};