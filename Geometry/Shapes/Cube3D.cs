﻿#region Header
//   Vorspire    _,-'/-'/  Cube3D.cs
//   .      __,-; ,'( '/
//    \.    `-.__`-._`:_,-._       _ , . ``
//     `:-._,------' ` _,`--` -: `_ , ` ,' :
//        `---..__,,--'  (C) 2018  ` -'. -'
//        #  Vita-Nex [http://core.vita-nex.com]  #
//  {o)xxx|===============-   #   -===============|xxx(o}
//        #        The MIT License (MIT)          #
#endregion

#region References
using Server;
#endregion

namespace VitaNex.Geometry
{
	public class Cube3D : Shape3D
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

		public Cube3D(int radius)
			: this(Point3D.Zero, radius)
		{ }

		public Cube3D(IPoint3D center, int radius)
			: this(center, radius, false)
		{ }

		public Cube3D(IPoint3D center, int radius, bool hollow)
			: base(center)
		{
			_Radius = radius;
			_Hollow = hollow;
		}

		/// <summary>
		///     This cube always has an odd width, height and depth, never even.
		///     This preserves the center point.
		/// </summary>
		protected override void OnRender()
		{
			const int h = 5;

			for (var z = -Radius; z <= Radius; z++)
			{
				for (var x = -Radius; x <= Radius; x++)
				{
					for (var y = -Radius; y <= Radius; y++)
					{
						if (!Hollow || (z == -Radius || z == Radius || x == -Radius || x == Radius || y == -Radius || y == Radius))
						{
							Add(new Block3D(Center.Clone3D(x, y, z * h), h));
						}
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