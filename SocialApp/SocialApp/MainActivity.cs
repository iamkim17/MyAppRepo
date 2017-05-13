using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.IO;
using SQLite;

namespace SocialApp
{
    [Activity(Label = "SocialApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText txtUsername;
        EditText txtPassword;
        Button btnLogin;
        Button btnReg;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnReg = FindViewById<Button>(Resource.Id.btnRegister);
            txtUsername = FindViewById<EditText>(Resource.Id.usernameField);
            txtPassword = FindViewById<EditText>(Resource.Id.passwordField);
            btnLogin.Click += LoginMethod;
            btnReg.Click += RegisterMethod;
            CreateDB();
        }

        private void LoginMethod(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dbPath);
                var data = db.Table<LoginTable>();
                var data1 = data.Where(x => x.username == txtUsername.Text && x.password == txtPassword.Text).FirstOrDefault();
                if(data1 != null)
                {
                    Toast.MakeText(this, "Login Successful", ToastLength.Short).Show();
                    StartActivity(typeof(profileFeed));
                }
                else
                {
                    Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
        private void RegisterMethod(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterVeiw));
        }

        public String CreateDB()
        {
            var output = "";
            output += "Creating Database if doesnt exist";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
            var db = new SQLiteConnection(dbPath);
            output += "\n Database Created . . . . ";
            return output;
        }
    }
}

