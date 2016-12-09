#include"Stdafx.h"
#include"Table.h"
#include<time.h>
#include<math.h>
using namespace std;
int remain(int hand_brick_now[])
{
	int num = 0;
	for (int i = 1; i <= 29; i++)
	{
		num += hand_brick_now[i];
	}
	return num;
}
bool hupai(int hand_brick_more[])
{
	if (remain(hand_brick_more) == 0) return true;
	for (int i = 1; i <= 29; i++)
	{
		if (hand_brick_more[i] >= 3)
		{
			hand_brick_more[i] = hand_brick_more[i] - 3;
			if (hupai(hand_brick_more)) return true;
			hand_brick_more[i] = hand_brick_more[i] + 3;
		}
		if (hand_brick_more[i] >= 2)
		{
			hand_brick_more[i] = hand_brick_more[i] - 2;
			if (hupai(hand_brick_more)) return true;
			hand_brick_more[i] = hand_brick_more[i] + 2;
		}
		if (i <= 27)
		{
			if (hand_brick_more[i] * hand_brick_more[i + 1] * hand_brick_more[i + 2] > 0)
			{
				hand_brick_more[i] -= 1;
				hand_brick_more[i + 1] -= 1;
				hand_brick_more[i + 2] -= 1;
				if (hupai(hand_brick_more)) return true;
				hand_brick_more[i] += 1;
				hand_brick_more[i + 1] += 1;
				hand_brick_more[i + 2] += 1;
			}
		}
	}
	return false;
}
int ConvertPai(string _Pai)
{
	if ('b' == _Pai[0])return  0 + _Pai[1] - '0';
	if ('t' == _Pai[0])return 10 + _Pai[1] - '0';
	if ('w' == _Pai[0])return 20 + _Pai[1] - '0';
}
Table::Table()
{
	/*bool Pai[108] = { false };
	srand(unsigned(time(0)));
	int Tmp;
	string TmpChar(2, 0);
	for (int i = 0; i < 108;)
	{
		Tmp = rand() % 108;
		//Tmp = i;
		if (!Pai[Tmp])
		{
			i++;
			Pai[Tmp] = true;
			switch (Tmp / 36)
			{
			case 0:
				TmpChar[0] = 'b';
				TmpChar[1] = Tmp / 4 + 1 + '0';
				break;
			case 1:
				TmpChar[0] = 't';
				TmpChar[1] = (Tmp - 36) / 4 + 1 + '0';
				break;
			default:
				TmpChar[0] = 'w';
				TmpChar[1] = (Tmp - 72) / 4 + 1 + '0';
				break;
			}
			m_Mahjong_Init.push_back(TmpChar);
		}
	}*/
	m_Mahjong_Init.push_back("w1");//1
	m_Mahjong_Init.push_back("w1");
	m_Mahjong_Init.push_back("w1");
	m_Mahjong_Init.push_back("w1");

	m_Mahjong_Init.push_back("w2");//2
	m_Mahjong_Init.push_back("w2");
	m_Mahjong_Init.push_back("w2");
	m_Mahjong_Init.push_back("w2");

	m_Mahjong_Init.push_back("w3");//3
	m_Mahjong_Init.push_back("w3");
	m_Mahjong_Init.push_back("w3");
	m_Mahjong_Init.push_back("w3");

	m_Mahjong_Init.push_back("w4");//4
	m_Mahjong_Init.push_back("w4");
	m_Mahjong_Init.push_back("w4");
	m_Mahjong_Init.push_back("w4");

	m_Mahjong_Init.push_back("w5");//5
	m_Mahjong_Init.push_back("w5");
	m_Mahjong_Init.push_back("w5");
	m_Mahjong_Init.push_back("w5");

	m_Mahjong_Init.push_back("w6");//6
	m_Mahjong_Init.push_back("w6");
	m_Mahjong_Init.push_back("w6");
	m_Mahjong_Init.push_back("w6");

	m_Mahjong_Init.push_back("w7");//7
	m_Mahjong_Init.push_back("w7");
	m_Mahjong_Init.push_back("w7");
	m_Mahjong_Init.push_back("w7");

	m_Mahjong_Init.push_back("b8");//8
	m_Mahjong_Init.push_back("b8");
	m_Mahjong_Init.push_back("b8");
	m_Mahjong_Init.push_back("b8");

	m_Mahjong_Init.push_back("b9");//9
	m_Mahjong_Init.push_back("b9");
	m_Mahjong_Init.push_back("b9");
	m_Mahjong_Init.push_back("b9");

	m_Mahjong_Init.push_back("b1");//10
	m_Mahjong_Init.push_back("b1");
	m_Mahjong_Init.push_back("b1");
	m_Mahjong_Init.push_back("b1");

	m_Mahjong_Init.push_back("b2");//11
	m_Mahjong_Init.push_back("b2");
	m_Mahjong_Init.push_back("b2");
	m_Mahjong_Init.push_back("b2");

	m_Mahjong_Init.push_back("t1");//12
	m_Mahjong_Init.push_back("b3");
	m_Mahjong_Init.push_back("b3");
	m_Mahjong_Init.push_back("b3");

	m_Mahjong_Init.push_back("t1");//13
	m_Mahjong_Init.push_back("t1");
	m_Mahjong_Init.push_back("b4");
	m_Mahjong_Init.push_back("b4");

	m_Mahjong_Init.push_back("t1");//14
	m_Mahjong_Init.push_back("b5");
	m_Mahjong_Init.push_back("b5");
	m_Mahjong_Init.push_back("b5");

	m_Mahjong_Init.push_back("b6");//15
	m_Mahjong_Init.push_back("b6");
	m_Mahjong_Init.push_back("b6");
	m_Mahjong_Init.push_back("b6");

	m_Mahjong_Init.push_back("b7");//16
	m_Mahjong_Init.push_back("b7");
	m_Mahjong_Init.push_back("b7");
	m_Mahjong_Init.push_back("b7");

	m_Mahjong_Init.push_back("t8");//17
	m_Mahjong_Init.push_back("t8");
	m_Mahjong_Init.push_back("t8");
	m_Mahjong_Init.push_back("t8");
}
Table::~Table()
{
}
string Table::Deal(int who)
{
	string Output;
	Output = m_Mahjong_Init[m_HasHandout];
	m_Player[who - 1].m_LastDeal = Output;
	m_Player[who - 1].m_Pai.push_back(Output);
	if (Output[0] == 'b')
		m_Player[who - 1].m_iPai[Output[1] - '0'] += 1;
	if (Output[0] == 't')
		m_Player[who - 1].m_iPai[Output[1] - '0' + 10] += 1;
	if (Output[0] == 'w')
		m_Player[who - 1].m_iPai[Output[1] - '0' + 20] += 1;
	Output = '0' + Output + '0';
	m_HasHandout++;
	m_Player[who - 1].m_ZiMo = 1;
	m_output = Output;
	return Output;
}
string Table::Get(string behavior)
{
	int who = behavior[0] - '0';
	string tmp_pai = behavior.substr(1, 2);
	struct_paidui tmp_PaiDui;
	int tmp_ipai = ConvertPai(tmp_pai);
	if (behavior == "000g")//过牌
		return "000g";
	if (behavior[3] == '1')//打牌
	{
		if (m_Player[who - 1].m_iPai[tmp_ipai] < 1)
			return false;
		tmp_PaiDui.pai = tmp_pai;
		tmp_PaiDui.who = who;
		m_Player[who - 1].m_iPai[tmp_ipai]--;
		vector<string>::iterator it;
		for (it = m_Player[who - 1].m_Pai.begin(); it != m_Player[who - 1].m_Pai.end(); it++)
		{
			if (*it == tmp_pai)
			{
				m_Player[who - 1].m_Pai.erase(it);
				break;
			}
		}
		if (m_Hua != 0 && m_boolHua == true)
			m_boolHua = false;
		if (m_Hua != 0 && m_boolHua == false)
			m_Hua = 0;
		m_Player[who - 1].m_ZiMo = 0;
		m_output = behavior[0] + tmp_pai + '1';
		return m_output;
	}
	if (behavior[3] == '2')//胡牌
	{
		if (!IsHu(behavior[0] - '0' - 1, tmp_pai))
			return false;
		m_output = behavior[0] + tmp_pai + '2';
		return m_output;
	}
	if (behavior[3] == '7')//想碰牌
	{
		if (m_Player[who - 1].m_iPai[tmp_ipai] < 2)
			return false;
		m_output = behavior[0] + tmp_pai + '7';
		return m_output;
	}
	if (behavior[3] == '3')//暗杠
	{
		if (m_Player[who - 1].m_iPai[tmp_ipai] < 4)
			return false;
		string Push = tmp_pai + behavior[0] + '2';
		for (char i = 0; i < 4; i++)
			if (m_Player[i].m_Ontable&&i != who)
			{
				i = i + '0';
				Push = Push + i;
			}
		m_Player[who - 1].m_HasGang.push_back(tmp_pai + behavior[0] + '0');
		m_Player[who - 1].m_ZiMo = 0;
		m_Hua++;
		m_boolHua = true;
		m_output = behavior[0] + tmp_pai + '3';
		return m_output;
	}
	if (behavior[3] == '8')//想弯杠
	{
		if (m_Player[who - 1].m_LastDeal != tmp_pai)
			return false;
		bool bGang = false;
		for (unsigned int i = 0; i < m_Player[who - 1].m_HasPeng.size(); i++)
		{
			if (m_Player[who - 1].m_HasPeng[i] == tmp_pai)
			{
				bGang = true;
				break;
			}
		}
		if (bGang == false)
			return false;
		m_output = behavior[0] + tmp_pai + '8';
		return m_output;
	}
	if (behavior[3] == '9')//想直杠
	{
		if (m_PaiDui[m_PaiDui.size()-1].pai != tmp_pai)
			return false;
		if (m_Player[who - 1].m_iPai[tmp_ipai] < 3)
			return false;
		m_output = behavior[0] + tmp_pai + '9';
		return m_output;
	}
	return false;
}
string Table::Realize()
{
	int who = m_output[0] - '0';
	string tmp_pai = m_output.substr(1, 2);
	if (m_output[3] == '7')
	{
		m_output[3] = '4';
		m_Player[who - 1].m_HasPeng.push_back(tmp_pai);
		m_Hua = 0;
		m_Player[who - 1].m_ZiMo = 0;
		return m_output;
	}
	if (m_output[3] == '8')
	{
		m_output[3] = '5';
		string Push = tmp_pai + m_output[0] + '2';
		for (char i = 0; i < 4; i++)
			if (m_Player[i].m_Ontable&&i != who)
			{
				i = i + '0';
				Push = Push + i;
			}
		m_Player[who - 1].m_HasGang.push_back(Push);
		m_Player[who - 1].m_ZiMo = 0;
		m_Hua++;
		m_boolHua = true;
		return m_output;
	}
	if (m_output[3] == '9')
	{
		char cwho;
		cwho = m_PaiDui[m_PaiDui.size()-1].who + '0';
		m_Player[who - 1].m_HasGang.push_back(tmp_pai + cwho + '1');
		m_Player[who - 1].m_ZiMo = 0;
		m_Hua++;
		m_boolHua = true;
		m_output[3] = '6';
		return m_output;
	}
	return m_output;
}
bool Table::HumanIsHu(int who, string pai_)
{
	int sum_Dui = 0;
	bool hu = true;
	int iPai = ConvertPai(pai_);
	if (m_Player[who - 1].m_ZiMo == 0)
	{
		m_Player[who - 1].m_iPai[iPai]++;
		m_Player[who - 1].m_Pai.push_back(pai_);
	}
	if (0 == IsHuaZhu(who))
		hu = false;
	for (int i = 1; i < 30; i++)
	{
		if (m_Player[who - 1].m_iPai[i] == 2)
			sum_Dui++;
		if (m_Player[who - 1].m_iPai[i] == 4)
			sum_Dui += 2;
	}
	if (sum_Dui != 1 || sum_Dui != 7)
		hu = false;
	if (!hupai(m_Player[who - 1].m_iPai))
		hu = false;
	if (m_Player[who - 1].m_ZiMo == 0 && hu == false)
	{
		m_Player[who - 1].m_iPai[iPai]--;
		m_Player[who - 1].m_Pai.pop_back();
	}
	return hu;
}
bool Table::IsHu(int who, string pai_)
{
	int sum_Dui = 0;
	int iPai = ConvertPai(pai_);
	if (m_Player[who - 1].m_ZiMo == 0)
	{
		m_Player[who - 1].m_iPai[iPai]++;
		m_Player[who - 1].m_Pai.push_back(pai_);
	}
	if (0 == IsHuaZhu(who))
		return false;
	for (int i = 1; i < 30; i++)
	{
		if (m_Player[who - 1].m_iPai[i] == 2)
			sum_Dui++;
		if (m_Player[who - 1].m_iPai[i] == 4)
			sum_Dui += 2;
	}
	if (sum_Dui != 1 || sum_Dui != 7)
		return false;
	if (!hupai(m_Player[who - 1].m_iPai))
		return false;
	int rate = 1;
	rate *= IsQing(who)*IsBigPeng(who)*IsQiDui(who)*NumGang(who)*(int)pow(2, m_Hua);
	rate += m_Player[who - 1].m_ZiMo;
	m_Player[who - 1].m_Money += rate*m_Di;
	//for (int i = 0; i < m_Player[who-1].m_HasGang.size(); i++)
	//{
		//if (m_Player[who-1].m_HasGang[i][3] == ')
	//}
}
int Table::Result(int who)
{
	return m_Player[who - 1].m_Money;
}
int Table::GetHasHandout()
{
	return Table::m_HasHandout;
}
void Table::Restart()
{

}
int Table::IsHuaZhu(int who)
{
	int iB = 0, iT = 0, iW = 0;
	for (unsigned int i = 0; i < m_Player[who - 1].m_Pai.size(); i++)
	{
		if (m_Player[who - 1].m_Pai[i][0] == 'b')
			iB = 1;
		if (m_Player[who - 1].m_Pai[i][0] == 't')
			iT = 1;
		if (m_Player[who - 1].m_Pai[i][0] == 'w')
			iW = 1;
	}
	for (unsigned int i = 0; i < m_Player[who - 1].m_HasPeng.size(); i++)
	{
		if (m_Player[who - 1].m_HasPeng[i][0] == 'b')
			iB = 1;
		if (m_Player[who - 1].m_HasPeng[i][0] == 't')
			iT = 1;
		if (m_Player[who - 1].m_HasPeng[i][0] == 'w')
			iW = 1;
	}
	for (unsigned int i = 0; i < m_Player[who - 1].m_HasGang.size(); i++)
	{
		if (m_Player[who - 1].m_HasGang[i][0] == 'b')
			iB = 1;
		if (m_Player[who - 1].m_HasGang[i][0] == 't')
			iT = 1;
		if (m_Player[who - 1].m_HasGang[i][0] == 'w')
			iW = 1;
	}
	if (iB + iT + iW == 3)
		return 0;
	else
		return 1;
}
int Table::IsQing(int who)
{
	int iB = 0, iT = 0, iW = 0;
	for (unsigned int i = 0; i < m_Player[who - 1].m_Pai.size(); i++)
	{
		if (m_Player[who - 1].m_Pai[i][0] == 'b')
			iB = 1;
		if (m_Player[who - 1].m_Pai[i][0] == 't')
			iT = 1;
		if (m_Player[who - 1].m_Pai[i][0] == 'w')
			iW = 1;
	}
	for (unsigned int i = 0; i < m_Player[who - 1].m_HasPeng.size(); i++)
	{
		if (m_Player[who - 1].m_HasPeng[i][0] == 'b')
			iB = 1;
		if (m_Player[who - 1].m_HasPeng[i][0] == 't')
			iT = 1;
		if (m_Player[who - 1].m_HasPeng[i][0] == 'w')
			iW = 1;
	}
	for (unsigned int i = 0; i < m_Player[who - 1].m_HasGang.size(); i++)
	{
		if (m_Player[who - 1].m_HasGang[i][0] == 'b')
			iB = 1;
		if (m_Player[who - 1].m_HasGang[i][0] == 't')
			iT = 1;
		if (m_Player[who - 1].m_HasGang[i][0] == 'w')
			iW = 1;
	}
	if (iB + iT + iW == 1)
		return 4;
	else
		return 1;
}
int Table::IsBigPeng(int who)
{
	if (m_Player[who - 1].m_HasPeng.size() + m_Player[who - 1].m_HasGang.size() == 4)
		return 4;
	if (m_Player[who - 1].m_HasPeng.size() + m_Player[who - 1].m_HasGang.size() == 3)
	{
		for (int i = 1; i < 30; i++)
		{
			if (m_Player[who - 1].m_iPai[i] == 3)
				return 2;
		}
	}
	return 1;
}
int Table::IsDaiYao(int who)//待完成
{
	for (unsigned int i = 0; i < m_Player[who - 1].m_HasPeng.size(); i++)
		if (m_Player[who - 1].m_HasPeng[i][2] != 1 || m_Player[who - 1].m_HasPeng[i][2] != 9)
			return 1;
	for (unsigned int i = 0; i < m_Player[who - 1].m_HasGang.size(); i++)
		if (m_Player[who - 1].m_HasGang[i][2] != 1 || m_Player[who - 1].m_HasGang[i][2] != 9)
			return 1;
}
int Table::IsQiDui(int who)
{
	int sum_Dui = 0;
	int Rate_Long = 1;
	for (int i = 1; i < 30; i++)
	{
		if (m_Player[who - 1].m_iPai[i] == 2)
			sum_Dui++;
		if (m_Player[who - 1].m_iPai[i] == 4)
		{
			sum_Dui += 2;
			Rate_Long *= 4;
		}
	}
	if (sum_Dui == 7)
		return Rate_Long * 4;
	else
		return 1;
}
int Table::NumGang(int who)
{
	int num = 0;
	num = m_Player[who - 1].m_HasGang.size();
	for (int i = 1; i <= 29; i++)
	{
		if (4 == m_Player[who - 1].m_iPai[i])
			num++;
	}
	int ihua;
	for (unsigned int i = 0; i < m_Player[who - 1].m_HasPeng.size(); i++)
	{
		ihua = ConvertPai(m_Player[who - 1].m_HasPeng[i]);
		if (m_Player[who - 1].m_iPai[ihua] == 1)
			num++;
	}
	int result = 1;
	for (int i = 0; i < num; i++)
		result *= 2;
	return result;
}



