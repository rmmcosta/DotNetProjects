#pragma once
#include <iostream>
using namespace std;
class BaseDMA
{
private:
	char* name;
public:
	BaseDMA(const char* s = "unknown");
	BaseDMA(const BaseDMA&);
	virtual ~BaseDMA();
	friend ostream& operator<<(ostream&, const BaseDMA&);
	BaseDMA& operator=(const BaseDMA&);
};
