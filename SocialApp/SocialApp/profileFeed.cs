using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
namespace SocialApp
{
    [Activity(Label = "profileFeed")]
    public class profileFeed : Activity
    {
        DBHelper dbH = new DBHelper();
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
            var db = new SQLiteConnection(dbPath);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ProfileFeedLayout);


            dbH.CreateDatabase();
            dbH.CreateTable();

            var items = dbH.GetData().Select(x => "\n" + "Username: " + x.username + "\n" + "First Name: " + x.fname + "\n" + "Last Name: " + x.lname + "\n" + "Address: " + x.address + "\n" + "Email Address: " + x.emailAdd + "\n").ToList();
            //+ "\n" + "First Name: " + x.fname + "\n"+ "Last Name: " + x.lname + "\n" + "Address: " + x.address + "\n" + "Email Address: " + x.emailAdd + "\n"
            //var item = dbH.GetData().Select(x => x.lname).ToList();
            var userLists = FindViewById<ListView>(Resource.Id.userList);

            userLists.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);

            userLists.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            {
                var selectedItem = userLists.GetItemAtPosition(e.Position).ToString();
                Intent intent = new Intent(this, typeof(Profile));
                intent.PutExtra("queryData", selectedItem);
                //selectedItem = dbH.GetData().Select(x => "\n" + "Username: " + x.username + "\n" + "First Name: " + x.fname + "\n" + "Last Name: " + x.lname + "\n" + "Address: " + x.address + "\n" + "Email Address: " + x.emailAdd + "\n").ToString();
                Toast.MakeText(this, selectedItem, ToastLength.Long).Show();

                StartActivity(intent);
            };
        }

    }
}