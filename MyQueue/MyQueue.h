#pragma once
template <typename T>
class MyQueue
{
	class Node
	{
	private:
		Node* next;
		T value;
	public:
		Node(T v = 0) :value(v)
		{
			next = nullptr;
		}
		T getValue() const { return value; }
		void setValue(const T v) { value = v; }
		Node* getNext() const { return next; }
		void setNext(Node* n) { next = n; }
	};
private:
	enum { MAX = 5 };
	int maxElements;
	int nodes;
	Node* first;
	Node* last;
public:
	MyQueue(int limit = MAX) : maxElements(limit), nodes(0)
	{
		first = last = nullptr;
	}
	~MyQueue();
	bool enqueue(T);
	bool dequeue(T&);
	bool isFull();
	bool isEmpty();
};

template <typename T>
bool MyQueue<T>::enqueue(T v)
{
	if (!isFull())
	{
		if (isEmpty())
		{
			first = last = new Node(v);
		}
		else
		{
			Node* temp = new Node(v);
			last->setNext(temp);
			last = temp;
		}
		nodes++;
		return true;
	}

	else
		return false;
}

template <typename T>
bool MyQueue<T>::dequeue(T& v)
{
	if (!isEmpty())
	{
		Node* temp = first;
		v = temp->getValue();
		first = temp->getNext();
		delete temp;
		nodes--;
		return true;
	}
	else
	{
		v = -1;
		return false;
	}
}

template <typename T>
bool MyQueue<T>::isEmpty()
{
	return nodes == 0;
}

template <typename T>
bool MyQueue<T>::isFull()
{
	return nodes == maxElements;
}

template <typename T>
MyQueue<T>::~MyQueue()
{
	while (first != nullptr)
	{
		Node* temp = first;
		first = temp->getNext();
		delete temp;
	}
}