using Model;
using System;
using ViewModel;

public class Program
{
    public static void Main(string[]args)
    {



        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("City name");
        //Console.ResetColor();
        //CityDB cdb = new();
        //CityList cList = cdb.SelectAll();

        //City cityToUpdate = cList[0];
        //cityToUpdate.CityName = "Rehovot";
        //cdb.Update(cityToUpdate);
        //int x = cdb.SaveChanges();
        //Console.WriteLine($"{x} rows were updated");

        //foreach (City c in cList)
        //    Console.WriteLine(c.CityName);


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("parents id and last name");
        Console.ResetColor();
        ParentsDB pdb = new();
        ParentsList pList = pdb.SelectAll();

        Parents ParentsToUpdate = pList[0];
      //  ParentsToUpdate.Id = 8;
        ParentsToUpdate.LastName = "cohen111";
        pdb.Update(ParentsToUpdate);
        int y = pdb.SaveChanges();
        Console.WriteLine($"{y} rows were updated");

        foreach (Parents p in pList)
            Console.WriteLine(p.Id + " " + p.LastName);



        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("ChildOfParent id and first name");
        //Console.ResetColor();
        //ChildOfParentDB db = new();
        //ChildOfParentList list = db.SelectAll();

        //ChildOfParent ChildOfParentToUpdate = list[0];
        ////ChildOfParentToUpdate.Id = "7";
        //ChildOfParentToUpdate.FirstName = "rotem";
        //db.Update(ChildOfParentToUpdate);
        //int z = db.SaveChanges();
        //Console.WriteLine($"{z} rows were updated");

        //foreach (ChildOfParent p in list)
        //    Console.WriteLine(p.Id + " " + p.FirstName);


        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("JobHistory start time");
        //Console.ResetColor();
        //JobHistoryDB jhdb = new();
        //JobHistoryList jhlist = jhdb.SelectAll();

        //JobHistory JobHistoryToUpdate = jhlist[0];
        ////ChildOfParentToUpdate.Id = "7";
        //JobHistoryToUpdate.Parentid = pList[0];
        //jhdb.Update(JobHistoryToUpdate);
        //int z = jhdb.SaveChanges();
        //Console.WriteLine($"{z} rows were updated");


        //foreach (JobHistory jh in jhlist)
        //    Console.WriteLine(jh.StartTime);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("BabySitterTeens id and last name");
        //Console.ResetColor();
        //BabySitterTeensDB bst = new();
        //BabySitterTeensList groupList = bst.SelectAll();
        //foreach (BabySitterTeens p in groupList)
        //    Console.WriteLine(p.Id + " " + p.LastName);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("BabySitterRate id");
        //Console.ResetColor();
        //BabySitterRateDB bdb = new();
        //BabySitterRateList blist = bdb.SelectAll();
        //foreach (BabySitterRate p in blist)
        //    Console.WriteLine(p.Id);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("Messages Receiver");
        //Console.ResetColor();
        //MessagesDB msg = new();
        //MessagesList mlist = msg.SelectAll();
        //foreach (Messages p in mlist)
        //    Console.WriteLine(p.Receiver);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("Requests BabysitterId");
        //Console.ResetColor();
        //RequestsDB rdb = new();
        //RequestsList rlist = rdb.SelectAll();
        //foreach (Requests p in rlist)
        //    Console.WriteLine(p.BabysitterId);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("Reviews BabysitterId");
        //Console.ResetColor();
        //ReviewsDB rvdb = new();
        //ReviewsList rvlist = rvdb.SelectAll();
        //foreach (Reviews p in rvlist)
        //    Console.WriteLine(p.BabySitterId);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("Schedule BabysitterId");
        //Console.ResetColor();
        //ScheduleDB sdb = new();
        //ScheduleList slist = sdb.SelectAll();
        //foreach (Schedule p in slist)
        //    Console.WriteLine(p.BabysitterId);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("User Id");
        //Console.ResetColor();
        //UserDB udb = new();
        //UserList ulist = udb.SelectAll();
        //foreach (User p in ulist)
        //    Console.WriteLine(p.Id);

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("UserProfile Pass");
        //Console.ResetColor();
        //UserProfileDB updb = new();
        //UserProfileList uplist = updb.SelectAll();
        //foreach (UserProfile p in uplist)
        //    Console.WriteLine(p.Pass);




    }
}