// QuickSort.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

template <typename T>
inline void printVector(vector<T>&);

template <typename Iter>
inline void printVector(Iter, Iter);

template <typename Iter>
inline void mySwap(Iter, Iter);

template <typename Iter>
inline Iter partition(Iter, Iter);

template <typename Iter>
inline void myReverse(Iter, Iter);

template <typename Iter>
inline void quickSort(Iter, Iter);

template <typename T>
inline void printVector(vector<T>& values)
{
	for (T v : values)
	{
		cout << v << "\t";
	}
	cout << endl;
}

template <typename Iter>
inline void printVector(Iter start, Iter end)
{
	for (; start != end; start++)
		cout << *start << "\t";
	cout << endl;
}

template <typename Iter>
inline void mySwap(Iter start, Iter end)
{
	cout << "swap a=" << *start << ", b=" << *end << endl;
	auto temp = *start;
	*start = *end;
	*end = temp;
}

template <typename Iter>
inline void myReverse(Iter start, Iter end)
{
	while (start < end)
	{
		mySwap(start++, end--);
	}
}

template <typename Iter>
inline void quickSort(Iter start, Iter end)
{
	if (start >= end)
		return;
	Iter partitionBorder = partition(start, end);
	quickSort(start, partitionBorder);
	quickSort(partitionBorder + 1, end);
}

template <typename Iter>
inline Iter partition(Iter start, Iter end)
{
	cout << "partition..." << endl;
	Iter mid = start + (end - start) / 2;
	auto pivot = *mid;
	cout << "pivot: " << pivot << endl;
	while (true)
	{
		while (*start < pivot)
		{
			if (start == mid)
				break;
			start++;
		}

		while (*end > pivot)
		{
			if (end == mid)
				break;
			end--;
		}

		if (start >= end)
			return end;
		mySwap(start, end);
		//printVector(start, end);
		start++;
		end--;
	}
}

int main()
{
	int count;
	cout << "how many numbers? ";
	cin >> count;
	cout << endl;
	vector<int> nums(count);
	for (int i = 0; i < count; i++)
	{
		cout << "number " << i << ": ";
		cin >> nums[i];
	}
	printVector(nums);
	cout << "reverse..." << endl;
	myReverse(nums.begin(), nums.end() - 1);
	printVector(nums);
	cout << "quick sort..." << endl;
	quickSort(nums.begin(), nums.end() - 1);
	printVector(nums);
	nums.clear();
	cout << "how many letters? ";
	cin >> count;
	vector<char> phrase(count);
	for (int i = 0; i < count; i++)
	{
		cout << "char " << i << ": ";
		cin >> phrase[i];
	}
	printVector(phrase);
	cout << "reverse..." << endl;
	myReverse(phrase.begin(), phrase.end()-1);
	printVector(phrase);
	cout << "quick sort..." << endl;
	quickSort(phrase.begin(), phrase.end()-1);
	printVector(phrase);
	phrase.clear();
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
