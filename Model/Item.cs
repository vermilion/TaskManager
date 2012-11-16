using System;
using System.Globalization;

namespace Model
{
    /// <summary>
    /// Base item
    /// </summary>
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

    /// <summary>
    /// Task related item
    /// </summary>
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

    /// <summary>
    /// History entry
    /// </summary>
    public class History : Base
    {
        public long DataID;
        public string Text;

        public History()
        {
            DataID = -1;
        }
    }

    /// <summary>
    /// User identity
    /// </summary>
    public class User
    {
        public string Login;
        public string Pass;
        public string ShowAs;
    }

    /// <summary>
    /// Stores current user data
    /// </summary>
    public static class UserData
    {
        public static string UserName { get; set; }
    }
}