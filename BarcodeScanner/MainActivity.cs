using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Util;
using Xamarin.Essentials;
using ZXing.Mobile;

namespace BarcodeScanner
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/ic_launcher", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        string ip;
        int port;
        Button btnPair;
        Button btnScan;
        CheckBox chkSound;
        SeekBar skbVolume;

        MobileBarcodeScanner scanner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            MobileBarcodeScanner.Initialize(Application);
            scanner = new MobileBarcodeScanner();

            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            this.btnPair = FindViewById<Button>(Resource.Id.main_pair_button);
            btnPair.Click += async delegate  {
                btnPair.Background = this.Resources.GetDrawable(Resource.Drawable.gradient);
                btnPair.RefreshDrawableState();

                scanner.UseCustomOverlay = false;
                scanner.TopText = this.Resources.GetString(Resource.String.pair_top_text);
                scanner.BottomText = this.Resources.GetString(Resource.String.pair_bottom_text);
                
                var result = await scanner.Scan();
                this.HandlePairResult(result);

            };

            this.btnScan = FindViewById<Button>(Resource.Id.main_scan_button);
            btnScan.Click += delegate {

                btnScan.Background = this.Resources.GetDrawable(Resource.Drawable.gradient);
                btnScan.RefreshDrawableState();

                scanner.UseCustomOverlay = false;
                scanner.TopText = this.Resources.GetString(Resource.String.scan_top_text);
                scanner.BottomText = this.Resources.GetString(Resource.String.scan_bottom_text);

                var opt = new MobileBarcodeScanningOptions() { 
                    DelayBetweenContinuousScans = 1000,
                    AutoRotate = false
                    
                };
                scanner.ScanContinuously(opt, HandleScanResult);

            };
            this.chkSound = FindViewById<CheckBox>(Resource.Id.main_sound_checkbox);
            this.chkSound.CheckedChange += delegate
            {
                this.skbVolume.Enabled = this.chkSound.Checked;
            };

            this.skbVolume = FindViewById<SeekBar>(Resource.Id.main_volume_seekbar);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            btnPair.SetBackgroundColor(this.Resources.GetColor(Resource.Color.colorAccent));
            btnPair.RefreshDrawableState();

            btnScan.SetBackgroundColor(this.Resources.GetColor(Resource.Color.colorAccent));
            btnScan.RefreshDrawableState();

        }
        private void HandlePairResult( ZXing.Result result)
        {
            scanner.PauseAnalysis();
            if (!string.IsNullOrEmpty(result?.Text))
            {
                if (result.Text.Contains(":"))
                {
                    this.beep();
                    string[] results = result.Text.Split(":".ToCharArray());
                    this.ip = results[0];
                    this.port = int.Parse(results[1]);
                    this.btnScan.Enabled = true;
                }
            }
            scanner.PauseAnalysis();
        }
        private void HandleScanResult(ZXing.Result result)
        {
            scanner.PauseAnalysis();
            if (!string.IsNullOrEmpty(result?.Text) )
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    udpClient.Connect(this.ip, this.port);
                    Byte[] senddata = System.Text.Encoding.ASCII.GetBytes(result.Text);
                    udpClient.Send(senddata, senddata.Length);
             
                    udpClient.Close();
                    this.beep();
                }
            }
            scanner.ResumeAnalysis();
        }

        private void beep()
        {
            if (this.chkSound.Checked)
            {
                int volume = this.skbVolume.Progress;
                ToneGenerator generator = new ToneGenerator(Android.Media.Stream.Alarm, volume);
                generator.StartTone(Tone.CdmaConfirm);
                SystemClock.Sleep(300);
                generator.Release();
            }

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.menu_share_option)
            {
                this.ShareAppLink();
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void ShareAppLink()
        {
            await Xamarin.Essentials.Share.RequestAsync(new ShareTextRequest
            {
                Uri = this.Resources.GetString(Resource.String.app_playstore_url),
                Title = this.Resources.GetString(Resource.String.app_name),
            });

        }
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

