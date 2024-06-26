#region Header
//   Vorspire    _,-'/-'/  ListPool.cs
//   .      __,-; ,'( '/
//    \.    `-.__`-._`:_,-._       _ , . ``
//     `:-._,------' ` _,`--` -: `_ , ` ,' :
//        `---..__,,--'  (C) 2018  ` -'. -'
//        #  Vita-Nex [http://core.vita-nex.com]  #
//  {o)xxx|===============-   #   -===============|xxx(o}
//        #        The MIT License (MIT)          #
#endregion

#region References
using System.Collections.Generic;
#endregion

namespace VitaNex.Collections
{
	public sealed class ListPool<T> : ObjectPool<List<T>>
	{
		public ListPool()
		{ }

		public ListPool(int capacity)
			: base(capacity)
		{ }

		protected override bool Sanitize(List<T> o)
		{
			o.Clear();

			if (o.Capacity > 0x1000)
			{
				o.Capacity = 0x1000;
			}

			return o.Count == 0;
		}
	}
}
