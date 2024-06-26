#region Header
//   Vorspire    _,-'/-'/  Disc3D.cs
//   .      __,-; ,'( '/
//    \.    `-.__`-._`:_,-._       _ , . ``
//     `:-._,------' ` _,`--` -: `_ , ` ,' :
//        `---..__,,--'  (C) 2018  ` -'. -'
//        #  Vita-Nex [http://core.vita-nex.com]  #
//  {o)xxx|===============-   #   -===============|xxx(o}
//        #        The MIT License (MIT)          #
#endregion

#region References
using System;

using Server;
#endregion

namespace VitaNex.Geometry
{
	public class Disc3D : Shape3D
	{
		private int _Radius;
		private bool _Hollow;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int Radius
		{
			get => _Radius;
			set
			{
				if (_Radius == value)
				{
					return;
				}

				_Radius = value;
				Render();
			}
		}

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool Hollow
		{
			get => _Hollow;
			set
			{
				if (_Hollow == value)
				{
					return;
				}

				_Hollow = value;
				Render();
			}
		}

		public Disc3D(int radius)
			: this(Point3D.Zero, radius)
		{ }

		public Disc3D(IPoint3D center, int radius)
			: this(center, radius, false)
		{ }

		public Disc3D(IPoint3D center, int radius, bool hollow)
			: base(center)
		{
			_Radius = radius;
			_Hollow = hollow;
		}

		public Disc3D(GenericReader reader)
			: base(reader)
		{ }

		protected override void OnRender()
		{
			const int h = 5;

			for (var x = -Radius; x <= Radius; x++)
			{
				for (var y = -Radius; y <= Radius; y++)
				{
					var dist = (int)Math.Sqrt(x * x + y * y);

					if ((!Hollow || dist >= Radius) && dist <= Radius)
					{
						Add(new Block3D(Center.Clone3D(x, y), h));
					}
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.SetVersion(0);

			writer.Write(_Radius);
			writer.Write(_Hollow);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.GetVersion();

			_Radius = reader.ReadInt();
			_Hollow = reader.ReadBool();
		}
	}
}