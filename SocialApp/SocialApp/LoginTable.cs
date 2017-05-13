using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SocialApp
{
    class LoginTable
    { 
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int id { get; set; }

        [MaxLength(25)]
        public string username { get; set; }
        [MaxLength(25)]
        public string password { get; set; }
        [MaxLength(25)]
        public string fname { get; set; }
        [MaxLength(25)]
        public string lname { get; set; }
        [MaxLength(25)]
        public string address { get; set; }
        [MaxLength(25)]
        public string emailAdd { get; set; }
    }
}