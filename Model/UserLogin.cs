using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;



namespace PetCare.Model
{
　　　 class HashElement
　　　 {
　　　　　　　 long m_SessionID;
　　　　　　　 DateTime m_Time;

　　　　　　　 public long SessionID
　　　　　　　 {
　　　　　　　　　　　 get { return m_SessionID; }
　　　　　　　　　　　 set { m_SessionID = value; }
　　　　　　　 }

　　　　　　　 public DateTime Time
　　　　　　　 {
　　　　　　　　　　　 get { return m_Time; }
　　　　　　　　　　　 set { m_Time = value; }
　　　　　　　 }

　　　　　　　 public HashElement()
　　　　　　　 {
　　　　　　　　　　　 m_SessionID = -1;
　　　　　　　　　　　 m_Time = DateTime.Now;
　　　　　　　 }
　　　 }

　　　 public static class UserLogin
　　　 {
　　　　　　　 //哈希表，作为保存登录用户的队列
　　　　　　　 private static Hashtable m_userList;
　　　　　　　 //检查用户在线是否超时的线程
　　　　　　　 //private static Thread m_threadQueue;
　　　　　　　 //用户在线超时的时限(30分钟)
　　　　　　　 private static TimeSpan m_tsSub = new TimeSpan(0, 30, 0);


　　　　　　　 //public static UserLogin()
　　　　　　　 public static void Init()
　　　　　　　 {
　　　　　　　　　　　 //哈希表初始化为同步封装(线程安全)
　　　　　　　　　　　 m_userList = Hashtable.Synchronized(new Hashtable());
　　　　　　　　　　　 //初始化线程
　　　　　　　　　　　 //m_threadQueue = new Thread(CheckListTO);
　　　　　　　　　　　 //m_threadQueue.IsBackground = true;　 //设置为后台线程
　　　　　　　　　　　 //m_threadQueue.Start();
　　　　　　　 }

　　　　　　　 public static void Empty()
　　　　　　　 {
　　　　　　　　　　　 //if (m_threadQueue.IsAlive)
　　　　　　　　　　　 //{
　　　　　　　　　　　 //　　　 m_threadQueue.Abort();
　　　　　　　　　　　 //}
　　　　　　　　　　　 m_userList.Clear();
　　　　　　　 }

　　　　　　　 /// <summary>
　　　　　　　 /// 登录信息在数据库中验证成功后调用
　　　　　　　 /// </summary>
　　　　　　　 /// <param name="userName">用户名</param>
　　　　　　　 /// <param name="sessionID">登录流水号</param>
　　　　　　　 /// <returns>
　　　　　　　 /// 0:用户及登录流水号成功保存于队列
　　　　　　　 /// -1:保存失败
　　　　　　　 /// </returns>
　　　　　　　 public static int AddUserToList(string userName, long sessionID)
　　　　　　　 {
　　　　　　　　　　　// WriteLog.WriteData w = new WriteLog.WriteData();
　　　　　　　　　　　 int ret = 0;
　　　　　　　　　　　 try
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 HashElement hashElt = new HashElement();
　　　　　　　　　　　　　　　 hashElt.SessionID = sessionID;
　　　　　　　　　　　　　　　 //如果用户已经登录过，则只更新登录流水号及操作时间，否则新加入队列
　　　　　　　　　　　　　　　 lock (m_userList.SyncRoot)
　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　 if (m_userList.ContainsKey(userName))
　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　 m_userList[userName] = hashElt;
　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　 else
　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　 m_userList.Add(userName, hashElt);
　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　 }
　　　　　　　　　　　 }
　　　　　　　　　　　 catch (Exception exp)
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.StackTrace);
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.Message);
　　　　　　　　　　　　　//　　 w.WriteLine(exp.Message + exp.StackTrace, 01);
　　　　　　　　　　　　　　　 ret = -1;
　　　　　　　　　　　 }
　　　　　　　　　　　 return ret;
　　　　　　　 }

　　　　　　　 /// <summary>
　　　　　　　 /// 除登录外其他所有功能调用之前首先调用该方法
　　　　　　　 /// </summary>
　　　　　　　 /// <param name="userName">用户名</param>
　　　　　　　 /// <param name="sessionID">登录流水号</param>
　　　　　　　 /// <returns>
　　　　　　　 /// 0:验证用户登录成功
　　　　　　　 /// -1:验证用户登录失败
　　　　　　　 /// -2:用户未登录
　　　　　　　 /// -3:用户已重新登录或在别处登录
　　　　　　　 /// </returns>
　　　　　　　 public static int CheckUserLogin(string userName, long sessionID)
　　　　　　　 {
　　　　　　　　　　　 //WriteLog.WriteData w = new WriteLog.WriteData();
　　　　　　　　　　　 int ret = 0;
　　　　　　　　　　　 try
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 lock (m_userList.SyncRoot)
　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　 if (m_userList.ContainsKey(userName))
　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　 HashElement hashElt = m_userList[userName] as HashElement;
　　　　　　　　　　　　　　　　　　　　　　　 if (hashElt.SessionID.Equals(sessionID))
　　　　　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　　　　　 hashElt.Time = DateTime.Now;
　　　　　　　　　　　　　　　　　　　　　　　　　　　 m_userList[userName] = hashElt;
　　　　　　　　　　　　　　　　　　　　　　　　　　　 ret = 0;
　　　　　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　　　　　 else
　　　　　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　　　　　 ret = -3;
　　　　　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　 else
　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　 ret = -2;
　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　 }
　　　　　　　　　　　 }
　　　　　　　　　　　 catch 
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 //w.WriteLine(exp.Message + exp.StackTrace, 02);
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.StackTrace);
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.Message);
　　　　　　　　　　　　　　　 ret = -1;
　　　　　　　　　　　 }
　　　　　　　　　　　 return ret;
　　　　　　　 }

　　　　　　　 /// <summary>
　　　　　　　 /// 检查保存在队列中的用户在线是否超过时限，该方法供线程调用
　　　　　　　 /// </summary>
　　　　　　　 private static void CheckListTO()
　　　　　　　 {
　　　　　　　　　　　 //WriteLog.WriteData w = new WriteLog.WriteData();
　　　　　　　　　　　 try
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 //保存待清理的超时在线用户的临时队列
　　　　　　　　　　　　　　　 List<string> toKeys = new List<string>();
　　　　　　　　　　　　　　　 while (true)
　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　 //线程每隔1分钟执行检查清理操作
　　　　　　　　　　　　　　　　　　　 Thread.Sleep(1000 * 60);
　　　　　　　　　　　　　　　　　　　 //遍历保存在线用户的哈希表
　　　　　　　　　　　　　　　　　　　 lock (m_userList.SyncRoot)
　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　 foreach (DictionaryEntry deElt in m_userList)
　　　　　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　　　　　 //如果有超时的在线用户，将超时用户时放入临时的队列中，
　　　　　　　　　　　　　　　　　　　　　　　　　　　 //检查完哈希表之后再进行清理操作
　　　　　　　　　　　　　　　　　　　　　　　　　　　 //不能在检查过程中执行哈希表的删除键值操作，否则会出现异常。
　　　　　　　　　　　　　　　　　　　　　　　　　　　 HashElement htElt = deElt.Value as HashElement;
　　　　　　　　　　　　　　　　　　　　　　　　　　　 if (DateTime.Now - htElt.Time > m_tsSub)
　　　　　　　　　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　 toKeys.Add((string)deElt.Key);
　　　　　　　　　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　　　　　 //如果有超时的在线用户则进行清理操作
　　　　　　　　　　　　　　　　　　　　　　　 if (0 < toKeys.Count)
　　　　　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　　　　　 foreach (string key in toKeys)
　　　　　　　　　　　　　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　 m_userList.Remove(key);
　　　　　　　　　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　　　　　　　　　 toKeys.Clear();
　　　　　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　　　　　 }
　　　　　　　　　　　　　　　 }
　　　　　　　　　　　 }
　　　　　　　　　　　 catch 
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.StackTrace);
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.Message);
　　　　　　　　　　　　　　　 //w.WriteLine(exp.Message + exp.StackTrace, 03);
　　　　　　　　　　　 }
　　　　　　　 }
　　　　　　　 /// <summary>
　　　　　　　 /// 获取当前在线用户统计数
　　　　　　　 /// </summary>
　　　　　　　 /// <returns>统计数</returns>
　　　　　　　 public static int GetUserCount()
　　　　　　　 {
　　　　　　　　　 //WriteLog.WriteData w = new WriteLog.WriteData();
　　　　　　　　　　　 int count = 0;
　　　　　　　　　　　 try
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 lock (m_userList.SyncRoot)
　　　　　　　　　　　　　　　 {
　　　　　　　　　　　　　　　　　　　 count = m_userList.Count;
　　　　　　　　　　　　　　　 }
　　　　　　　　　　　 }
　　　　　　　　　　　 catch 
　　　　　　　　　　　 {
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.StackTrace);
　　　　　　　　　　　　　　　 //System.Console.Out.WriteLine(exp.Message);
　　　　　　　　　　　　　　　 //w.WriteLine(exp.Message + exp.StackTrace, 04);
　　　　　　　　　　　 }
　　　　　　　　　　　 return count;
　　　　　　　 }
　　　 }
}

