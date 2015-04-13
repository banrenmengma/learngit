#ifndef _CITYINFO_H_
#define _CITYINFO_H_

#include<string>
#include<math.h>
using namespace std;

class CityInfo{
private:
	string Name;
	int CityIndex;
	double Coordx;
	double Coordy;

public:
	void SetName(string na);
	void SetCityIndex(int index);
	void SetCoordx(double x);
	void SetCoordy(double y);
	string GetName();
	int GetCityIndex();
	double GetCoordx();
	double GetCoordy();
	double GetCityDis(CityInfo c1);
};

#endif