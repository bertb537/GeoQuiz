using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Util;

namespace GeoQuiz
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light", MainLauncher =
       true)]
    public class MainActivity : AppCompatActivity
    {
        private const string TAG = "Main_Activity";

        int currentIndex = 0;
        protected override void OnStart() //called when app starts
        {
            base.OnStart();
            Log.Debug(TAG, "OnStart Called");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(TAG, "OnResume Called");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(TAG, "OnPause Called");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(TAG, "OnStop Called");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(TAG, "OnDestroy Called");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            Log.Debug(TAG, "OnSaveInstanceState");

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Questions questionBank = new Questions();

            Button trueButton = FindViewById<Button>(Resource.Id.true_button);
            Button falseButton = FindViewById<Button>(Resource.Id.false_button);
            Button nextButton = FindViewById<Button>(Resource.Id.next_button);
            TextView questionTextView = FindViewById<TextView>(Resource.Id.question_text_view);

            questionTextView.SetText(questionBank.questions[currentIndex], null);

            trueButton.Click += delegate
            {
                if(questionBank.answers[currentIndex] == true)
                {
                    Toast.MakeText(this, Resource.String.correct_toast,
                   ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, Resource.String.incorrect_toast,
                    ToastLength.Short).Show();
                }
                
            };
            falseButton.Click += delegate
            {
                if (questionBank.answers[currentIndex] == false)
                {
                    Toast.MakeText(this, Resource.String.correct_toast,
                   ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, Resource.String.incorrect_toast,
                    ToastLength.Short).Show();
                }
            };
            nextButton.Click += delegate
            {
                currentIndex = (currentIndex + 1) % questionBank.questions.Count;
                questionTextView.SetText(questionBank.questions[currentIndex], null);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[]
            permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode,
               permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        } 
    }
}