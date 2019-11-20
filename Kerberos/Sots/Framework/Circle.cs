﻿// Decompiled with JetBrains decompiler
// Type: Kerberos.Sots.Framework.Circle
// Assembly: sots2_managed, Version=2.0.25104.1, Culture=neutral, PublicKeyToken=null
// MVID: 7BEBB796-D765-47D7-AFD1-D31EAC2170CD
// Assembly location: D:\Games\Sword of the Stars II Enhanced Edition\bin\x86\sots2_managed.dll

using System;
using System.Runtime.InteropServices;

namespace Kerberos.Sots.Framework
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Circle
	{
		public static Vector2 CalcPoint(float radius, float theta)
		{
			return new Vector2(radius * (float)Math.Cos((double)theta), radius * (float)Math.Sin((double)theta));
		}
	}
}
