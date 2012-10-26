using System;
using System.Globalization;

namespace Model
{
    public class Base
    {
        public string Datetime;
        public long ID;
        public string User;

        protected Base()
        {
            ID = -1;
            Datetime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }

    public class Data : Base
    {
        public string AssignedTo;
        public string CreatedBy;
        public string CreationDate;
        public string Description;
        public string Priority;
        public string Progress;
        public string Related;
        public string State;
        public string Title;

        public Data()
        {
            Priority = "10";
            Related = "";
        }
    }

    public class History : Base
    {
        public long DataID;
        public string Text;

        public History()
        {
            DataID = -1;
        }
    }

    public class User
    {
        public string Login;
        public string Pass;
        public string ShowAs;
    }

    public static class UserData
    {
        public static string UserName { get; set; }
    }
}