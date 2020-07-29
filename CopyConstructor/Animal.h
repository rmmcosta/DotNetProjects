#pragma once
#ifndef ANIMAL_H
#define ANIMAL_H
class Animal
{
private:
	int age;
	bool isCopy;
public:
	Animal(int age = 0) :age(age) { isCopy = false; };
	Animal(const Animal&);
	const void printAge() const;
	const bool getIsCopy() const;
};
#endif

