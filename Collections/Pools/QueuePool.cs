#region Header
//   Vorspire    _,-'/-'/  QueuePool.cs
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
	public sealed class QueuePool<T> : ObjectPool<Queue<T>>
	{
		public QueuePool()
		{ }

		public QueuePool(int capacity)
			: base(capacity)
		{ }

		protected override bool Sanitize(Queue<T> o)
		{
			o.Clear();

			return o.Count == 0;
		}
	}
}
