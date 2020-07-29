#include "MyStack.h"
#include <iostream>
#include <string>
using namespace std;

void isCreatedEmpty();
void isFull();
void twoPushesTwoPops();
void pushCharPopChar();
void pushStringPopString();
void isEmptyNoPop();
void pushCustomObjectPop();
void pushPointerPop();
void stack2();

class CustomClass {
private:
	int id;
public:
	CustomClass(int id = 1) :id(id) {}
	friend ostream& operator<<(ostream&, CustomClass&);
};

ostream& operator<<(ostream& out, CustomClass& cc) {
	out << "identifier:" << cc.id << endl;
	return out;
}

int main()
{
	isCreatedEmpty();
	isFull();
	twoPushesTwoPops();
	pushCharPopChar();
	pushStringPopString();
	isEmptyNoPop();
	pushCustomObjectPop();
	pushPointerPop();
	stack2();
	return 0;
}

void isCreatedEmpty() {
	MyStack<int> ms1 = MyStack<int>();
	cout << "is empty: " << ms1.isEmpty() << endl;
}
void isEmptyNoPop() {
	MyStack<int> ms1 = MyStack<int>();
	cout << "is empty: " << ms1.isEmpty() << endl;
	int result;
	bool success = ms1.pop(result);
	cout << "success: " << success << " result: " << result << endl;
}
void isFull() {
	MyStack<int> ms1 = MyStack<int>();
	for (int i = 0; i < MAX; i++)
	{
		ms1.push(i);
	}
	cout << "is full: " << ms1.isFull() << endl;
}
void twoPushesTwoPops() {
	MyStack<int> ms2 = MyStack<int>();
	bool success;
	success = ms2.push(55);
	cout << "push 55: " << success << endl;
	success = ms2.push(33);
	cout << "push 33: " << success << endl;
	int result;
	success = ms2.pop(result);
	cout << "33 -> " << success << " " << result << endl;
	success = ms2.pop(result);
	cout << "55 -> " << success << " " << result << endl;
	cout << "is empty: " << ms2.isEmpty() << endl;
}
void pushCharPopChar() {
	MyStack<char> ms3 = MyStack<char>();
	char c = 'A';
	ms3.push(c);
	char cr;
	ms3.pop(cr);
	cout << "pop char: " << cr << endl;
}
void pushStringPopString() {
	MyStack<string> ms4 = MyStack<string>();
	ms4.push("coiso e tal");
	string sr;
	ms4.pop(sr);
	cout << "string result: " << sr << endl;
}

void pushCustomObjectPop() {
	CustomClass cc = CustomClass(11);
	cout << "cc: " << cc;
	MyStack<CustomClass> ms = MyStack<CustomClass>();
	bool success;
	success = ms.push(cc);
	cout << "push with success: " << success << endl;
	CustomClass cc1;
	success = ms.pop(cc1);
	cout << "pop with success: " << success << " cc1 " << cc1;
}

void pushPointerPop() {
	CustomClass* cc = new CustomClass(12);
	cout << "cc* " << *cc;
	MyStack<CustomClass*> ms = MyStack<CustomClass*>();
	bool success;
	success = ms.push(cc);
	cout << "push with success: " << success << endl;
	CustomClass* cc1;
	success = ms.pop(cc1);
	cout << "pop with success: " << success << " cc1 " << *cc1;
}

void stack2()
{
	cout << "stack2" << endl;
	MyStack<CustomClass*> ms = MyStack<CustomClass*>(2);
	ms.push(new CustomClass(3));
	ms.push(new CustomClass(7));
	if (!ms.isFull())
		ms.push(new CustomClass());
	CustomClass* temp;
	while (!ms.isEmpty())
	{
		ms.pop(temp);
		cout << *temp;
	}
	cout << "end stack2" << endl;
}