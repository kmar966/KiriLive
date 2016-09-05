using System;
using System.Collections.Generic;
namespace KiribatiRadioLive
{
	public class DrawerListItemModel
	{
		public int Image { get; set; }
		public string Name { get; set; }
	}

	public class DrawerHeaderModel
	{
		public int Image { get; set; }
		public string AppName { get; set; }
	}

	public class DrawerItemModel
	{
		public List<DrawerListItemModel> Data { get; set; }
		public DrawerHeaderModel Header { get; set; }
	}
}

