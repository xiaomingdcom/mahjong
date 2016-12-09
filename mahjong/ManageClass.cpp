// 这是主 DLL 文件。

#include "stdafx.h"
#include "ManageClass.h"
#include <iostream>
using namespace Runtime::InteropServices;

void MarshalString(String ^ s, string& os) {
	using namespace Runtime::InteropServices;
	const char* chars =
		(const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();
	os = chars;
	Marshal::FreeHGlobal(IntPtr((void*)chars));
}
ManageClass::CTABLE::CTABLE()
{
	m_pImp = new Table();
}
ManageClass::CTABLE::~CTABLE()
{
	throw gcnew System::NotImplementedException();
	delete m_pImp;
}
String^ ManageClass::CTABLE::Deal(int who)
{
	return gcnew String(m_pImp->Deal(who).c_str());
}
String ^ManageClass::CTABLE::Get(String ^ behavior)
{
	string str_behavior;
	MarshalString(behavior, str_behavior);
	return gcnew String(m_pImp->Get(str_behavior).c_str());
}
bool ManageClass::CTABLE::IsHu(int who, String ^pai)
{
	string str_pai;
	MarshalString(pai, str_pai);
	return m_pImp->IsHu(who, str_pai);
}
int ManageClass::CTABLE::Result(int who)
{
	return m_pImp->Result(who);
}
int ManageClass::CTABLE::GetHasHandout()
{
	return m_pImp->GetHasHandout();
}
String^ ManageClass::CTABLE::Realize()
{
	return gcnew String(m_pImp->Realize().c_str());
}
ManageClass::CAI::CAI(int identity)
{
	m_pImp = new AI(identity);
}
ManageClass::CAI::~CAI()
{
	delete m_pImp;
}
String ^ ManageClass::CAI::respond_table(String ^ message)
{
	string str_message;
	MarshalString(message, str_message);
	return gcnew String(m_pImp->respond_table(str_message).c_str());
}
bool ManageClass::CTABLE::HumanIsHu(int who, String ^pai)
{
	string str_pai;
	MarshalString(pai, str_pai);
	return m_pImp->HumanIsHu(who, str_pai);
}