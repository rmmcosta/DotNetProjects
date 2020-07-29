#include "LackDMA.h"

ostream& operator<<(ostream& out, const LackDMA& ldma)
{
	out << (const BaseDMA&)ldma;
	return out;
}