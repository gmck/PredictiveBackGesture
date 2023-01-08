using Android.App;
using Android.OS;
using Android.Util;
using Android.Window;
using AndroidX.AppCompat.App;
using System;

namespace com.companyname.predictivebackgesturexam
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.PredictiveBackGesture.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnBackInvokedCallback
    {
        private readonly string logTag = "predictivebackgesture";
        private IOnBackInvokedCallback? onBackInvokedCallback;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            if (OperatingSystem.IsAndroidVersionAtLeast(33))
            {
                onBackInvokedCallback = this;
                OnBackInvokedDispatcher.RegisterOnBackInvokedCallback(IOnBackInvokedDispatcher.PriorityDefault, onBackInvokedCallback!);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            Log.Debug(logTag, "OnDestroy IsFinishing is "  +IsFinishing.ToString());

            if (OperatingSystem.IsAndroidVersionAtLeast(33))
                OnBackInvokedDispatcher.UnregisterOnBackInvokedCallback(onBackInvokedCallback!);

        }

        // Or
        //void IOnBackInvokedCallback.OnBackInvoked()
        //{
        //    Finish();
        //}


        public void OnBackInvoked()
        {
            Finish();
        }


    }
}