﻿// Decompiled with JetBrains decompiler
// Type: Meebey.SmartIrc4net.IrcCommands
// Assembly: sots2_managed, Version=2.0.25104.1, Culture=neutral, PublicKeyToken=null
// MVID: 7BEBB796-D765-47D7-AFD1-D31EAC2170CD
// Assembly location: D:\Games\Sword of the Stars II Enhanced Edition\bin\x86\sots2_managed.dll

using System;

namespace Meebey.SmartIrc4net
{
	public class IrcCommands : IrcConnection
	{
		private int _MaxModeChanges = 3;

		protected int MaxModeChanges
		{
			get
			{
				return this._MaxModeChanges;
			}
			set
			{
				this._MaxModeChanges = value;
			}
		}

		public void SendMessage(SendType type, string destination, string message, Priority priority)
		{
			switch (type)
			{
				case SendType.Message:
					this.RfcPrivmsg(destination, message, priority);
					break;
				case SendType.Action:
					this.RfcPrivmsg(destination, "\x0001ACTION " + message + "\x0001", priority);
					break;
				case SendType.Notice:
					this.RfcNotice(destination, message, priority);
					break;
				case SendType.CtcpReply:
					this.RfcNotice(destination, "\x0001" + message + "\x0001", priority);
					break;
				case SendType.CtcpRequest:
					this.RfcPrivmsg(destination, "\x0001" + message + "\x0001", priority);
					break;
			}
		}

		public void SendMessage(SendType type, string destination, string message)
		{
			this.SendMessage(type, destination, message, Priority.Medium);
		}

		public void SendReply(IrcMessageData data, string message, Priority priority)
		{
			switch (data.Type)
			{
				case ReceiveType.ChannelMessage:
					this.SendMessage(SendType.Message, data.Channel, message, priority);
					break;
				case ReceiveType.QueryMessage:
					this.SendMessage(SendType.Message, data.Nick, message, priority);
					break;
				case ReceiveType.QueryNotice:
					this.SendMessage(SendType.Notice, data.Nick, message, priority);
					break;
			}
		}

		public void SendReply(IrcMessageData data, string message)
		{
			this.SendReply(data, message, Priority.Medium);
		}

		public void Op(string channel, string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+o " + nickname), priority);
		}

		public void Op(string channel, string nickname)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+o " + nickname));
		}

		public void Deop(string channel, string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "-o " + nickname), priority);
		}

		public void Deop(string channel, string nickname)
		{
			this.WriteLine(Rfc2812.Mode(channel, "-o " + nickname));
		}

		public void Voice(string channel, string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+v " + nickname), priority);
		}

		public void Voice(string channel, string nickname)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+v " + nickname));
		}

		public void Devoice(string channel, string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "-v " + nickname), priority);
		}

		public void Devoice(string channel, string nickname)
		{
			this.WriteLine(Rfc2812.Mode(channel, "-v " + nickname));
		}

		public void Ban(string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+b"), priority);
		}

		public void Ban(string channel)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+b"));
		}

		public void Ban(string channel, string hostmask, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+b " + hostmask), priority);
		}

		public void Ban(string channel, string hostmask)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+b " + hostmask));
		}

		public void Unban(string channel, string hostmask, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "-b " + hostmask), priority);
		}

		public void Unban(string channel, string hostmask)
		{
			this.WriteLine(Rfc2812.Mode(channel, "-b " + hostmask));
		}

		public void Halfop(string channel, string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(channel, "+h " + nickname), priority);
		}

		public void Dehalfop(string channel, string nickname)
		{
			this.WriteLine(Rfc2812.Mode(channel, "-h " + nickname));
		}

		public void RfcPass(string password, Priority priority)
		{
			this.WriteLine(Rfc2812.Pass(password), priority);
		}

		public void RfcPass(string password)
		{
			this.WriteLine(Rfc2812.Pass(password));
		}

		public void RfcUser(string username, int usermode, string realname, Priority priority)
		{
			this.WriteLine(Rfc2812.User(username, usermode, realname), priority);
		}

		public void RfcUser(string username, int usermode, string realname)
		{
			this.WriteLine(Rfc2812.User(username, usermode, realname));
		}

		public void RfcOper(string name, string password, Priority priority)
		{
			this.WriteLine(Rfc2812.Oper(name, password), priority);
		}

		public void RfcOper(string name, string password)
		{
			this.WriteLine(Rfc2812.Oper(name, password));
		}

		public void RfcPrivmsg(string destination, string message, Priority priority)
		{
			this.WriteLine(Rfc2812.Privmsg(destination, message), priority);
		}

		public void RfcPrivmsg(string destination, string message)
		{
			this.WriteLine(Rfc2812.Privmsg(destination, message));
		}

		public void RfcNotice(string destination, string message, Priority priority)
		{
			this.WriteLine(Rfc2812.Notice(destination, message), priority);
		}

		public void RfcNotice(string destination, string message)
		{
			this.WriteLine(Rfc2812.Notice(destination, message));
		}

		public void RfcJoin(string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.Join(channel), priority);
		}

		public void RfcJoin(string channel)
		{
			this.WriteLine(Rfc2812.Join(channel));
		}

		public void RfcJoin(string[] channels, Priority priority)
		{
			this.WriteLine(Rfc2812.Join(channels), priority);
		}

		public void RfcJoin(string[] channels)
		{
			this.WriteLine(Rfc2812.Join(channels));
		}

		public void RfcJoin(string channel, string key, Priority priority)
		{
			this.WriteLine(Rfc2812.Join(channel, key), priority);
		}

		public void RfcJoin(string channel, string key)
		{
			this.WriteLine(Rfc2812.Join(channel, key));
		}

		public void RfcJoin(string[] channels, string[] keys, Priority priority)
		{
			this.WriteLine(Rfc2812.Join(channels, keys), priority);
		}

		public void RfcJoin(string[] channels, string[] keys)
		{
			this.WriteLine(Rfc2812.Join(channels, keys));
		}

		public void RfcPart(string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.Part(channel), priority);
		}

		public void RfcPart(string channel)
		{
			this.WriteLine(Rfc2812.Part(channel));
		}

		public void RfcPart(string[] channels, Priority priority)
		{
			this.WriteLine(Rfc2812.Part(channels), priority);
		}

		public void RfcPart(string[] channels)
		{
			this.WriteLine(Rfc2812.Part(channels));
		}

		public void RfcPart(string channel, string partmessage, Priority priority)
		{
			this.WriteLine(Rfc2812.Part(channel, partmessage), priority);
		}

		public void RfcPart(string channel, string partmessage)
		{
			this.WriteLine(Rfc2812.Part(channel, partmessage));
		}

		public void RfcPart(string[] channels, string partmessage, Priority priority)
		{
			this.WriteLine(Rfc2812.Part(channels, partmessage), priority);
		}

		public void RfcPart(string[] channels, string partmessage)
		{
			this.WriteLine(Rfc2812.Part(channels, partmessage));
		}

		public void RfcKick(string channel, string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channel, nickname), priority);
		}

		public void RfcKick(string channel, string nickname)
		{
			this.WriteLine(Rfc2812.Kick(channel, nickname));
		}

		public void RfcKick(string[] channels, string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channels, nickname), priority);
		}

		public void RfcKick(string[] channels, string nickname)
		{
			this.WriteLine(Rfc2812.Kick(channels, nickname));
		}

		public void RfcKick(string channel, string[] nicknames, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channel, nicknames), priority);
		}

		public void RfcKick(string channel, string[] nicknames)
		{
			this.WriteLine(Rfc2812.Kick(channel, nicknames));
		}

		public void RfcKick(string[] channels, string[] nicknames, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channels, nicknames), priority);
		}

		public void RfcKick(string[] channels, string[] nicknames)
		{
			this.WriteLine(Rfc2812.Kick(channels, nicknames));
		}

		public void RfcKick(string channel, string nickname, string comment, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channel, nickname, comment), priority);
		}

		public void RfcKick(string channel, string nickname, string comment)
		{
			this.WriteLine(Rfc2812.Kick(channel, nickname, comment));
		}

		public void RfcKick(string[] channels, string nickname, string comment, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channels, nickname, comment), priority);
		}

		public void RfcKick(string[] channels, string nickname, string comment)
		{
			this.WriteLine(Rfc2812.Kick(channels, nickname, comment));
		}

		public void RfcKick(string channel, string[] nicknames, string comment, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channel, nicknames, comment), priority);
		}

		public void RfcKick(string channel, string[] nicknames, string comment)
		{
			this.WriteLine(Rfc2812.Kick(channel, nicknames, comment));
		}

		public void RfcKick(string[] channels, string[] nicknames, string comment, Priority priority)
		{
			this.WriteLine(Rfc2812.Kick(channels, nicknames, comment), priority);
		}

		public void RfcKick(string[] channels, string[] nicknames, string comment)
		{
			this.WriteLine(Rfc2812.Kick(channels, nicknames, comment));
		}

		public void RfcMotd(Priority priority)
		{
			this.WriteLine(Rfc2812.Motd(), priority);
		}

		public void RfcMotd()
		{
			this.WriteLine(Rfc2812.Motd());
		}

		public void RfcMotd(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Motd(target), priority);
		}

		public void RfcMotd(string target)
		{
			this.WriteLine(Rfc2812.Motd(target));
		}

		[Obsolete("use RfcLusers(Priority) instead")]
		public void RfcLuser(Priority priority)
		{
			this.RfcLusers(priority);
		}

		public void RfcLusers(Priority priority)
		{
			this.WriteLine(Rfc2812.Lusers(), priority);
		}

		[Obsolete("use RfcLusers() instead")]
		public void RfcLuser()
		{
			this.RfcLusers();
		}

		public void RfcLusers()
		{
			this.WriteLine(Rfc2812.Lusers());
		}

		[Obsolete("use RfcLusers(string, Priority) instead")]
		public void RfcLuser(string mask, Priority priority)
		{
			this.RfcLusers(mask, priority);
		}

		public void RfcLusers(string mask, Priority priority)
		{
			this.WriteLine(Rfc2812.Lusers(mask), priority);
		}

		[Obsolete("use RfcLusers(string) instead")]
		public void RfcLuser(string mask)
		{
			this.RfcLusers(mask);
		}

		public void RfcLusers(string mask)
		{
			this.WriteLine(Rfc2812.Lusers(mask));
		}

		[Obsolete("use RfcLusers(string, string, Priority) instead")]
		public void RfcLuser(string mask, string target, Priority priority)
		{
			this.RfcLusers(mask, target, priority);
		}

		public void RfcLusers(string mask, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Lusers(mask, target), priority);
		}

		[Obsolete("use RfcLusers(string, string) instead")]
		public void RfcLuser(string mask, string target)
		{
			this.RfcLusers(mask, target);
		}

		public void RfcLusers(string mask, string target)
		{
			this.WriteLine(Rfc2812.Lusers(mask, target));
		}

		public void RfcVersion(Priority priority)
		{
			this.WriteLine(Rfc2812.Version(), priority);
		}

		public void RfcVersion()
		{
			this.WriteLine(Rfc2812.Version());
		}

		public void RfcVersion(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Version(target), priority);
		}

		public void RfcVersion(string target)
		{
			this.WriteLine(Rfc2812.Version(target));
		}

		public void RfcStats(Priority priority)
		{
			this.WriteLine(Rfc2812.Stats(), priority);
		}

		public void RfcStats()
		{
			this.WriteLine(Rfc2812.Stats());
		}

		public void RfcStats(string query, Priority priority)
		{
			this.WriteLine(Rfc2812.Stats(query), priority);
		}

		public void RfcStats(string query)
		{
			this.WriteLine(Rfc2812.Stats(query));
		}

		public void RfcStats(string query, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Stats(query, target), priority);
		}

		public void RfcStats(string query, string target)
		{
			this.WriteLine(Rfc2812.Stats(query, target));
		}

		public void RfcLinks()
		{
			this.WriteLine(Rfc2812.Links());
		}

		public void RfcLinks(string servermask, Priority priority)
		{
			this.WriteLine(Rfc2812.Links(servermask), priority);
		}

		public void RfcLinks(string servermask)
		{
			this.WriteLine(Rfc2812.Links(servermask));
		}

		public void RfcLinks(string remoteserver, string servermask, Priority priority)
		{
			this.WriteLine(Rfc2812.Links(remoteserver, servermask), priority);
		}

		public void RfcLinks(string remoteserver, string servermask)
		{
			this.WriteLine(Rfc2812.Links(remoteserver, servermask));
		}

		public void RfcTime(Priority priority)
		{
			this.WriteLine(Rfc2812.Time(), priority);
		}

		public void RfcTime()
		{
			this.WriteLine(Rfc2812.Time());
		}

		public void RfcTime(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Time(target), priority);
		}

		public void RfcTime(string target)
		{
			this.WriteLine(Rfc2812.Time(target));
		}

		public void RfcConnect(string targetserver, string port, Priority priority)
		{
			this.WriteLine(Rfc2812.Connect(targetserver, port), priority);
		}

		public void RfcConnect(string targetserver, string port)
		{
			this.WriteLine(Rfc2812.Connect(targetserver, port));
		}

		public void RfcConnect(
		  string targetserver,
		  string port,
		  string remoteserver,
		  Priority priority)
		{
			this.WriteLine(Rfc2812.Connect(targetserver, port, remoteserver), priority);
		}

		public void RfcConnect(string targetserver, string port, string remoteserver)
		{
			this.WriteLine(Rfc2812.Connect(targetserver, port, remoteserver));
		}

		public void RfcTrace(Priority priority)
		{
			this.WriteLine(Rfc2812.Trace(), priority);
		}

		public void RfcTrace()
		{
			this.WriteLine(Rfc2812.Trace());
		}

		public void RfcTrace(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Trace(target), priority);
		}

		public void RfcTrace(string target)
		{
			this.WriteLine(Rfc2812.Trace(target));
		}

		public void RfcAdmin(Priority priority)
		{
			this.WriteLine(Rfc2812.Admin(), priority);
		}

		public void RfcAdmin()
		{
			this.WriteLine(Rfc2812.Admin());
		}

		public void RfcAdmin(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Admin(target), priority);
		}

		public void RfcAdmin(string target)
		{
			this.WriteLine(Rfc2812.Admin(target));
		}

		public void RfcInfo(Priority priority)
		{
			this.WriteLine(Rfc2812.Info(), priority);
		}

		public void RfcInfo()
		{
			this.WriteLine(Rfc2812.Info());
		}

		public void RfcInfo(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Info(target), priority);
		}

		public void RfcInfo(string target)
		{
			this.WriteLine(Rfc2812.Info(target));
		}

		public void RfcServlist(Priority priority)
		{
			this.WriteLine(Rfc2812.Servlist(), priority);
		}

		public void RfcServlist()
		{
			this.WriteLine(Rfc2812.Servlist());
		}

		public void RfcServlist(string mask, Priority priority)
		{
			this.WriteLine(Rfc2812.Servlist(mask), priority);
		}

		public void RfcServlist(string mask)
		{
			this.WriteLine(Rfc2812.Servlist(mask));
		}

		public void RfcServlist(string mask, string type, Priority priority)
		{
			this.WriteLine(Rfc2812.Servlist(mask, type), priority);
		}

		public void RfcServlist(string mask, string type)
		{
			this.WriteLine(Rfc2812.Servlist(mask, type));
		}

		public void RfcSquery(string servicename, string servicetext, Priority priority)
		{
			this.WriteLine(Rfc2812.Squery(servicename, servicetext), priority);
		}

		public void RfcSquery(string servicename, string servicetext)
		{
			this.WriteLine(Rfc2812.Squery(servicename, servicetext));
		}

		public void RfcList(string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.List(channel), priority);
		}

		public void RfcList(string channel)
		{
			this.WriteLine(Rfc2812.List(channel));
		}

		public void RfcList(string[] channels, Priority priority)
		{
			this.WriteLine(Rfc2812.List(channels), priority);
		}

		public void RfcList(string[] channels)
		{
			this.WriteLine(Rfc2812.List(channels));
		}

		public void RfcList(string channel, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.List(channel, target), priority);
		}

		public void RfcList(string channel, string target)
		{
			this.WriteLine(Rfc2812.List(channel, target));
		}

		public void RfcList(string[] channels, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.List(channels, target), priority);
		}

		public void RfcList(string[] channels, string target)
		{
			this.WriteLine(Rfc2812.List(channels, target));
		}

		public void RfcNames(string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.Names(channel), priority);
		}

		public void RfcNames(string channel)
		{
			this.WriteLine(Rfc2812.Names(channel));
		}

		public void RfcNames(string[] channels, Priority priority)
		{
			this.WriteLine(Rfc2812.Names(channels), priority);
		}

		public void RfcNames(string[] channels)
		{
			this.WriteLine(Rfc2812.Names(channels));
		}

		public void RfcNames(string channel, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Names(channel, target), priority);
		}

		public void RfcNames(string channel, string target)
		{
			this.WriteLine(Rfc2812.Names(channel, target));
		}

		public void RfcNames(string[] channels, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Names(channels, target), priority);
		}

		public void RfcNames(string[] channels, string target)
		{
			this.WriteLine(Rfc2812.Names(channels, target));
		}

		public void RfcTopic(string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.Topic(channel), priority);
		}

		public void RfcTopic(string channel)
		{
			this.WriteLine(Rfc2812.Topic(channel));
		}

		public void RfcTopic(string channel, string newtopic, Priority priority)
		{
			this.WriteLine(Rfc2812.Topic(channel, newtopic), priority);
		}

		public void RfcTopic(string channel, string newtopic)
		{
			this.WriteLine(Rfc2812.Topic(channel, newtopic));
		}

		public void RfcMode(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(target), priority);
		}

		public void RfcMode(string target)
		{
			this.WriteLine(Rfc2812.Mode(target));
		}

		public void RfcMode(string target, string newmode, Priority priority)
		{
			this.WriteLine(Rfc2812.Mode(target, newmode), priority);
		}

		public void RfcMode(string target, string newmode)
		{
			this.WriteLine(Rfc2812.Mode(target, newmode));
		}

		public void RfcService(string nickname, string distribution, string info, Priority priority)
		{
			this.WriteLine(Rfc2812.Service(nickname, distribution, info), priority);
		}

		public void RfcService(string nickname, string distribution, string info)
		{
			this.WriteLine(Rfc2812.Service(nickname, distribution, info));
		}

		public void RfcInvite(string nickname, string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.Invite(nickname, channel), priority);
		}

		public void RfcInvite(string nickname, string channel)
		{
			this.WriteLine(Rfc2812.Invite(nickname, channel));
		}

		public void RfcNick(string newnickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Nick(newnickname), priority);
		}

		public void RfcNick(string newnickname)
		{
			this.WriteLine(Rfc2812.Nick(newnickname));
		}

		public void RfcWho(Priority priority)
		{
			this.WriteLine(Rfc2812.Who(), priority);
		}

		public void RfcWho()
		{
			this.WriteLine(Rfc2812.Who());
		}

		public void RfcWho(string mask, Priority priority)
		{
			this.WriteLine(Rfc2812.Who(mask), priority);
		}

		public void RfcWho(string mask)
		{
			this.WriteLine(Rfc2812.Who(mask));
		}

		public void RfcWho(string mask, bool ircop, Priority priority)
		{
			this.WriteLine(Rfc2812.Who(mask, ircop), priority);
		}

		public void RfcWho(string mask, bool ircop)
		{
			this.WriteLine(Rfc2812.Who(mask, ircop));
		}

		public void RfcWhois(string mask, Priority priority)
		{
			this.WriteLine(Rfc2812.Whois(mask), priority);
		}

		public void RfcWhois(string mask)
		{
			this.WriteLine(Rfc2812.Whois(mask));
		}

		public void RfcWhois(string[] masks, Priority priority)
		{
			this.WriteLine(Rfc2812.Whois(masks), priority);
		}

		public void RfcWhois(string[] masks)
		{
			this.WriteLine(Rfc2812.Whois(masks));
		}

		public void RfcWhois(string target, string mask, Priority priority)
		{
			this.WriteLine(Rfc2812.Whois(target, mask), priority);
		}

		public void RfcWhois(string target, string mask)
		{
			this.WriteLine(Rfc2812.Whois(target, mask));
		}

		public void RfcWhois(string target, string[] masks, Priority priority)
		{
			this.WriteLine(Rfc2812.Whois(target, masks), priority);
		}

		public void RfcWhois(string target, string[] masks)
		{
			this.WriteLine(Rfc2812.Whois(target, masks));
		}

		public void RfcWhowas(string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Whowas(nickname), priority);
		}

		public void RfcWhowas(string nickname)
		{
			this.WriteLine(Rfc2812.Whowas(nickname));
		}

		public void RfcWhowas(string[] nicknames, Priority priority)
		{
			this.WriteLine(Rfc2812.Whowas(nicknames), priority);
		}

		public void RfcWhowas(string[] nicknames)
		{
			this.WriteLine(Rfc2812.Whowas(nicknames));
		}

		public void RfcWhowas(string nickname, string count, Priority priority)
		{
			this.WriteLine(Rfc2812.Whowas(nickname, count), priority);
		}

		public void RfcWhowas(string nickname, string count)
		{
			this.WriteLine(Rfc2812.Whowas(nickname, count));
		}

		public void RfcWhowas(string[] nicknames, string count, Priority priority)
		{
			this.WriteLine(Rfc2812.Whowas(nicknames, count), priority);
		}

		public void RfcWhowas(string[] nicknames, string count)
		{
			this.WriteLine(Rfc2812.Whowas(nicknames, count));
		}

		public void RfcWhowas(string nickname, string count, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Whowas(nickname, count, target), priority);
		}

		public void RfcWhowas(string nickname, string count, string target)
		{
			this.WriteLine(Rfc2812.Whowas(nickname, count, target));
		}

		public void RfcWhowas(string[] nicknames, string count, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Whowas(nicknames, count, target), priority);
		}

		public void RfcWhowas(string[] nicknames, string count, string target)
		{
			this.WriteLine(Rfc2812.Whowas(nicknames, count, target));
		}

		public void RfcKill(string nickname, string comment, Priority priority)
		{
			this.WriteLine(Rfc2812.Kill(nickname, comment), priority);
		}

		public void RfcKill(string nickname, string comment)
		{
			this.WriteLine(Rfc2812.Kill(nickname, comment));
		}

		public void RfcPing(string server, Priority priority)
		{
			this.WriteLine(Rfc2812.Ping(server), priority);
		}

		public void RfcPing(string server)
		{
			this.WriteLine(Rfc2812.Ping(server));
		}

		public void RfcPing(string server, string server2, Priority priority)
		{
			this.WriteLine(Rfc2812.Ping(server, server2), priority);
		}

		public void RfcPing(string server, string server2)
		{
			this.WriteLine(Rfc2812.Ping(server, server2));
		}

		public void RfcPong(string server, Priority priority)
		{
			this.WriteLine(Rfc2812.Pong(server), priority);
		}

		public void RfcPong(string server)
		{
			this.WriteLine(Rfc2812.Pong(server));
		}

		public void RfcPong(string server, string server2, Priority priority)
		{
			this.WriteLine(Rfc2812.Pong(server, server2), priority);
		}

		public void RfcPong(string server, string server2)
		{
			this.WriteLine(Rfc2812.Pong(server, server2));
		}

		public void RfcAway(Priority priority)
		{
			this.WriteLine(Rfc2812.Away(), priority);
		}

		public void RfcAway()
		{
			this.WriteLine(Rfc2812.Away());
		}

		public void RfcAway(string awaytext, Priority priority)
		{
			this.WriteLine(Rfc2812.Away(awaytext), priority);
		}

		public void RfcAway(string awaytext)
		{
			this.WriteLine(Rfc2812.Away(awaytext));
		}

		public void RfcRehash()
		{
			this.WriteLine(Rfc2812.Rehash());
		}

		public void RfcDie()
		{
			this.WriteLine(Rfc2812.Die());
		}

		public void RfcRestart()
		{
			this.WriteLine(Rfc2812.Restart());
		}

		public void RfcSummon(string user, Priority priority)
		{
			this.WriteLine(Rfc2812.Summon(user), priority);
		}

		public void RfcSummon(string user)
		{
			this.WriteLine(Rfc2812.Summon(user));
		}

		public void RfcSummon(string user, string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Summon(user, target), priority);
		}

		public void RfcSummon(string user, string target)
		{
			this.WriteLine(Rfc2812.Summon(user, target));
		}

		public void RfcSummon(string user, string target, string channel, Priority priority)
		{
			this.WriteLine(Rfc2812.Summon(user, target, channel), priority);
		}

		public void RfcSummon(string user, string target, string channel)
		{
			this.WriteLine(Rfc2812.Summon(user, target, channel));
		}

		public void RfcUsers(Priority priority)
		{
			this.WriteLine(Rfc2812.Users(), priority);
		}

		public void RfcUsers()
		{
			this.WriteLine(Rfc2812.Users());
		}

		public void RfcUsers(string target, Priority priority)
		{
			this.WriteLine(Rfc2812.Users(target), priority);
		}

		public void RfcUsers(string target)
		{
			this.WriteLine(Rfc2812.Users(target));
		}

		public void RfcWallops(string wallopstext, Priority priority)
		{
			this.WriteLine(Rfc2812.Wallops(wallopstext), priority);
		}

		public void RfcWallops(string wallopstext)
		{
			this.WriteLine(Rfc2812.Wallops(wallopstext));
		}

		public void RfcUserhost(string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Userhost(nickname), priority);
		}

		public void RfcUserhost(string nickname)
		{
			this.WriteLine(Rfc2812.Userhost(nickname));
		}

		public void RfcUserhost(string[] nicknames, Priority priority)
		{
			this.WriteLine(Rfc2812.Userhost(nicknames), priority);
		}

		public void RfcUserhost(string[] nicknames)
		{
			this.WriteLine(Rfc2812.Userhost(nicknames));
		}

		public void RfcIson(string nickname, Priority priority)
		{
			this.WriteLine(Rfc2812.Ison(nickname), priority);
		}

		public void RfcIson(string nickname)
		{
			this.WriteLine(Rfc2812.Ison(nickname));
		}

		public void RfcIson(string[] nicknames, Priority priority)
		{
			this.WriteLine(Rfc2812.Ison(nicknames), priority);
		}

		public void RfcIson(string[] nicknames)
		{
			this.WriteLine(Rfc2812.Ison(nicknames));
		}

		public void RfcQuit(Priority priority)
		{
			this.WriteLine(Rfc2812.Quit(), priority);
		}

		public void RfcQuit()
		{
			this.WriteLine(Rfc2812.Quit());
		}

		public void RfcQuit(string quitmessage, Priority priority)
		{
			this.WriteLine(Rfc2812.Quit(quitmessage), priority);
		}

		public void RfcQuit(string quitmessage)
		{
			this.WriteLine(Rfc2812.Quit(quitmessage));
		}

		public void RfcSquit(string server, string comment, Priority priority)
		{
			this.WriteLine(Rfc2812.Squit(server, comment), priority);
		}

		public void RfcSquit(string server, string comment)
		{
			this.WriteLine(Rfc2812.Squit(server, comment));
		}
	}
}
