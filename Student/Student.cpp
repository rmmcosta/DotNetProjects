#include "Student.h"

void Student::addGrade(double d)
{
	if (count < grades.size() || count < 0)
	{
		count++;
		grades[count] = d;
	}
	else
		cout << "Grades are full" << endl;
}

double Student::getAvg()
{
	if (count > -1)
		return grades.sum() / (count + 1);
	return 0.0;
}

ostream& operator<<(ostream& out, Student& s)
{
	out << "-------------------" << endl;
	out << s.name << endl;
	if (s.count < 0)
	{
		out << "no grades yet, but you can add " << s.grades.size();
	}
	else
	{
		for (int i = 0; i <= s.count; i++)
		{
			out << s.grades[i] << "\t";
		}
	}

	out << endl;
	return out;
}