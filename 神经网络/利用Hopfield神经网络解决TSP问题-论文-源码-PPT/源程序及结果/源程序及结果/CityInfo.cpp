#include "CityInfo.h"
//设置城市名字
void CityInfo::SetName(string na){
    Name=na;
}
//设置城市索引
void CityInfo::SetCityIndex(int index){
    CityIndex=index;
}
//设置Coordx
void CityInfo::SetCoordx(double x){
    Coordx=x;
}
//设置Coordy
void CityInfo::SetCoordy(double y){
    Coordy=y;
}
//得到城市名字
string CityInfo::GetName( ){
    return Name;
}
//得到城市下标索引
int CityInfo::GetCityIndex( ){
    return CityIndex;
}
//得到X坐标
double CityInfo::GetCoordx( ){
    return Coordx;
}
//得到Y坐标
double CityInfo::GetCoordy(){
    return Coordy;
}
//得到两个城市距离
double CityInfo::GetCityDis(CityInfo c1){
	return sqrt((c1.GetCoordx()-Coordx)*(c1.GetCoordx()-Coordx)+(c1.GetCoordy()-Coordy)*(c1.GetCoordy()-Coordy));
}