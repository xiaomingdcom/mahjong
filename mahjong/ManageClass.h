// ManageClass.h

#pragma once
#include"Table.h"
#include"majiangAI.h"
using namespace System;

namespace ManageClass {

	public ref class CTABLE
	{
		// TODO:  �ڴ˴���Ӵ���ķ�����
	public:
		CTABLE(); 
		~CTABLE();
		String^ Deal(int who);             //����
		String ^ManageClass::CTABLE::Get(String ^ behavior);
		bool IsHu(int who, String ^ pai);
		int Result(int who);
		int GetHasHandout();
		String^ Realize();
		bool HumanIsHu(int who, String ^ pai);
	private:
		Table *m_pImp;
	};
	public ref class CAI
	{
	public:
		CAI(int identity);
		~CAI();
		String ^respond_table(String ^message);
	private:
		AI *m_pImp;
	};
}
