#include "HasDMA.h"

HasDMA::~HasDMA() {
	delete[] otherName;
}

HasDMA::HasDMA(const char* name, const char* oName) :BaseDMA(name) {
	int l = strlen(oName) + 1;
	otherName = new char[l];
	strcpy_s(otherName, l, oName);
}
HasDMA::HasDMA(const HasDMA& hdma) : BaseDMA(hdma) {
	int l = strlen(hdma.otherName) + 1;
	otherName = new char[l];
	strcpy_s(otherName, l, hdma.otherName);
}
HasDMA::HasDMA(const char* oName, const BaseDMA& bdma) : BaseDMA(bdma)
{
	int l = strlen(oName) + 1;
	otherName = new char[l];
	strcpy_s(otherName, l, oName);
}
HasDMA& HasDMA:: operator=(const HasDMA& hdma) {
	if (this == &hdma)
		return *this;
	delete[] otherName;
	BaseDMA::operator=(hdma);
	int l = strlen(hdma.otherName) + 1;
	otherName = new char[l];
	strcpy_s(otherName, l, hdma.otherName);
	return *this;
}
ostream& operator<<(ostream& out, HasDMA& hdma) {
	out << hdma.otherName << ", " << (BaseDMA)hdma;
	return out;
}