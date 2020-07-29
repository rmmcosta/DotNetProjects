// vectors.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <map>
using namespace std;

class Edge
{
public:
	Edge(int num, int distance) :num(num), distance(distance) {}
	int getNum() { return num; };
	int getDistance() { return distance; };
private:
	int num;
	int distance;
};

class Graph
{
public:
	void insertEdge(int, int, int);
	void printEdges();
private:
	map<int, vector<Edge*>> edges;
};

void Graph::insertEdge(int nodeOrigin, int nodeDestin, int distance)
{
	if (edges.find(nodeOrigin) != edges.end())
	{
		//already in map
		edges.find(nodeOrigin)->second.push_back(new Edge(nodeDestin, distance));
	}
	else
	{
		edges.insert(pair<int, vector<Edge*>>(nodeOrigin, { new Edge(nodeDestin, distance) }));
	}
}

int main()
{
	Graph* g = new Graph();
	g->insertEdge(0, 1, 2);
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
