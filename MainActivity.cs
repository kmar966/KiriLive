using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Support.V4.View;
using Android.Views;

namespace KiribatiRadioLive
{
	[Activity(Label = "KiribatiRadioLive", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MyTheme")]
	public class MainActivity : AppCompatActivity
	{

		private DrawerLayout drawer_layout;
		private ListView drawer_list;
		private string[] tiles; // drawer item names
		private DrawerItemModel drawer_items;
		private TypedArray drawer_items_icons; // list of drawer icons
		private DrawerToggle drawer_toggle;
		private SupportToolbar toolbar;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			toolbar = FindViewById<SupportToolbar>(Resource.Id.custom_toolbar);
			toolbar.Title = "Hello World";

			SetSupportActionBar(toolbar);



			// set the padding for the toolbar
			toolbar.SetPadding(0, StatusBarHeight, 0, 0);



			tiles = Resources.GetStringArray(Resource.Array.drawer_items);
			drawer_items_icons = Resources.ObtainTypedArray(Resource.Array.drawer_items_icon);
			drawer_layout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			drawer_list = FindViewById<ListView>(Resource.Id.drawer_list);
			InitializeDrawerItems();
			drawer_list.Adapter = new DrawerListAdapter(this, drawer_items, StatusBarHeight);//ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, drawer_items);



			drawer_toggle = new DrawerToggle(this, drawer_layout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);

			drawer_layout.SetDrawerListener(drawer_toggle);
			SupportActionBar.SetHomeButtonEnabled(true);
			SupportActionBar.SetDisplayShowTitleEnabled(true);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			drawer_toggle.SyncState();

			drawer_list.ItemClick += (sender, e) =>
			{
				Toast.MakeText(this, "You clicked " + e.Position + " Id: " + e.Id, ToastLength.Long).Show();
				LoadFragment(e.Position);

			};

			LoadFragment(0);


		}


		private void LoadFragment(int position)
		{
			SupportFragmentTransaction transaction = SupportFragmentManager.BeginTransaction();

			switch (position)
			{
				case 2:
					transaction.Replace(Resource.Id.main_content, new MusicLibraryFragment());
					toolbar.Title = "Music Library";
					break;

				default:
					transaction.Replace(Resource.Id.main_content, new StationFragment());
					toolbar.Title = "Stations";
					break;
			}

			if (drawer_layout.IsDrawerOpen(drawer_list))
			{
				drawer_layout.CloseDrawer(drawer_list);
			}

			transaction.Commit();
		}

		private void InitializeDrawerItems()
		{

			// add data 
			var data = new List<DrawerListItemModel>();
			for (int i = 0; i < tiles.Length; i++)
			{
				data.Add(new DrawerListItemModel()
				{
					Name = tiles[i],
					Image = drawer_items_icons.GetResourceId(i, -1)
				});
			}

			// add header
			var header = new DrawerHeaderModel()
			{
				AppName = GetString(Resource.String.app_name)
			};

			drawer_items = new DrawerItemModel()
			{
				Data = data,
				Header = header
			};





		}

		private int StatusBarHeight
		{
			get
			{
				// get the height of the status bar
				int result = 0;
				int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
				if (resourceId > 0)
				{
					result = Resources.GetDimensionPixelSize(resourceId);
				}
				return result;
			}


		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			drawer_toggle.OnOptionsItemSelected(item);
			return base.OnOptionsItemSelected(item);
		}
	}
}


