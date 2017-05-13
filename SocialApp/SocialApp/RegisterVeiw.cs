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

using System.IO;
using SQLite;

namespace SocialApp
{
    [Activity(Label = "RegisterVeiw")]
    public class RegisterVeiw : Activity
    {
        EditText txtUsername;
        EditText txtPassword;
        EditText txtFirstName;
        EditText txtLastName;
        EditText txtAddress;
        EditText txtEmailAdd;
        Button btnRegisterUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegistrationLayout);

            txtUsername = FindViewById<EditText>(Resource.Id.regUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.regPassword);
            txtFirstName = FindViewById<EditText>(Resource.Id.regFirstName);
            txtLastName = FindViewById<EditText>(Resource.Id.regLastName);
            txtAddress = FindViewById<EditText>(Resource.Id.regAddress);
            txtEmailAdd = FindViewById<EditText>(Resource.Id.regEmailAdd);
            btnRegisterUser = FindViewById<Button>(Resource.Id.btnReg1);
            btnRegisterUser.Click += RegUser;

        }

        private void RegUser(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<LoginTable>();
                LoginTable tbl = new LoginTable();
                tbl.username = txtUsername.Text;
                tbl.password = txtPassword.Text;
                tbl.fname = txtFirstName.Text;
                tbl.lname = txtLastName.Text;
                tbl.address = txtAddress.Text;
                tbl.emailAdd = txtEmailAdd.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully . . . ", ToastLength.Short).Show();
                StartActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
            
        }
    }
}