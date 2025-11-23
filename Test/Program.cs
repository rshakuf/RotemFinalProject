using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using ViewModel;

public class Program
{
    public static void Main(string[] args)
    {
        bool test_insert = true, test_update = false, test_delete = false, test_select = false;

        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("City name");
        //Console.ResetColor();
        //CityDB cdb = new();
        //CityList cList = cdb.SelectAll();
        //foreach (City c in cList)
        //    Console.WriteLine(c.CityName);


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("City name");
        Console.ResetColor();
        CityDB cdb = new();
        CityList cList = cdb.SelectAll();

        City cityToUpdate = cList[0];
        cityToUpdate.CityName = "Rehovot";
        cdb.Update(cityToUpdate);
        int x = cdb.SaveChanges();
        Console.WriteLine($"{x} rows were updated");

        foreach (City c in cList)
            Console.WriteLine(c.CityName);


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("parents id and last name");
        Console.ResetColor();
        ParentsDB pdb = new();
        ParentsList pList = pdb.SelectAll();

        Parents ParentsToUpdate = pList[0];
        //  ParentsToUpdate.Id = 8;
        ParentsToUpdate.LastName = "coxxxhen111";
        pdb.Update(ParentsToUpdate);
        int y = pdb.SaveChanges();
        Console.WriteLine($"{y} rows were updated");

        foreach (Parents p in pList)
            Console.WriteLine(p.Id + " " + p.LastName);



        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("ChildOfParent id and first name");
        Console.ResetColor();
        ChildOfParentDB db = new();
        ChildOfParentList list = db.SelectAll();

        ChildOfParent ChildOfParentToUpdate = list[0];
        //ChildOfParentToUpdate.Id = "7";
        ChildOfParentToUpdate.FirstName = "rotem";
        db.Update(ChildOfParentToUpdate);
        int z = db.SaveChanges();
        Console.WriteLine($"{z} rows were updated");

        foreach (ChildOfParent p in list)
            Console.WriteLine(p.Id + " " + p.FirstName);


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("JobHistory start time");
        Console.ResetColor();
        JobHistoryDB jhdb = new();
        JobHistoryList jhlist = jhdb.SelectAll();

        JobHistory JobHistoryToUpdate = jhlist[0];
        //ChildOfParentToUpdate.Id = "7";
        //JobHistoryToUpdate.Parentid = pList[0];
        jhdb.Update(JobHistoryToUpdate);
        int k = jhdb.SaveChanges();
        Console.WriteLine($"{k} rows were updated");

        foreach (JobHistory jh in jhlist)
            Console.WriteLine(jh.StartTime);


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("BabySitterTeens id and last name");
        Console.ResetColor();
        BabySitterTeensDB bst = new();
        BabySitterTeensList groupList = bst.SelectAll();

        BabySitterTeens BabySitterTeensToUpdate = groupList[0];
        BabySitterTeensToUpdate.MailOfRecommender = "lori@gmail.com";
        //JobHistoryToUpdate.Parentid = pList[0];
        bst.Update(BabySitterTeensToUpdate);
        int a = bst.SaveChanges();
        Console.WriteLine($"{a} rows were updated");

        foreach (BabySitterTeens p in groupList)
            Console.WriteLine(p.Id);



        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("BabySitterRate id");
        Console.ResetColor();
        BabySitterRateDB bdb = new();
        BabySitterRateList blist = bdb.SelectAll();

        if (blist.Count > 0)
        {
            BabySitterRate BabySitterRateToUpdate = blist[0];
            BabySitterRateToUpdate.Stars = 5;
            bdb.Update(BabySitterRateToUpdate);
            int l = bdb.SaveChanges();
            Console.WriteLine($"{l} rows were updated");

            foreach (BabySitterRate p in blist)
                Console.WriteLine(p.Stars);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BabySitterRate read is 0!!!");
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Messages Receiver");
        Console.ResetColor();
        MessagesDB msgdb = new();
        MessagesList mlist = msgdb.SelectAll();

        Messages MessagesToUpdate = mlist[0];
        MessagesToUpdate.MessageText = "hi how u doing";
        msgdb.Update(MessagesToUpdate);
        int t = msgdb.SaveChanges();
        Console.WriteLine($"{t} rows were updated");

        foreach (Messages p in mlist)
            Console.WriteLine(p.MessageText);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Requests BabysitterId");
        Console.ResetColor();
        RequestsDB rdb = new();
        RequestsList rlist = rdb.SelectAll();

        Requests RequestsToUpdate = rlist[0];
        RequestsToUpdate.Status = "hi im available";
        rdb.Update(RequestsToUpdate);
        int w = rdb.SaveChanges();
        Console.WriteLine($"{w} rows were updated");

        foreach (Requests p in rlist)
            Console.WriteLine(p.Status);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Reviews BabysitterId");
        Console.ResetColor();
        ReviewsDB rvdb = new();
        ReviewsList rvlist = rvdb.SelectAll();

        Reviews ReviewsToUpdate = rvlist[0];
        ReviewsToUpdate.Rating = 9;
        rvdb.Update(ReviewsToUpdate);
        int q = rvdb.SaveChanges();
        Console.WriteLine($"{q} rows were updated");

        foreach (Reviews p in rvlist)
            Console.WriteLine(p.Rating);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Schedule BabysitterId");
        Console.ResetColor();
        ScheduleDB sdb = new();
        ScheduleList slist = sdb.SelectAll();

        Schedule ScheduleToUpdate = slist[0];
        ScheduleToUpdate.DayOfWeek = "sunday";
        sdb.Update(ScheduleToUpdate);
        int n = sdb.SaveChanges();
        Console.WriteLine($"{n} rows were updated");

        foreach (Schedule p in slist)
            Console.WriteLine(p.DayOfWeek);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("User Id");
        Console.ResetColor();
        UserDB udb = new();
        UserList ulist = udb.SelectAll();

        User UserToUpdate = ulist[0];
        UserToUpdate.CityNameId = 3;
        udb.Update(UserToUpdate);
        int u = udb.SaveChanges();
        Console.WriteLine($"{u} rows were updated");

        foreach (User p in ulist)
            Console.WriteLine(p.CityNameId);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("UserProfile Pass");
        Console.ResetColor();
        UserProfileDB updb = new();
        UserProfileList uplist = updb.SelectAll();

        UserProfile UserProfileToUpdate = uplist[0];
        UserProfileToUpdate.Pass = "4286";
        updb.Update(UserProfileToUpdate);
        int h = updb.SaveChanges();
        Console.WriteLine($"{h} rows were updated");

        foreach (UserProfile p in uplist)
            Console.WriteLine(p.Pass);


        int rows;

        User userInserted = new User { FirstName = "New User" + DateTime.Now.Millisecond, LastName = "asdasd", CityNameId = 1, DateOfBirth = DateTime.Now.Date };
        udb.Insert(userInserted);
        rows = udb.SaveChanges();
        Console.WriteLine($"\n[User INSERT] rows={rows} | new ID={userInserted.Id}");

        Parents parentInserted = new Parents { FirstName = "New parent" + DateTime.Now.Millisecond, LastName = "asdasd", CityNameId = 1, DateOfBirth = DateTime.Now.Date };
        pdb.Insert(parentInserted);
        rows = pdb.SaveChanges();
        Console.WriteLine($"\n[Parent INSERT] rows={rows} | new ID={parentInserted.Id}");

        BabySitterTeens BabySitterTeensInserted = new BabySitterTeens { FirstName = "New BabySitterTeens", MailOfRecommender = "teen@gmail.com", ProfilePicture = "", LastName = "asdasd", CityNameId = 1, DateOfBirth = DateTime.Now.Date, PriceForAnHour = 50 };
        bst.Insert(BabySitterTeensInserted);
        rows = bst.SaveChanges();
        Console.WriteLine($"\n[BabySitterTeens INSERT] rows={rows} | new ID={BabySitterTeensInserted.Id}");

        ChildOfParent ChildOfParentInserted = new ChildOfParent { FirstName = "New ChildOfParent", LastName = "asdasd", CityNameId = 1, DateOfBirth = DateTime.Now.Date };
        db.Insert(ChildOfParentInserted);
        rows = db.SaveChanges();
        Console.WriteLine($"\n[ChildOfParent INSERT] rows={rows} | new ID={ChildOfParentInserted.Id}");

        City CityInserted = new City { CityName = "New CityName" };
        cdb.Insert(ChildOfParentInserted);
        rows = cdb.SaveChanges();
        Console.WriteLine($"\n[City INSERT] rows={rows} | new ID={CityInserted.Id}");

        JobHistory JobHistoryInserted = new JobHistory { BabySitterId=jhlist[0].BabySitterId, Parentid=jhlist[0].Parentid, StartTime = DateTime.Now.Date, EndTime = DateTime.Now.Date, TotalPayment = 100 };
        jhdb.Insert(JobHistoryInserted);
        rows = jhdb.SaveChanges();
        Console.WriteLine($"\n[JobHistory INSERT] rows={rows} | new ID={JobHistoryInserted.BabySitterId}");

        Messages MessagesInserted = new Messages { SenderId=mlist[0].SenderId, MessageText = "segf", TimeSent = DateTime.Now.Date };
        msgdb.Insert(MessagesInserted);
        rows = msgdb.SaveChanges();
        Console.WriteLine($"\n[Messages INSERT] rows={rows} | new ID={MessagesInserted.Id}");

        Requests RequestsInserted = new Requests { Status = "avb", TimeOfRequest = DateTime.Now.Date };
        rdb.Insert(RequestsInserted);
        rows = rdb.SaveChanges();
        Console.WriteLine($"\n[Requests INSERT] rows={rows} | new ID={RequestsInserted.Id}");

        Reviews ReviewsInserted = new Reviews { Rating = 5, ReviewDate = DateTime.Now.Date };
        rvdb.Insert(ReviewsInserted);
        rows = rvdb.SaveChanges();
        Console.WriteLine($"\n[Reviews INSERT] rows={rows} | new ID={ReviewsInserted.Id}");

        Schedule ScheduleInserted = new Schedule { BabysitterId = slist[0].BabysitterId, DayOfWeek = "Monday", StartTime = DateTime.Now.Date, EndTime = DateTime.Now.Date };
        sdb.Insert(ScheduleInserted);
        rows = sdb.SaveChanges();
        Console.WriteLine($"\n[Schedule INSERT] rows={rows} | new ID={ScheduleInserted.Id}");

        



}

}