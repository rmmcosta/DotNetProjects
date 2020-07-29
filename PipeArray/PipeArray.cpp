// PipeArray.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

const int kSize = 66;
const int kIter = 6;

void subdivide(char arr[], int low, int high, int level);
void resetArray(char arr[], int init, int end);
int main()
{
	//init array
	char arr[kSize];
	arr[kSize - 1] = '\0';
	arr[0] = '|';
	arr[kSize - 2] = '|';
	resetArray(arr, 1, kSize - 2);
	cout << arr << endl;
	for (int i = 1; i <= kIter; i++)
	{
		subdivide(arr, 0, kSize-2, i);
		cout << arr << endl;
		resetArray(arr, 1, kSize - 2);
	}
}

void subdivide(char arr[], int low, int high, int level)
{
	if (level == 0)
		return;
	int med = (high - low) / 2 + low;
	arr[med] = '|';
	subdivide(arr, med, high, level - 1);
	subdivide(arr, low, med, level - 1);
}

void resetArray(char arr[], int init, int end)
{
	for (int i = init; i < end; i++)
	{
		arr[i] = ' ';
	}
}


// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
