#include <string>
#include <iostream>
#include <algorithm>
#include "RHTBigNumArithmetic.h"

std::string CBigNumArithmetic::BNMinus(const std::string& _sLeft, const std::string& _sRight)
{
	if (_sLeft == "" || _sRight == "")
	{
		return "";
	}
	//先检测这个数是否合法（有非0-9的字符）
	if (!BNNumValidity(_sLeft) || !BNNumValidity(_sRight) || (pointNum(_sLeft) > 1) || (pointNum(_sRight) > 1))
	{
		return "";
	}

	std::string sTmpLeft = _sLeft;
	std::string sTmpRight = _sRight;
	std::string sResult = "";
	bool bIsNegative = false;

	if (BNCompare(sTmpLeft, sTmpRight) < 1)
	{
		bIsNegative = true;
		sTmpLeft = _sRight;
		sTmpRight = _sLeft;
	}

	int nResultPos = 0;
	BNTransformNoPoint(sTmpLeft, sTmpRight, nResultPos);
	reverse(sTmpLeft.begin(), sTmpLeft.end());
	reverse(sTmpRight.begin(), sTmpRight.end());
	int nLengh = sTmpLeft.length() > sTmpRight.length() ? sTmpRight.length() : sTmpLeft.length();

	int nIndex = 0;
	for (; nIndex < nLengh; nIndex++)
	{
		char cRes = sTmpLeft[nIndex] - sTmpRight[nIndex] + 48;
		sResult += cRes;
	}

	if (nLengh < sTmpLeft.length())
	{
		for (; nIndex < sTmpLeft.length(); nIndex++)
		{
			sResult += sTmpLeft[nIndex];
		}
	}

	if (nLengh < sTmpRight.length())
	{
		for (; nIndex < sTmpRight.length(); nIndex++)
		{
			sResult += sTmpRight[nIndex];
		}
	}

	int nCarry = 0;

	for (nIndex = 0; nIndex < sResult.length(); nIndex++)
	{
		int nValue = sResult[nIndex] - 48 + nCarry;
		if (nValue < 0)
		{
			sResult[nIndex] = nValue + 10 + 48;
			nCarry = -1;
		}
		else
		{
			sResult[nIndex] = nValue + 48;
			nCarry = 0;
		}
	}

	reverse(sResult.begin(), sResult.end());
	BNSetStringPoint(sResult, nResultPos, sTmpLeft, sTmpRight);
	BNWipeoffZero(sResult);

	if (bIsNegative)
	{
		std::string sTmp("-");
		sResult = sTmp + sResult;
	}

	return sResult;
}

std::string CBigNumArithmetic::BNMultiply(const std::string& _sLeft, const std::string& _sRight)
{
	if (_sLeft == "" || _sRight == "")
	{
		return "";
	}

	if (!BNNumValidity(_sLeft) || !BNNumValidity(_sRight) || (pointNum(_sLeft) > 1) || (pointNum(_sRight) > 1))
	{
		return "";
	}

	std::string sTmpLeft = _sLeft;
	std::string sTmpRight = _sRight;
	std::string sResult = "";
	int nResultPos = 0;
	BNTransformNoPoint(sTmpLeft, sTmpRight, nResultPos, true);

	reverse(sTmpLeft.begin(), sTmpLeft.end());
	reverse(sTmpRight.begin(), sTmpRight.end());
	int nLengh = sTmpLeft.length() + sTmpRight.length() + 1;
	int* pStr = new int[nLengh];
	char* pResult = new char[nLengh];
	memset(pStr, 0, sizeof(int)*nLengh);
	memset(pResult, 0, nLengh);
	int nIndex = 0;

	for (; nIndex < sTmpLeft.length(); nIndex++)
	{
		for (int nJ = 0; nJ < sTmpRight.length(); nJ++)
		{
			int cRes = (sTmpLeft[nIndex] - '0') * (sTmpRight[nJ] - '0');
			//std::cout << cRes << std::endl;
			pStr[nIndex + nJ] += cRes;
		}
	}

	int nCarry = 0;

	for (nIndex = 0; nIndex < nLengh; nIndex++)
	{
		int nValue = pStr[nIndex] + nCarry;
		pStr[nIndex] = nValue % 10 + '0';
		nCarry = nValue / 10;
	}

	for (int i = 0; i < nLengh; i++)
	{
		pResult[i] = pStr[i];
	}

	sResult.insert(0, pResult, nLengh);
	BNWipeoffZero(sResult);
	reverse(sResult.begin(), sResult.end());
	BNSetStringPoint(sResult, nResultPos,sTmpLeft, sTmpRight);

	return sResult;
}
int CBigNumArithmetic::pointNum(const std::string& value)
{
	int count = 0;
	int i = 0;
	while (value[i] != '\0')
	{
		if (value[i] == '.')
		{
			count++;
		}
		i++;
	}
	return count;
}

//判断字符串是否等于0
bool CBigNumArithmetic::test(std::string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		if (str.substr(i, 1) != "0")
			return false;
	}
	return true;
}

std::string CBigNumArithmetic::BNDivide(const std::string& _sLeft, const std::string& _sRight, int _nLen)
{
	if (_sLeft == "" || _sRight == "")
	{
		return "";
	}

	//先检测这个数是否合法（有非0-9的字符），除数不能为0，小数点的个数不能大于1，
	if (!BNNumValidity(_sLeft) || !BNNumValidity(_sRight) || (pointNum(_sLeft) > 1) || (pointNum(_sRight) > 1) || test(_sRight))
	{
		std::cout << "输入的数据不合法" << std::endl;
		return "";
	}

	std::string sTmpLeft = _sLeft;
	std::string sTmpRight = _sRight;
	std::string sResult = "";
	int nResultPos = 0;
	//去掉数据的小数点，并获取小数点的位置
	BNTransformNoPoint(sTmpLeft, sTmpRight, nResultPos, false, true);

	int nLengthLeft = sTmpLeft.length();
	int nLengthRight = sTmpRight.length();
	nResultPos = nLengthLeft - nResultPos;
	int nBeginPos = 0, nEndPos = 0, nBitNum = 0;
	std::string sTmp = sTmpLeft.substr(0, nLengthRight);

	while (nBitNum <= _nLen)
	{
		char nNum = 0;
		if (nBeginPos == 0 && BNCompare(sTmp, sTmpRight) > 0)
		{
			nBeginPos = sTmp.length() > sTmpRight.length() ? nLengthRight : nLengthRight - 1;
		}

		while (BNCompare(sTmp, sTmpRight) == 1)
		{
			sTmp = BNMinus(sTmp, sTmpRight);
			nNum++;
		}

		if (BNCompare(sTmp, sTmpRight) == 2)
		{
			sResult += (nNum + 1 + '0');
			sTmp = BNMinus(sTmp, sTmpRight);
			if (nLengthRight + nBitNum >= nLengthLeft)
			{
				break;
			}
		}
		else
		{
			sResult += (nNum + '0');
		}

		nBitNum++;
		if (nLengthRight + nBitNum <= nLengthLeft)
		{
			sTmp += sTmpLeft[nLengthRight + nBitNum - 1];
		}
		else
		{
			sTmp += '0';
		}
	}

	nEndPos = nLengthRight + nBitNum;
	//去掉开头是零的部分
	BNWipeoffZero(sResult);

	if (nEndPos > nResultPos)
	{
		//设置小数点位置
		if (nResultPos - nBeginPos <=0)
		{
			BNSetStringPoint(sResult, nResultPos - nBeginPos - 1, sTmpLeft, sTmpRight);
		}

		if(nResultPos - nBeginPos > 0)
		{
			if (nEndPos - nResultPos ==1)
			{
				BNSetStringPoint(sResult, (nEndPos - nResultPos), sTmpLeft, sTmpRight);
			}

			else
			{
				BNSetStringPoint(sResult, (nEndPos - 1 - nResultPos), sTmpLeft, sTmpRight);
			}
		}
	}
	else
	{
		BNSetStringPoint(sResult, 0, sTmpLeft, sTmpRight);
	}
	return sResult;
}

int  CBigNumArithmetic::BNCompare(const std::string& _sLeft, const std::string& _sRight)
{
	if (_sLeft == "" || _sRight == "")
	{
		return -1;
	}

	if (!BNNumValidity(_sLeft) || !BNNumValidity(_sRight) || (pointNum(_sLeft) > 1) || (pointNum(_sRight) > 1))
	{
		return -1;
	}


	std::string sTmpLeft = _sLeft;
	std::string sTmpRight = _sRight;
	int nResultPos = 0;
	BNTransformNoPoint(sTmpLeft, sTmpRight, nResultPos);

	if (sTmpLeft.length() > sTmpRight.length())
	{
		return 1;
	}

	if (sTmpLeft.length() < sTmpRight.length())
	{
		return 0;
	}

	for (int nIndex = 0; nIndex < sTmpLeft.length(); nIndex++)
	{
		if (sTmpLeft[nIndex] > sTmpRight[nIndex])
		{
			return 1;
		}
		if (sTmpLeft[nIndex] < sTmpRight[nIndex])
		{
			return 0;
		}
	}

	return 2;
}

bool CBigNumArithmetic::BNTransformNoPoint(std::string& _sLeftValue, std::string& _sRightValue, int& _nResultPointPos, bool _bMulti, bool _bDivide)
{
	int nLeftPointPos = 0, nRightPointPos = 0, nResultPos = 0;
	BNStringPointPos(_sLeftValue, nLeftPointPos);
	BNStringPointPos(_sRightValue, nRightPointPos);
	BNWipeoffZero(_sLeftValue);
	BNWipeoffZero(_sRightValue);

	if (_bMulti)
	{
		nResultPos = nLeftPointPos + nRightPointPos;
	}

	else
	{
		if (_bDivide)
		{
			if (nLeftPointPos < nRightPointPos)
			{
				for (int index = 0; index < nRightPointPos - nLeftPointPos; index++)
				{
					_sLeftValue += '0';
				}
			}

			else if (nLeftPointPos > nRightPointPos)
			{
				nResultPos = nLeftPointPos - nRightPointPos;
			}
			else
			{
				if (_sLeftValue.length() < _sRightValue.length())
				{
					nResultPos += (_sRightValue.length() - _sLeftValue.length());
					for (int nIndex = 0; nIndex < _sRightValue.length() - _sLeftValue.length(); nIndex++)
					{
						_sLeftValue += '0';
					}
				}
			}

		}
		else
		{
			nResultPos = nRightPointPos > nLeftPointPos ? nRightPointPos : nLeftPointPos;
			if (nResultPos > nLeftPointPos)
			{
				for (int index = 0; index < nResultPos - nLeftPointPos; index++)
				{
					_sLeftValue += '0';
				}
			}
			else if (nResultPos > nRightPointPos)
			{
				for (int index = 0; index < nResultPos - nRightPointPos; index++)
				{
					_sRightValue += '0';
				}
			}
		}
	}

	_nResultPointPos = nResultPos;
	return true;
}

bool CBigNumArithmetic::BNWipeoffZero(std::string& value)  //去掉开头是零的部分
{
	int index = 0;
	for (; index < value.length(); index++)
	{
		if (value[index] != '0')
		{
			break;
		}

	}

	value = value.substr(index);
	return true;
}



bool CBigNumArithmetic::BNStringPointPos(std::string& value, int& pos)
{
	std::string tmp = "";
	int index = 0;

	for (; index < value.length(); index++)
	{
		if (value[index] == '.')
		{
			pos = index;
			tmp = value.substr(0, index);
			break;
		}
	}

	if (index != value.size())
	{
		tmp += value.substr(pos + 1);
		pos = value.size() - pos - 1;
		value = tmp;
	}

	return true;
}


bool CBigNumArithmetic::BNSetStringPoint(std::string& value, const int pos, const std::string& _sLeft, const std::string& _sRight)
{
	std::string tmp = "";
	std::string sTmpLeft = _sLeft;
	std::string sTmpRight = _sRight;

	if (pos > 0)
	{
		if (pos == 1)
		{
			tmp = value.substr(0, value.length() - pos);
			tmp += '.';
			tmp += value.substr(value.length()-1);
			//value = tmp;
		    int index;

			for (index=0; index <tmp.length(); index++)
			{
				if (tmp[index] == '.')
				{
					break;
				}
			}
			std::string result= tmp.substr(index+1);		
			if (result.length() >20)
			{
				std::string lastresult;
				std::string tempresult = result.substr(0, 20);
				lastresult = value.substr(0, value.length() - pos);
				lastresult += '.';
				lastresult += tempresult;
				value = lastresult;
			}
			else
			{
				value = tmp;
			}
		}
		else
		{
			tmp = value.substr(0, value.length() - pos);
			tmp += '.';
			tmp += value.substr(value.length() - pos);
			//value = tmp;

			int index;
			for (index = 0; index <tmp.length(); index++)
			{
				if (tmp[index] == '.')
				{
					break;
				}
			}
			std::string result = tmp.substr(index + 1);
			if (result.length() >20)
			{
				std::string lastresult;
				std::string tempresult = result.substr(0, 20);
				lastresult = value.substr(0, value.length() - pos);
				lastresult += '.';
				lastresult += tempresult;
				value = lastresult;
			}
			else
			{
				value = tmp;
			}
		}
	
	}



    if (pos <0)
	{
		if (pos == -1 && sTmpLeft>sTmpRight)
		{
			int tmpPos;
			tmpPos = -pos;
			tmp = value.substr(0,tmpPos);
			tmp += '.';
			tmp += value.substr(tmpPos,value.length() - tmpPos);
			//value = tmp;
			int index;

			for (index = 0; index <tmp.length(); index++)
			{
				if (tmp[index] == '.')
				{
					break;
				}
			}
			std::string result = tmp.substr(index + 1);
			if (result.length() >20)
			{
				int tmpPos = -pos;
				std::string lastresult;
				std::string tempresult = result.substr(0, 20);
				lastresult = value.substr(0, tmpPos);
				lastresult += '.';
				lastresult += tempresult;
				value = lastresult;
			}
			else
			{
				value = tmp;
			}

		}
	   if(pos==-1&&sTmpLeft<sTmpRight)
		{
			tmp += "0.";
			for (int index = 1; index < abs(pos); index++)
			{
				tmp += '0';
			}
			tmp += value;
			value = tmp;
			int index;

			for (index = 0; index <tmp.length(); index++)
			{
				if (tmp[index] == '.')
				{
					break;
				}
			}
			std::string result = tmp.substr(index + 1);
			if (result.length() >20)
			{
				std::string lastresult;
				std::string tempresult = result.substr(0, 20);
				lastresult += "0.";		
				lastresult += tempresult;
				value = lastresult;
			}
			else
			{
				value = tmp;
			}

		}
	   if (pos != -1 && pos < 0)
	   {
		   tmp += "0.";
		   for (int index = 1; index < abs(pos); index++)
		   {
			   tmp += '0';
		   }
		   tmp += value;
		  // value = tmp;

		   int index;
		   for (index = 0; index <tmp.length(); index++)
		   {
			   if (tmp[index] == '.')
			   {
				   break;
			   }
		   }
		   std::string result = tmp.substr(index + 1);
		   if (result.length() >20)
		   {
			   std::string lastresult;
			   std::string tempresult = result.substr(0, 20);
			   lastresult += "0.";		
			   lastresult += tempresult;
			   value = lastresult;
		   }
		   else
		   {
			   value = tmp;
		   }

	   }
	
	}
	return true;
}

bool CBigNumArithmetic::BNNumValidity(const std::string& value)
{
	bool flag = false;
	for (int index = 0; index < value.length(); index++)
	{
		if (value[index] > 47 && value[index] < 58|| value[index] == '.')
		{
			flag= true;
		}
		else
		{
			flag= false;
		}
	}
	return flag;
	
}

int main()
{
	CBigNumArithmetic c;
	std::string c1, c2;
	std::cin >> c1 >> c2;
	std::cout << c.BNDivide(c1, c2) << std::endl;
	/*std::string c3, c4;
	std::cin >> c3 >> c4;
	std::cout << c.BNMultiply(c3, c4) << std::endl;*/

	system("pause");
	return 0;
}

