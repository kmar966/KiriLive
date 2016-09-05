using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using System.Linq;
using Java.Lang;

namespace KiribatiRadioLive
{
	public class DrawerListAdapter : BaseAdapter<DrawerItemModel>
	{

		private MainActivity context;
		private IList<DrawerListItemModel> i;
		private DrawerItemModel items;
		private int statusBarHeight;


		public int typeCount = 2;
		public const int HEADER = 0;
		public const int DATA = 1;

		public DrawerListAdapter(MainActivity context, DrawerItemModel items, int statusBarHeight)
		{
			this.context = context;
			this.items = items;
			this.statusBarHeight = statusBarHeight;
		}

		public override DrawerItemModel this[int position]
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override int ViewTypeCount
		{
			get
			{
				return typeCount;
			}
		}

		public override int GetItemViewType(int position)
		{
			return position == 0 ? HEADER : DATA;
		}


		public override int Count
		{
			get
			{
				return items.Data.Count + 1; // + 1 since we have a header
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			throw new NotImplementedException();
		}

		public override long GetItemId(int position)
		{
			// position of the item is basically the its id
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = null; //convertView ?? context.LayoutInflater.Inflate(Resource.Layout.CustomDrawerListView, parent, false);

			switch (GetItemViewType(position))
			{
				case HEADER:
					view = context.LayoutInflater.Inflate(Resource.Layout.CustomDrawerHeader, parent, false);
					var header = items.Header;

					view.FindViewById<TextView>(Resource.Id.drawer_header_text).Text = header.AppName;
					view.FindViewById<LinearLayout>(Resource.Id.drawer_header_layout).SetPadding(0, statusBarHeight, 0, 0);
					view.SetOnClickListener(null); // disable on click event on this
					break;
				case DATA:
					view = context.LayoutInflater.Inflate(Resource.Layout.CustomDrawerListView, parent, false);

					var item = items.Data.ElementAt(position - 1);

					view.FindViewById<TextView>(Resource.Id.list_item_name).Text = item.Name;
					view.FindViewById<ImageView>(Resource.Id.thumbnail).SetImageResource(item.Image);
					break;
			}


			// get the item to be added to the listview row

			return view;
		}
	}
}

