#region Header
//   Vorspire    _,-'/-'/  SetPool.cs
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
	public sealed class SetPool<T> : ObjectPool<HashSet<T>>
	{
		public SetPool()
		{ }

		public SetPool(int capacity)
			: base(capacity)
		{ }

		protected override bool Sanitize(HashSet<T> o)
		{
			o.Clear();

			return o.Count == 0;
		}
	}
}
