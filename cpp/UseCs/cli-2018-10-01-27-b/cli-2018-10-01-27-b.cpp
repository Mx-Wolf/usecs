// cli-2018-10-01-27-b.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
struct Tuple {
public:
	Tuple(int a[]);
	int GetMax();
	int GetDif();
private:
	int Max;
	int Dif;
	int InitDif(int b1, int b2);
	void Collect(int a[]);
};
int reduce(int auxDif, int dif);
int main()
{
	int maxSum = 0;
	int auxDif = 0;
	int n;
	std::cin >> n;
	while (0 < n--)
	{
		int a[3];
		std::cin >> a[0] >> std::skipws >> a[1] >> std::skipws >> a[2];
		Tuple tuple(a);
		maxSum += tuple.GetMax();
		auxDif = reduce(auxDif, tuple.GetDif());
	}
	if (maxSum % 3 != 0) {
		std::cout << maxSum;
	}
	else {
		if (auxDif > 0) {
			std::cout << (maxSum - auxDif);
		}
		else {
			std::cout << 0;
		}
	}
}

Tuple::Tuple(int a[])
{
	Max = 0;
	Dif = 0;
	Collect(a);
}

int Tuple::GetMax()
{
	return Max;
}

int Tuple::GetDif()
{
	return Dif;
}

void Tuple::Collect(int a[])
{
	//012
	//021
	//201
	//102
	//120
	//210

	if (a[0] > a[1]) {//01
		if (a[0] > a[2]) {
			if (a[1] > a[2]) {//012
				Max = a[0];
				Dif = InitDif(a[1], a[2]);
			}
			else {//021
				Max = a[0];
				Dif = InitDif(a[2], a[1]);
			}
		}
		else {//201
			Max = a[2];
			Dif = InitDif(a[0], a[1]);
		}
	}
	else {//10
		if (a[1] > a[2]) {
			if (a[0] > a[2]) {//102
				Max = a[1];
				Dif = InitDif(a[0], a[2]);
			}
			else {//120
				Max = a[1];
				Dif = InitDif(a[2], a[0]);
			}
		}
		else {//210
			Max = a[2];
			Dif = InitDif(a[1], a[0]);
		}
	}
}

int Tuple::InitDif(int b1, int b2)
{
	int c1 = Max - b1;
	if (c1 % 3 != 0) return c1;
	int c2 = Max - b2;
	if (c2 % 3 != 0) return c2;
	return 0;
}

int reduce(int auxDif, int dif)
{
	if (dif % 3 != 0) {
		if (auxDif > 0) {
			if (auxDif > dif) {
				return dif;
			}
		}
		else {
			return dif;
		}
	}
	return auxDif;
}
