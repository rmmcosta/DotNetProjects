#include "BaseDMA.h"
#include "LackDMA.h"
#include "HasDMA.h"

int main()
{
	BaseDMA b = BaseDMA("xpto");
	cout << b;
	BaseDMA b1 = BaseDMA("cenas");
	cout << b1;
	BaseDMA b2 = b1; //uses copy constructor
	cout << b2;
	BaseDMA b3;
	b3 = b2; //uses assignment operator
	cout << b3;
	BaseDMA* b4 = new BaseDMA(b3); //uses copy constructor
	cout << *b4;
	BaseDMA* b5 = new BaseDMA(*b4); //uses copy constructor
	cout << *b5;
	delete b4;
	cout << *b5;
	LackDMA ld1;
	cout << ld1;
	BaseDMA* b6 = new BaseDMA(ld1);
	cout << *b6;
	LackDMA* ld2 = new LackDMA("Ana");
	cout << *ld2;
	LackDMA ld3;
	ld3 = *ld2;
	cout << ld3;
	delete ld2;
	cout << ld3;
	cout << "has dma starts now" << endl;
	HasDMA hd1 = HasDMA("Ricardo","Costa");
	cout << "hd1" << endl;
	cout << hd1;
	HasDMA hd2 = hd1;
	cout << "hd2" << endl;
	cout << hd2;
	HasDMA* hd3 = new HasDMA("Rodrigo", "Costa");
	cout << "*hd3" << endl;
	cout << *hd3;
	HasDMA hd4 = HasDMA(*hd3);
	cout << "hd4" << endl;
	cout << hd4;
	delete hd3;
	cout << "hd4 after delete hd3" << endl;
	cout << hd4;
	HasDMA hd5;
	hd5 = hd4;
	cout << "hd5 = hd4" << endl;
	cout << hd5;
	hd5 = hd5;
	cout << "hd5 = hd5" << endl;
	cout << hd5;
	return 0;
}