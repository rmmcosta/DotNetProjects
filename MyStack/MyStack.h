#pragma once
const int MAX = 10;
template <typename T>
class MyStack
{
private:
	int stackSize;
	T* values;
	int top;
public:
	MyStack(int ss = MAX) :top(0), stackSize(ss) {
		values = new T[ss];
	}
	bool isEmpty();
	bool isFull();
	bool push(T);
	bool pop(T&);
	~MyStack();
};

template <typename T>
MyStack<T>::~MyStack()
{
	delete[] values;
}

template <typename T>
bool MyStack<T>::isEmpty()
{
	return top == 0;
}

template <typename T>
bool MyStack<T>::isFull()
{
	return top == stackSize;
}

template <typename T>
bool MyStack<T>::push(T value)
{
	if (isFull())
		return false;
	values[top++] = value;
	return true;
}

template <typename T>
bool MyStack<T>::pop(T& value)
{
	if (isEmpty())
		return false;
	value = values[--top];
	return true;
}