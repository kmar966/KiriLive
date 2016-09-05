using System;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using SupportDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
namespace KiribatiRadioLive
{
	public class DrawerToggle : SupportDrawerToggle
	{
		private AppCompatActivity host;
		private int openResource, closeResource;
		public DrawerToggle(AppCompatActivity host, DrawerLayout drawer_layout, SupportToolBar toolbar, int openedResource, int closeResource)
		: base(host, drawer_layout, toolbar, openedResource, closeResource)
		{
			this.host = host;
			this.openResource = openedResource;
			this.closeResource = closeResource;

		}

		public override void OnDrawerOpened(Android.Views.View drawerView)
		{
			base.OnDrawerOpened(drawerView);
		}

		public override void OnDrawerClosed(Android.Views.View drawerView)
		{
			base.OnDrawerClosed(drawerView);
		}

		public override void OnDrawerSlide(Android.Views.View drawerView, float slideOffset)
		{
			base.OnDrawerSlide(drawerView, slideOffset);
		}

	}
}

