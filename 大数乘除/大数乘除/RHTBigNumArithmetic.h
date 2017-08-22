#pragma once
#include <string>
class CBigNumArithmetic
{
public:
	CBigNumArithmetic() {}
	~CBigNumArithmetic() {}
public:
	//std::string BNPlus(const std::string& _sLeft, const std::string& _sRight);
	std::string BNMinus(const std::string& _sLeft, const std::string& _sRight);
	std::string BNMultiply(const std::string& _sLeft, const std::string& _sRight);
	std::string BNDivide(const std::string& _sLeft, const std::string& _sRight, int _nLen = 30);
	int  BNCompare(const std::string& _sLeft, const std::string& _sRight);
protected:
	bool BNWipeoffZero(std::string& value);
	bool BNWipeoffZero1(std::string & value);
	bool BNStringPointPos(std::string& value, int& pos);
	//bool BNSetStringPoint(std::string& value, const int pos);
	bool BNTransformNoPoint(std::string& _sLeftValue, std::string& _sRightValue, int& _nResultPointPos, bool _bMulti = false, bool _bDivide = false);
	bool BNSetStringPoint(std::string & value, const int pos, const std::string & _sLeft, const std::string & _sRight);
	bool BNNumValidity(const std::string& _sValue);
	int pointNum(const std::string& value);
	bool test(std::string str);
};
