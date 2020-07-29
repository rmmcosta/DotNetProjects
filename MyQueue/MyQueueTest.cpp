#include "MyQueue.h"
#include <iostream>
using namespace std;

void allowEnqueueAndDequeue();
void noDequeueIsEmpty();
void enqueueDequeue();
void enqueueTwiceDequeueTwice();
void enqueueDequeueChar();

int main()
{
	cout << "--- allowEnqueueAndDequeue ---" << endl;
	allowEnqueueAndDequeue();
	cout << "-------------------------------------" << endl;
	cout << "--- noDequeueIsEmpty ---" << endl;
	noDequeueIsEmpty();
	cout << "-------------------------------------" << endl;
	cout << "--- enqueueDequeue ---" << endl;
	enqueueDequeue();
	cout << "-------------------------------------" << endl;
	cout << "--- enqueueTwiceDequeueTwice ---" << endl;
	enqueueTwiceDequeueTwice();
	cout << "-------------------------------------" << endl;
	cout << "--- enqueueDequeueChar ---" << endl;
	enqueueDequeueChar();
	cout << "-------------------------------------" << endl;
	return 0;
}

void allowEnqueueAndDequeue()
{
	MyQueue<int> mq1 = MyQueue<int>();
	cout << "allow enqueue: ";
	bool r = mq1.enqueue(2);
	cout << r << endl;
	int v;
	r = mq1.dequeue(v);
	cout << "allow dequeue: ";
	cout << r << endl;
}

void noDequeueIsEmpty()
{
	MyQueue<int> mq1 = MyQueue<int>();
	int v;
	bool r = !mq1.dequeue(v);
	cout << "no dequeue: " << r << endl;
}

void enqueueDequeue()
{
	MyQueue<int> mq1 = MyQueue<int>();
	int v;
	mq1.enqueue(31);
	mq1.dequeue(v);
	cout << "result 31: " << v << endl;
	cout << "is empty: " << mq1.isEmpty() << endl;
}

void enqueueTwiceDequeueTwice()
{
	MyQueue<int> mq1 = MyQueue<int>();
	bool r;
	r = mq1.enqueue(13);
	cout << "1st enqueue 13: " << r << endl;
	r = mq1.enqueue(24);
	cout << "2nd enqueue 24: " << r << endl;
	int v;
	r = mq1.dequeue(v);
	cout << "1st dequeue: " << r << " with value: " << v << endl;
	r = mq1.dequeue(v);
	cout << "2nd dequeue: " << r << " with value: " << v << endl;
}

void enqueueDequeueChar()
{
	MyQueue<char> mq1 = MyQueue<char>(2);
	cout << "mq1 is empty: " << mq1.isEmpty() << endl;
	bool r;
	r = mq1.enqueue('X');
	cout << "enqueue X: " << r << endl;
	r = mq1.enqueue('Y');
	cout << "2nd enqueue Y: " << r << endl;
	cout << "is full: " << mq1.isFull() << endl;
	char c;
	r = mq1.dequeue(c);
	cout << "1st dequeue: " << r << " with value: " << c << endl;
	r = mq1.dequeue(c);
	cout << "2nd dequeue: " << r << " with value: " << c << endl;
	cout << "is empty again: " << mq1.isEmpty() << endl;
}