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

#include "..\main.h"
#include "..\FalloutEngine\Fallout2.h"
#include "..\Version.h"

#include "MainMenu.h"

namespace sfall
{

static DWORD MainMenuYOffset;
static DWORD MainMenuTextOffset;

static const DWORD MainMenuButtonYHookRet = 0x48184A;
static void __declspec(naked) MainMenuButtonYHook() {
	__asm {
		xor edi, edi;
		xor esi, esi;
		mov ebp, MainMenuYOffset;
		jmp MainMenuButtonYHookRet;
	}
}

static void __declspec(naked) MainMenuTextYHook() {
	__asm {
		add eax, MainMenuTextOffset;
		jmp dword ptr ds:[FO_VAR_text_to_buf];
	}
}

static const DWORD MainMenuTextRet = 0x4817B0;
static const char* VerString1 = "SFALL " VERSION_STRING;
static DWORD OverrideColour;
static void __declspec(naked) FontColour() {
	__asm {
		cmp OverrideColour, 0;
		je skip;
		mov eax, OverrideColour;
		retn;
skip:
		movzx eax, byte ptr ds:[0x6A8B33];
		or eax, 0x6000000;
		retn;
	}
}

static void __declspec(naked) MainMenuTextHook() {
	__asm {
		mov edi, [esp];
		sub edi, 12; //shift yposition up by 12
		mov [esp], edi;
		mov ebp, ecx;
		push eax;
		call FontColour;
		mov [esp+8], eax;
		pop eax;
		call fo::funcoffs::win_print_;
		call FontColour;
		push eax;//colour
		mov edx, VerString1;//msg
		xor ebx, ebx;//font
		mov ecx, ebp;
		dec ecx; //xpos
		add edi, 12;
		push edi; //ypos
		mov eax, dword ptr ds:[FO_VAR_main_window];//winptr
		call fo::funcoffs::win_print_;
		jmp MainMenuTextRet;
	}
}

void MainMenu::init() {
	int offset;

	if (offset = GetConfigInt("Misc", "MainMenuCreditsOffsetX", 0)) {
		SafeWrite32(0x481753, 15 + offset);
	}
	if (offset = GetConfigInt("Misc", "MainMenuCreditsOffsetY", 0)) {
		SafeWrite32(0x48175C, 460 + offset);
	}
	if (offset = GetConfigInt("Misc", "MainMenuOffsetX", 0)) {
		SafeWrite32(0x48187C, 30 + offset);
		MainMenuTextOffset = offset;
	}
	if (offset = GetConfigInt("Misc", "MainMenuOffsetY", 0)) {
		MainMenuYOffset = offset;
		MainMenuTextOffset += offset * 640;
		MakeJump(0x481844, MainMenuButtonYHook);
	}
	if (MainMenuTextOffset) {
		MakeCall(0x481933, MainMenuTextYHook, 1);
	}

	MakeJump(0x4817AB, MainMenuTextHook);
	OverrideColour = GetConfigInt("Misc", "MainMenuFontColour", 0);
	if (OverrideColour) {
		MakeCall(0x48174C, FontColour);
	}
}

}
