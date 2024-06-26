#region Header
//   Vorspire    _,-'/-'/  DictionaryPool.cs
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
	public sealed class DictionaryPool<TKey, TVal> : ObjectPool<Dictionary<TKey, TVal>>
	{
		public DictionaryPool()
		{ }

		public DictionaryPool(int capacity)
			: base(capacity)
		{ }

		protected override bool Sanitize(Dictionary<TKey, TVal> o)
		{
			o.Clear();

			return o.Count == 0;
		}
	}
}
