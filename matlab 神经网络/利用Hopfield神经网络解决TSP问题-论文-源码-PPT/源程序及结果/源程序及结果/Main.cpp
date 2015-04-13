#include <math.h>
#include <ctype.h>
#include <ctime>
#include<iostream>
#include<vector>
#include<fstream>
#include<string>
#include<cassert>
#include "CityInfo.h"

using namespace std;

#define G(x) ((1.0+tanh(x/u0))/2.0)  //入口点函数
#define pi 3.1415926
double u0=0.02;
/*
* 函数介绍：城市的初始化设置，
			resize(Num)根据输入的城市数设置城市数组，
			SetCityIndex(i)依次设置某个城市的索引ID，
			SetCoordx随机取值，设置某城市在X-Y轴上的X坐标
* 输入参数：Num,设置城市结点的个数
* 返回值 ：返回一个初始化好的城市数组
*/


//通过随机函数得到(0,1)之间的城市坐标
vector<CityInfo>CreateCities(int Num){
	vector<CityInfo> City;
	City.resize(Num);//重置城市的规模
	for(int i=0;i<Num;i++){
		City[i].SetCityIndex(i);//设置城市索引，也即是第i个城市
		double t=((rand())%32767)/(float)32767;//得到(0,1)之间的一个数
		City[i].SetCoordx(t);//设置城市的x坐标
		t=((rand())%32767)/(float)32767;
		City[i].SetCoordy(t);//设置城市的y坐标
	}
	return City;
}
/*
* 函数介绍：计算偏置bias
			
* 输入参数：City,城市数组
* 返回值 ：返回一个偏置数组
*/
/*
  设置城市的偏置变量
  采用随机扰动的方法设置初始状态可以获得正确解，
  但随机扰动缺乏网络的整体特性，因而不易获得较
  好的解，并且收敛效率也不高。改进的方法是采用
  给初始状态增加一个偏置,偏置公式为bias(i,j)=cos(atan((y-0.5)/(x-0.5))+2*pi*(j-1)*sqrt((x-0.5)*(x-0.5)+(y-0.5)*(y-0.5))/N)
*/

vector<double> SetBias(vector<CityInfo>City){
	vector<double> Bias;
	double d1=0.0,d2=0.0,d3=0.0,d4=0.0;
	//遍历所有城市
	for(int i=0;i<City.size();i++){
		d1=(City[i].GetCoordy()-0.5)/(City[i].GetCoordx()-0.5);
		d2=atan(d1); //反正切函数
		d3=hypot(City[i].GetCoordx()-0.5,City[i].GetCoordy()-0.5);//平方根
		for(int j=0;j<City.size();j++){
			d4=d2+(j-1)*2*pi*d3/(float)City.size();//d4就是偏置值
			Bias.push_back(cos(d4));//往偏置向量中插入此次计算出来的偏置值
		}
	}
	return Bias;//返回偏置向量
}
/*
* 函数介绍：计算能量E，其中J1,J2,J3,J，E都是按照对应的公式E=A*J1/2+B*J2/2+C*J3/2+D*J/2求解计算而来
			
* 输入参数：city城市数组，u,v置换矩阵即神经元状态， ABCD为能量公式计算系数
* 返回值 ：返回能量E
*/
double CompEngery(vector<CityInfo> city,vector<double> & u,vector<double> & v,double A,double B,double C,double D){
	int i,j,x,y;  
	double delt=0,E=0,k=0,h=0.01;
	double J1=0.0,J2=0.0,J3=0.0,J=0.0;
	int Num=city.size();//获得城市的数目
	///计算J1,也是约束条件，即在换位矩阵中，每一城市行x 至多含有一个“1”，其余都是“0”，
	for(x=0;x<Num;x++)   
		for(i=0;i<Num-1;i++)
			//j从i+1开始是为了避免j=i的情况
			for(j=i+1;j<Num;j++)
				J1+=v[x*Num+i]*v[x*Num+j];//J1+=v[x][i]*v[x][j]
    //计算J2,也是约束条件，即在置换矩阵中，每一城市列y 至多含有一个“1”，其余都是“0”，
	for(i=0;i<Num;i++)
		for(x=0;x<Num-1;x++)
			//y从x+1开始是为了避免y=x的情况
			for(y=x+1;y<Num;y++)
				J2+=v[x*Num+i]*v[y*Num+i];//j2+=v[x][i]*v[y][i]
    //计算J3,其中K 是计算置换矩阵的总和；J3也是约束条件，即在置换矩阵中,只能有N个1；最后一步平方，是为了防止出现负数
	for(x=0;x<Num;x++)
		for(i=0;i<Num;i++)      
			k+=v[x*Num+i];    //计算能量系数,k+=v[x][i]
	J3=(k-Num)*(k-Num);
	/*
	计算J,可行旅行路线的路程
	J=min(sum(d[x][y]*v[x][i]*(v[y][i+1]+v[y][i-1]))),y!=x;
	v[x][i]的行下标x是城市编号，列下标i表示城市x在旅行顺序中的位置，下标对N取模运算
	*/
	for(x=0;x<Num;x++){
		for(y=0;y<Num;y++){    
			for(i=0;i<Num;i++){  
				if(i==0)  
					//下标对N取模运算,由于i-1<0,而i从0开始取值,所以取模后i为Num-1
					J+=city[x].GetCityDis(city[y])*v[x*Num+i]*(v[y*Num+Num-1]+v[y*Num+i+1]); //J+=dis[x][y]*v[x][i]*(v[y][N-1]+v[y][i+1]
				else if (i==Num-1)   
					J+=city[x].GetCityDis(city[y])*v[x*Num+i]*(v[y*Num+i-1]+v[y*Num]);//J+=dis[x][y]*v[x][i]*(v[y][i-1]+v[y][0])
				else             
					J+=city[x].GetCityDis(city[y])*v[x*Num+i]*(v[y*Num+i-1]+v[y*Num+i+1]);  
			}        
		}    
	}      
	//得到能量函数
	E=A*J1/2+B*J2/2+C*J3/2+D*J/2;

	/*
		取神经元的I/O函数为S型函数，可以求得TSP问题的网络方程
		delt=-u[x][i]-A*Sum(v[x][j])-B*Sum(v[y][j]-C*(Sum(v[x][i])-N)-D*Sum(d[x][y])(v[y][i+1]+v[y][i-1]));
		u[x*Num+i]=h*delt;
		v[x][i]通过G(u[u][i])求得
	*/
	for(x=0;x<Num;x++){
		for(i=0;i<Num;i++){
			delt=0-u[x*Num+i];//u[x][i]

			for(j=0;j<Num;j++){
				if(i==j)
					continue;
				delt-=A*v[x*Num+j]; //v[x][j]
			}

			for(y=0;y<Num;y++){
				if(x==y) 
					continue;  
				delt-=B*v[y*Num+i];   //v[y][i]
			} 

			delt-=C*(k-Num);//k=Sum(v[x][i])
			//i需对N取模
			for(y=0;y<Num;y++){
				if(i==0)     
					delt-=D*city[x].GetCityDis(city[y])*(v[y*Num+Num-1]+v[y*Num+i+1]);   
				else if (i==Num-1)   
					delt-=D*city[x].GetCityDis(city[y])*(v[y*Num+i-1]+v[y*Num]);    
				else             
					delt-=D*city[x].GetCityDis(city[y])*(v[y*Num+i-1]+v[y*Num+i+1]);
			}
			u[x*Num+i]+=h*delt;//缩小系数比例
			v[x*Num+i]=G(u[x*Num+i]); //v[x][i]=G(u[x][i])
		}
	}
	return E;
}
/*
* 函数介绍：验证路径数组中，路径是否合理正确
			
* 输入参数：Router路径数组，它是一维的，数组里存的是依次访问的城市号
* 返回值 ：返回路径是否有效的信息
*/
bool ReVaild(vector<int> Router){
	for(int i=0;i<Router.size();i++){
		for(int j=i+1;j<Router.size();j++){			
			if(Router[i]==Router[j] || Router[i]<0 || Router[i]>Router.size()-1)
				return false;			
		}
	}
	return true;
}
/*
* 函数介绍：输出城市数组的信息；即输出城市的数量，X-Y坐标			
* 输入参数：city城市数组
*/
void PrintCity(vector<CityInfo> City){
	for(int i=0;i<City.size();i++)
		cout<<City[i].GetCityIndex()<<"	"<<City[i].GetCoordx()<<"	"<<City[i].GetCoordy()<<endl;
}

void HOP_TSP(int Num)
{
	ofstream outfile;//以输出方式打开文件 
	string name;
	vector<CityInfo>City;//城市向量
    vector<int>Router;//路径向量
	vector<double>InitBias;//初始偏置向量
	vector<double>InSig,OutSig;
	int CityNum=Num;
	double TotalDis=0.0,E=0.0,u0=0.02;
double MinTotalDis;
vector<int>MinRouter;//最小的路径向量
	City=CreateCities(CityNum);//创建城市数目
	
	InitBias=SetBias(City);//设置偏置变量
	Router.resize(CityNum);//路径重新设置城市规模

	//InSig即是上面的求能量函数中的换位矩阵U向量，OutSig是求能量函数中的换位矩阵V向量
	InSig.resize(CityNum*CityNum);//创建一个CityNum*CityNum矩阵的向量
	OutSig.resize(CityNum*CityNum);
	
	name="result.txt";
	outfile.open(name.c_str(),ofstream::app);//name.c_str()返回const char*类型(可读不可改)的指向字符数组的指针
	if (!outfile){
		cout<<"Output file "<<name<<" opening failed!"<<endl;
		exit(1);
	}
	else{
		outfile<<CityNum<<endl;//将城市的数目CityNum输入到result.txt中去
		outfile<<CityNum<<"个城市坐标"<<endl;
		for(int i=0;i<City.size();i++)
			outfile<<"第"<<City[i].GetCityIndex()<<"城市"<<"  "<<City[i].GetCoordx()<<"	"<<City[i].GetCoordy()<<endl;//将城市的(x,y)坐标信息输入到文件中去
		outfile<<"**********************************************"<<endl;
		//通过for循环改变A,B，C的参数值
		for(double dd=0.05;dd<0.31;dd+=0.05){
			MinTotalDis=20.0;///++

			cout<<"--------------------------"<<"A=B=C="<<dd<<"	"<<"D=0.1"<<"-------------------------"<<endl;
			outfile<<"--------------------------"<<"A=B=C="<<dd<<"	"<<"D=0.1"<<"-------------------------"<<endl;
			for(int it=0;it<20;it++){
				int ItNum=0;
				
				double u00=0-u0*log(CityNum-1)/2;
				for(i=0;i<CityNum*CityNum;i++){  
					double t=((rand())%32767)/(float)32767;
					//求初始换位矩阵
					InSig[i]=u00+0.001*(t*2-1)*InitBias[i];
					OutSig[i]=G(InSig[i]); //G()是罚函数
				}
				double temp=0;
				assert(InSig.size()==CityNum*CityNum);//断言,异常处理的一种高级形式,表示布尔表达式，假设为真
				assert(OutSig.size()==CityNum*CityNum);
				
				do{
					E=CompEngery(City,InSig,OutSig,dd,dd,dd,0.1);//求能量函数
				if(fabs(E-temp)<1e-20)
					break;
					temp=E;
					ItNum++;
				}while(ItNum<9000);
				cout<<"iterations="<<ItNum<<"	"<<"E="<<E<<endl;//返回迭代的次数和能量值
			
				int i,j,k=0;
				int count=0;
				
				TotalDis=0.0;//TSP总距离
				//通过for循环得到换位矩阵中首列出现的城市的编号，即第一个城市的编号，保存在Router[0]中
				for(j=0;j<CityNum;j++){
					if(OutSig[j*CityNum]>=0.2){
						k=j;
						Router[count]=j;//Router用于保存顺次旅行城市的编号
						count+=1;
						break;
					}
				}
				//通过for循环得到换位矩阵其它列出现的城市编号，保存在Router[i]中，同时得到城市的旅行总距离，保存在TotalDis中
				for(i=1;i<CityNum;i++){
					for(j=0;j<CityNum;j++){
						if(OutSig[j*CityNum+i]>=0.2){//凡置换矩阵中，大于0.2的状态，认为是正确的路径结点
							Router[count]=j;
							count+=1;
							//::k表示置换矩阵中某一列中正确路径结点的行号，j为K所相邻列中正确路径结点的行号；两个相邻的行号，才能确定两点间的距离
							TotalDis+=City[k].GetCityDis(City[j]); 	         
							k=j;  
							break;    
						}
					}
				}
				TotalDis+=City[k].GetCityDis(City[Router[0]]);

				if(ReVaild(Router)){
					if(TotalDis<MinTotalDis)////++
					{
						MinTotalDis = TotalDis;
						MinRouter = Router;
					}

					cout<<"right path"<<endl; //如果路径有效的话
					cout<<"TotaoDis="<<TotalDis<<endl; 
					for(int i=0;i<CityNum;i++)
						cout<<Router[i]<<"	";
						//输入到文件中
						outfile<<endl;
						outfile<<"iterations="<<ItNum<<"	"<<"E="<<E<<endl;//输出迭代次数及能量函数到文件中
						
						outfile<<it+1<<"	";//对输出的次数进行标号
						outfile<<"right path"<<endl; //显示路径有效
						outfile<<"TotaoDis="<<TotalDis<<endl;//输出总距离
						
						//通过for循环输出顺次旅行城市的编号
						for(i=0;i<CityNum;i++)
							outfile<<Router[i]<<"	";
						outfile<<endl;
					}
				else{
					cout<<"wrong path"<<endl;//显示路径非法
				}

			}
			if(MinTotalDis!=20.0)
			{
				cout<<endl;
				outfile<<"最短路径长度："<<MinTotalDis;
				outfile<<"	最小路径为：";
				cout<<"最短路径长度："<<MinTotalDis;
				cout<<"	最小路径为：";
				for(int ki=0;ki<CityNum;ki++)
				{
					cout<<MinRouter[ki]<<"  ";
					outfile<<MinRouter[ki]<<"  ";
				}
				cout<<endl;
			}
		}
	}
	outfile<<"**********************************************"<<endl;
	outfile<<endl<<endl<<endl;
	outfile.close();
}

void main(){
	clock_t begin,finish;
	srand((unsigned int) time(NULL));//用于计算运行时间
	begin=clock();//获取系统的初始时间
	int Num;//用于保存城市数目
	cout<<"CityNum:	";
	cin>>Num;
	HOP_TSP(Num);//调用Hopfild-Tsp处理程序
	finish = clock();//结束时间
}