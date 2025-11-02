using Model;
using System;
using ViewModel;

public class Program
{
    public static void Main(string[]args)
    {
        //עובד
        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("City");
        //Console.ResetColor();
        //CityDB cdb = new();
        //CityList cList = cdb.SelectAll();
        //foreach (City c in cList)
        //    Console.WriteLine(c.CityName);

        //עובד
        //ParentsDB pdb = new();
        //ParentsList pList = pdb.SelectAll();
        //foreach (Parents p in pList)
        //    Console.WriteLine(p.Id+" "+p.LastName);

        //עובד
        //ChildOfParentDB db = new();
        //ChildOfParentList list = db.SelectAll();
        //foreach (ChildOfParent p in list)
        //    Console.WriteLine(p.Id + " " + p.FirstName);

        //לא עובד

        JobHistoryDB jhdb = new();
        JobHistoryList jhlist = jhdb.SelectAll();
        foreach (JobHistory jh in jhlist)
            Console.WriteLine(jh.StartTime);


        //עובד
        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("BabySitterTeens");
        //Console.ResetColor();
        //BabySitterTeensDB bst = new();
        //BabySitterTeensList groupList = bst.SelectAll();
        //foreach (BabySitterTeens p in groupList)
        //    Console.WriteLine(p.Id + " " + p.LastName);

        ////עובד
        //BabySitterRateDB db = new();
        //BabySitterRateList list = db.SelectAll();
        //foreach (BabySitterRate p in list)
        //    Console.WriteLine(p.Id );

        //לא עובד
        //MessagesDB msg = new();
        //MessagesList grouplist = msg.SelectAll();
        //foreach (Messages p in grouplist)
        //    Console.WriteLine(p.SenderId);

        //לא עובד
        //RequestsDB db = new();
        //RequestsList list = db.SelectAll();
        //foreach (Requests p in list)
        //    Console.WriteLine(p.BabysitterId);

        //לא עובד
        //ReviewsDB db = new();
        //ReviewsList list = db.SelectAll();
        //foreach (Reviews p in list)
        //    Console.WriteLine(p.BabySitterTeensid);


        //BabySitterRateDB db = new();
        //BabySitterRateList list = db.SelectAll();
        //foreach (BabySitterRate p in list)
        //    Console.WriteLine(p.Id );


        //BabySitterRateDB db = new();
        //BabySitterRateList list = db.SelectAll();
        //foreach (BabySitterRate p in list)
        //    Console.WriteLine(p.Id );
    }
}