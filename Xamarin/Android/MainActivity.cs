using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Framework;
using Framework.ServiceImps;
using Android.Views;
using Android.Content;
using Framework.Datas;

namespace Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // load the services with
            // * Test EndPoint Cloud Service
            ServiceProvider.SetupServiceProvider(new TestEndPointCloudService());

            // load view here
            LoadView();
        }

        /// <summary>
        /// function to load data from cloud and show to user
        /// </summary>
        private async void LoadView()
        {
            // TODO: maybe a simple loading UI here?

            // NOTE: maybe worthy to have only one read from cloud then filter the data here
            // if the loading from cloud would take too long
            var list_has_seat = await ServiceProvider.GetEventDetailsFromCloud_HasSeats_OrderByTime();
            var list_with_label = await ServiceProvider.GetEventDetailsFromCloud_WithLabels_OrderByTime("play");

            new Handler(Looper.MainLooper).Post(() => 
            {
                var llayout_has_seat = FindViewById<LinearLayout>(Resource.Id.linearLayoutEventHasSeats);
                foreach (var item in list_has_seat)
                {
                    LayoutInflater inflater = (LayoutInflater)GetSystemService(Context.LayoutInflaterService);
                    View temp = inflater.Inflate(Resource.Layout.temp_event_item, null);
                    PopulateEventTemplateUI(temp, item);
                    llayout_has_seat.AddView(temp);
                }

                var llayout_has_label = FindViewById<LinearLayout>(Resource.Id.linearLayoutEventHasLabel);
                foreach (var item in list_with_label)
                {
                    LayoutInflater inflater = (LayoutInflater)GetSystemService(Context.LayoutInflaterService);
                    View temp = inflater.Inflate(Resource.Layout.temp_event_item, null);
                    PopulateEventTemplateUI(temp, item);
                    llayout_has_label.AddView(temp);
                }
            });
        }

        /// <summary>
        /// function to populate event details to a event template
        /// </summary>
        /// <param name="obj"></param>
        private void PopulateEventTemplateUI(View view, EventDetail obj)
        {
            var label_name = view.FindViewById<TextView>(Resource.Id.textViewEventName);
            var label_venue = view.FindViewById<TextView>(Resource.Id.textViewEventVenue);
            var label_price = view.FindViewById<TextView>(Resource.Id.textViewEventPrice);

            label_name.Text = $"Name: {obj.name}";
            label_price.Text = $"Price: {obj.price:F1}";
            label_venue.Text = $"Venue: {obj.venue}";
        }
    }
}