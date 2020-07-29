#include <iostream>
using namespace std;

int sum(int, int);
int sub(int, int);
int multi(int, int);
int divi(int, int);
int doMath(int (*func) (int, int), int, int);

int main()
{
	//cout << doMath(sum, 2, 3);
	cout << "Plase choose what do you want to do: ";
	char option;
	cin >> option;
	cout << "value for a:";
	int a, b;
	cin >> a;
	cout << "value for b:";
	cin >> b;
	int (*func) (int, int) = NULL;
	switch (option)
	{
	case 's':
		func = sum;
		break;
	case 'b':
		func = sub;
		break;
	case 'm':
		func = multi;
		break;
	case 'd':
		func = divi;
		break;
	default:
		break;
	}
	cout << doMath(func, a, b);
	return 0;
}

int sum(int a, int b)
{
	return a + b;
}

int sub(int a, int b)
{
	return a - b;
}

int multi(int a, int b)
{
	return a * b;
}

int divi(int a, int b)
{
	return a / b;
}

int doMath(int (*func)(int, int), int a, int b)
{
	cout << "do math" << endl;
	return func(a, b);
}