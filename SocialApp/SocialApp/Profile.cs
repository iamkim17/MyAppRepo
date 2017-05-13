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

namespace SocialApp
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {
        TextView txtFName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ProfileLayout);

            txtFName = FindViewById<TextView>(Resource.Id.txtFName);
            txtFName.Text = Intent.GetStringExtra("queryData");
        }
    }
}