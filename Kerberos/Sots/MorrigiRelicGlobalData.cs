﻿// Decompiled with JetBrains decompiler
// Type: Kerberos.Sots.MorrigiRelicGlobalData
// Assembly: sots2_managed, Version=2.0.25104.1, Culture=neutral, PublicKeyToken=null
// MVID: 7BEBB796-D765-47D7-AFD1-D31EAC2170CD
// Assembly location: D:\Games\Sword of the Stars II Enhanced Edition\bin\x86\sots2_managed.dll

namespace Kerberos.Sots
{
	public class MorrigiRelicGlobalData
	{
		public ResearchBonusData[] ResearchBonus = new ResearchBonusData[2];
		public int[] Rewards = new int[10];
		public int NumTombs;
		public int NumFighters;

		public enum ResearchBonusType
		{
			Captured,
			Destroyed,
			NumTypes,
		}

		public enum RelicType
		{
			Pristine1,
			Stealth1,
			Pristine2,
			Stealth2,
			Pristine3,
			Stealth3,
			Pristine4,
			Stealth4,
			Pristine5,
			Stealth5,
			NumTypes,
		}
	}
}
