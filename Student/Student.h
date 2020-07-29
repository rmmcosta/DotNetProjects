#pragma once
#include <string>
#include <valarray>
#include <iostream>
using namespace std;
class Student
{
private:
	typedef valarray<double> ArrayDbl;
	string name;
	ArrayDbl grades;
	int count = -1;
public:
	Student(const string& s = "unknown", int size = 0) :name(s), grades(size) {}
	Student(const string& s, const ArrayDbl& arr) :name(s), grades(arr) { count = arr.size() - 1; }
	Student(const string& s, const double* values, int n) : name(s), grades(n) {
		count = n - 1;
		for (int i = 0; i < n; i++)
		{
			grades[i] = values[i];
		}
	}
	explicit Student(int n) :name("Nully"), grades(n) {} //prevent implicit conversions
	double operator[](int i) const { return grades[i]; }; //read
	double& operator[](int i) { return grades[i]; }; //write
	void addGrade(double d);
	double getAvg();
	friend ostream& operator<<(ostream&, Student&);
};
