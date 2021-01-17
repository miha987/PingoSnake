using Microsoft.Xna.Framework;
using PingoSnake.Code.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Spritefonts
{
	class MyFont64 : Spritefont
	{
		public MyFont64() : base("spritefont64")
		{

		}

		public override string SetReferenceString()
		{
			return "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ ";
		}

		public override void InitializeBoxes()
		{
			base.InitializeBoxes();

			AddCharacterBox(new Rectangle(4, 0, 24, 64));
			AddCharacterBox(new Rectangle(32, 0, 28, 64));
			AddCharacterBox(new Rectangle(64, 0, 40, 64));
			AddCharacterBox(new Rectangle(108, 0, 40, 64));
			AddCharacterBox(new Rectangle(152, 0, 44, 64));
			AddCharacterBox(new Rectangle(200, 0, 44, 64));
			AddCharacterBox(new Rectangle(248, 0, 16, 64));
			AddCharacterBox(new Rectangle(268, 0, 24, 64));
			AddCharacterBox(new Rectangle(296, 0, 24, 64));
			AddCharacterBox(new Rectangle(324, 0, 40, 64));
			AddCharacterBox(new Rectangle(368, 0, 32, 64));
			AddCharacterBox(new Rectangle(404, 0, 16, 64));
			AddCharacterBox(new Rectangle(424, 0, 36, 64));
			AddCharacterBox(new Rectangle(464, 0, 16, 64));
			AddCharacterBox(new Rectangle(484, 0, 32, 64));
			AddCharacterBox(new Rectangle(520, 0, 32, 64));
			AddCharacterBox(new Rectangle(556, 0, 24, 64));
			AddCharacterBox(new Rectangle(584, 0, 32, 64));
			AddCharacterBox(new Rectangle(620, 0, 32, 64));
			AddCharacterBox(new Rectangle(656, 0, 36, 64));
			AddCharacterBox(new Rectangle(696, 0, 32, 64));
			AddCharacterBox(new Rectangle(732, 0, 32, 64));
			AddCharacterBox(new Rectangle(768, 0, 32, 64));
			AddCharacterBox(new Rectangle(804, 0, 32, 64));
			AddCharacterBox(new Rectangle(840, 0, 32, 64));
			AddCharacterBox(new Rectangle(876, 0, 16, 64));
			AddCharacterBox(new Rectangle(896, 0, 16, 64));
			AddCharacterBox(new Rectangle(916, 0, 36, 64));
			AddCharacterBox(new Rectangle(956, 0, 28, 64));
			AddCharacterBox(new Rectangle(988, 0, 36, 64));
			AddCharacterBox(new Rectangle(1028, 0, 32, 64));
			AddCharacterBox(new Rectangle(1064, 0, 40, 64));
			AddCharacterBox(new Rectangle(1108, 0, 32, 64));
			AddCharacterBox(new Rectangle(1144, 0, 32, 64));
			AddCharacterBox(new Rectangle(1180, 0, 32, 64));
			AddCharacterBox(new Rectangle(1216, 0, 36, 64));
			AddCharacterBox(new Rectangle(1256, 0, 32, 64));
			AddCharacterBox(new Rectangle(1292, 0, 32, 64));
			AddCharacterBox(new Rectangle(1328, 0, 32, 64));
			AddCharacterBox(new Rectangle(1364, 0, 32, 64));
			AddCharacterBox(new Rectangle(1400, 0, 24, 64));
			AddCharacterBox(new Rectangle(1428, 0, 36, 64));
			AddCharacterBox(new Rectangle(1468, 0, 32, 64));
			AddCharacterBox(new Rectangle(1504, 0, 32, 64));
			AddCharacterBox(new Rectangle(1540, 0, 40, 64));
			AddCharacterBox(new Rectangle(1584, 0, 36, 64));
			AddCharacterBox(new Rectangle(1624, 0, 32, 64));
			AddCharacterBox(new Rectangle(1660, 0, 32, 64));
			AddCharacterBox(new Rectangle(1696, 0, 36, 64));
			AddCharacterBox(new Rectangle(1736, 0, 36, 64));
			AddCharacterBox(new Rectangle(1776, 0, 32, 64));
			AddCharacterBox(new Rectangle(1812, 0, 32, 64));
			AddCharacterBox(new Rectangle(1848, 0, 32, 64));
			AddCharacterBox(new Rectangle(1884, 0, 32, 64));
			AddCharacterBox(new Rectangle(1920, 0, 40, 64));
			AddCharacterBox(new Rectangle(1964, 0, 36, 64));
			AddCharacterBox(new Rectangle(2004, 0, 32, 64));
			AddCharacterBox(new Rectangle(2040, 0, 32, 64));
			AddCharacterBox(new Rectangle(2076, 0, 24, 64));
			AddCharacterBox(new Rectangle(2104, 0, 32, 64));
			AddCharacterBox(new Rectangle(2140, 0, 24, 64));
			AddCharacterBox(new Rectangle(2168, 0, 44, 64));
			AddCharacterBox(new Rectangle(2216, 0, 32, 64));
			AddCharacterBox(new Rectangle(2252, 0, 24, 64));
			AddCharacterBox(new Rectangle(2280, 0, 32, 64));
			AddCharacterBox(new Rectangle(2316, 0, 32, 64));
			AddCharacterBox(new Rectangle(2352, 0, 32, 64));
			AddCharacterBox(new Rectangle(2388, 0, 32, 64));
			AddCharacterBox(new Rectangle(2424, 0, 32, 64));
			AddCharacterBox(new Rectangle(2460, 0, 28, 64));
			AddCharacterBox(new Rectangle(2492, 0, 32, 64));
			AddCharacterBox(new Rectangle(2528, 0, 32, 64));
			AddCharacterBox(new Rectangle(2564, 0, 24, 64));
			AddCharacterBox(new Rectangle(2592, 0, 24, 64));
			AddCharacterBox(new Rectangle(2620, 0, 32, 64));
			AddCharacterBox(new Rectangle(2656, 0, 20, 64));
			AddCharacterBox(new Rectangle(2680, 0, 40, 64));
			AddCharacterBox(new Rectangle(2724, 0, 32, 64));
			AddCharacterBox(new Rectangle(2760, 0, 32, 64));
			AddCharacterBox(new Rectangle(2796, 0, 32, 64));
			AddCharacterBox(new Rectangle(2832, 0, 36, 64));
			AddCharacterBox(new Rectangle(2872, 0, 32, 64));
			AddCharacterBox(new Rectangle(2908, 0, 32, 64));
			AddCharacterBox(new Rectangle(2944, 0, 32, 64));
			AddCharacterBox(new Rectangle(2980, 0, 32, 64));
			AddCharacterBox(new Rectangle(3016, 0, 32, 64));
			AddCharacterBox(new Rectangle(3052, 0, 40, 64));
			AddCharacterBox(new Rectangle(3096, 0, 32, 64));
			AddCharacterBox(new Rectangle(3132, 0, 32, 64));
			AddCharacterBox(new Rectangle(3168, 0, 32, 64));
			AddCharacterBox(new Rectangle(3204, 0, 28, 64));
			AddCharacterBox(new Rectangle(3236, 0, 16, 64));
			AddCharacterBox(new Rectangle(3256, 0, 28, 64));
			AddCharacterBox(new Rectangle(3288, 0, 36, 64));
			AddCharacterBox(new Rectangle(3328, 0, 28, 64));
		}
	}
}
