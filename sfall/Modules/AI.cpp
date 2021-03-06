/*
 *    sfall
 *    Copyright (C) 2012  The sfall team
 *
 *    This program is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *    This program is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *    GNU General Public License for more details.
 *
 *    You should have received a copy of the GNU General Public License
 *    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

#include <unordered_map>

#include "..\main.h"

#include "AI.h"
#include "..\FalloutEngine\Fallout2.h"
#include "..\SafeWrite.h"

namespace sfall 
{

typedef std::unordered_map<DWORD, DWORD> :: const_iterator iter;

static std::unordered_map<DWORD,DWORD> targets;
static std::unordered_map<DWORD,DWORD> sources;

static DWORD combatDisabled;
static std::string combatBlockedMessage;

DWORD _stdcall AIGetLastAttacker(DWORD target) {
	iter itr=sources.find(target);
	if(itr==sources.end()) return 0;
	else return itr->second;
}

DWORD _stdcall AIGetLastTarget(DWORD source) {
	iter itr=targets.find(source);
	if(itr==targets.end()) return 0;
	else return itr->second;
}

static void __fastcall CombatAttackHook(DWORD source, DWORD target) {
	sources[target] = source;
	targets[source] = target;
}

static void __declspec(naked) combat_attack_hook() {
	_asm {
		push ecx;
		push edx;
		push eax;
		mov  ecx, eax;         // source
		call CombatAttackHook; // edx - target
		pop  eax;
		pop  edx;
		pop  ecx;
		jmp  fo::funcoffs::combat_attack_;
	}
}

static void _stdcall CombatBlocked() {
	fo::func::display_print(combatBlockedMessage.c_str());
}

static const DWORD BlockCombatHook1Ret1=0x45F6B4;
static const DWORD BlockCombatHook1Ret2=0x45F6D7;
static void __declspec(naked) BlockCombatHook1() {
	__asm {
		mov eax, combatDisabled;
		test eax, eax;
		jz end;
		call CombatBlocked;
		jmp BlockCombatHook1Ret2;
end:
		mov eax, 0x14;
		jmp BlockCombatHook1Ret1;
	}
}

static void __declspec(naked) BlockCombatHook2() {
	__asm {
		mov eax, dword ptr ds:[FO_VAR_intfaceEnabled];
		test eax, eax;
		jz end;
		mov eax, combatDisabled;
		test eax, eax;
		jz succeed;
		pushad;
		call CombatBlocked;
		popad;
		xor eax, eax;
		jmp end;
succeed:
		inc eax;
end:
		retn;
	}
}

void _stdcall AIBlockCombat(DWORD i) {
	combatDisabled = i ? 1 : 0;
}

void AI::init() {
	//HookCall(0x42AE1D, ai_attack_hook);
	//HookCall(0x42AE5C, ai_attack_hook);
	HookCall(0x426A95, combat_attack_hook);
	HookCall(0x42A796, combat_attack_hook);
	MakeJump(0x45F6AF, BlockCombatHook1);
	HookCall(0x4432A6, BlockCombatHook2);
	combatBlockedMessage = Translate("sfall", "BlockedCombat", "You cannot enter combat at this time.");
}

void _stdcall AICombatStart() {
	targets.clear();
	sources.clear();
}

void _stdcall AICombatEnd() {
	targets.clear();
	sources.clear();
}

}
