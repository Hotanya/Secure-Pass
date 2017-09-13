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
using Android.Gms.Ads;
using SecurePass.Droid;
using SecurePass.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: Xamarin.Forms.Dependency(typeof(SecurePass.Droid.InterstitialRenderer))]

namespace SecurePass.Droid
{
    public class InterstitialRenderer: IAdMobInterstitial
    {
        InterstitialAd _ad;

        public void Show(string adUnit)
        {
            var context = Android.App.Application.Context;
            _ad = new InterstitialAd(context);
            _ad.AdUnitId = adUnit;

            var intlistener = new InterstitialAdListener(_ad);
            intlistener.OnAdLoaded();
            _ad.AdListener = intlistener;

            var requestbuilder = new AdRequest.Builder();
            _ad.LoadAd(requestbuilder.Build());
        }
    }

}