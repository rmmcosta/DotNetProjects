#include "Student.h"

int main()
{
	Student s1 = Student("Ricardo", 3);
	cout << s1;
	s1.addGrade(14.5);
	cout << s1;
	s1.addGrade(15.5);
	cout << s1;
	cout << "average " << s1.getAvg() << endl;
	cout << "s1[0] " << s1[0] << endl;
	s1[2] = 18.1;
	cout << "s1[2] " << s1[2] << endl;
	Student s2;
	//s2 = 6; //not allowed thanks to the use of explicit in the constructor
	cout << s2;
	Student s3 = Student("Ana");
	cout << s3;
	//s3 = 7;//not allowed thanks to the use of explicit in the constructor
	cout << s3;
	Student s4 = Student(9);
	cout << s4;
	Student s5 = Student("Rui", { 10.5,13.4,14.1,9.8 });
	cout << s5;
	const double grades[2] = { 5.0,13.2 };
	Student s6 = Student("John", grades, 2);
	cout << s6;
	return 0;
}