using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MessagesDB : BaseDB
    {
        public MessagesList SelectAll()
        {
            command.CommandText = $"SELECT Messages.* FROM Messages";
            MessagesList groupList = new MessagesList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Messages msg = entity as Messages;
            msg.SenderId = int.Parse(reader["senderId"].ToString());
            msg.Receiver = int.Parse(reader["receiver"].ToString());
            msg.MessageText = reader["messageText"].ToString();
            msg.TimeSent = DateTime.Parse(reader["timeSent"].ToString());

            base.CreateModel(entity);
            return msg;
        }

        public override BaseEntity NewEntity()
        {
            return new Messages();
        }

        static private MessagesList list = new MessagesList();

        public static Messages SelectById(int id)
        {
            MessagesDB db = new MessagesDB();
            list = db.SelectAll();

            Messages g = list.Find(item => item.Id == id);
            return g;
        }

       
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Messages m = entity as Messages;
            if (m != null)
            {
                string sqlStr = $"DELETE FROM Messages WHERE ID=@pid";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", m.Id));
            }
        }

        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity(); ;
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                //inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Messages m = entity as Messages;
            if (m != null)
            {
                string sqlStr = $"INSERT INTO Messages (senderId, receiver, messageText, timeSent) " +
                                $"VALUES (?,?,?,?)";

                command.CommandText = sqlStr;
                command.Parameters.AddWithValue("@sender", m.SenderId);
                command.Parameters.AddWithValue("@receiver", m.Receiver);
                command.Parameters.AddWithValue("@text", m.MessageText);
                command.Parameters.AddWithValue("@time", m.TimeSent);
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Messages m = entity as Messages;
            if (m != null)
            {
                string sqlStr = $"UPDATE Messages " +
                                $"SET senderId=@sender, receiver=@receiver, messageText=@text, timeSent=@time " +
                                $"WHERE id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@sender", m.SenderId));
                command.Parameters.Add(new OleDbParameter("@receiver", m.Receiver));
                command.Parameters.Add(new OleDbParameter("@text", m.MessageText));
                command.Parameters.Add(new OleDbParameter("@time", m.TimeSent));
                command.Parameters.Add(new OleDbParameter("@id", m.Id));
            }
        }
        //public override void CreateInsertSQL(BaseEntity entity, OleDbCommand command)
        //{
        //    Messages m = entity as Messages;
        //    if (m == null) return;

        //    string sqlStr =
        //        "INSERT INTO MessagesTbl (senderId, receiver, messageText, timeSent) " +
        //        "VALUES (@sender, @receiver, @text, @time)";

        //    command.CommandText = sqlStr;

        //    command.Parameters.Add(new OleDbParameter("@sender", m.SenderId));
        //    command.Parameters.Add(new OleDbParameter("@receiver", m.Receiver));
        //    command.Parameters.Add(new OleDbParameter("@text", m.MessageText));
        //    command.Parameters.Add(new OleDbParameter("@time", m.TimeSent));
        //}


        //public override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand command)
        //{
        //    Messages m = entity as Messages;
        //    if (m == null) return;

        //    string sqlStr =
        //        "UPDATE MessagesTbl " +
        //        "SET senderId=@sender, receiver=@receiver, messageText=@text, timeSent=@time " +
        //        "WHERE id=@id";

        //    command.CommandText = sqlStr;

        //    command.Parameters.Add(new OleDbParameter("@sender", m.SenderId));
        //    command.Parameters.Add(new OleDbParameter("@receiver", m.Receiver));
        //    command.Parameters.Add(new OleDbParameter("@text", m.MessageText));
        //    command.Parameters.Add(new OleDbParameter("@time", m.TimeSent));
        //    command.Parameters.Add(new OleDbParameter("@id", m.Id));
        //}
    }
}