﻿// Decompiled with JetBrains decompiler
// Type: Kerberos.Sots.Data.ScenarioFramework.StartContext
// Assembly: sots2_managed, Version=2.0.25104.1, Culture=neutral, PublicKeyToken=null
// MVID: 7BEBB796-D765-47D7-AFD1-D31EAC2170CD
// Assembly location: D:\Games\Sword of the Stars II Enhanced Edition\bin\x86\sots2_managed.dll

using Kerberos.Sots.Data.Xml;
using System.Xml;

namespace Kerberos.Sots.Data.ScenarioFramework
{
	public class StartContext : TriggerContext
	{
		internal const string XmlStartContextName = "StartContext";
		private const string XmlStartTurnName = "StartTurn";
		public int StartTurn;

		public override string XmlName
		{
			get
			{
				return nameof(StartContext);
			}
		}

		public override void AttachToXmlNode(ref XmlElement node)
		{
			XmlHelper.AddNode((object)this.StartTurn, "StartTurn", ref node);
		}

		public override void LoadFromXmlNode(XmlElement node)
		{
			this.StartTurn = XmlHelper.GetData<int>(node, "StartTurn");
		}
	}
}
