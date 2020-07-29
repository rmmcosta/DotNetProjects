#include "BaseDMA.h"

BaseDMA::BaseDMA(const char* s)
{
	int l = strlen(s) + 1;
	name = new char[l];
	strcpy_s(name, l, s);
}

BaseDMA::BaseDMA(const BaseDMA& b)
{
	const char* copy = "copy of ";
	int l = strlen(copy) + strlen(b.name) + 1;
	name = new char[l];
	strcpy_s(name, l, copy);
	strcat_s(name, l, b.name);
}

BaseDMA& BaseDMA::operator=(const BaseDMA& b)
{
	if (this == &b)
		return *this;
	delete[] name;
	const char* copy = "assignment of copy ";
	int l = strlen(copy) + strlen(b.name) + 1;
	name = new char[l];
	strcpy_s(name, l, copy);
	strcat_s(name, l, b.name);
	return *this;
}

BaseDMA::~BaseDMA()
{
	delete[] name;
}

ostream& operator<<(ostream& out, const BaseDMA& b)
{
	out << b.name << endl;
	return out;
}