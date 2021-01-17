using Microsoft.Xna.Framework;
using PingoSnake.Code.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Spritefonts
{
	class MyFont128 : Spritefont
	{
		public MyFont128() : base("spritefont128")
		{

		}

		public override string SetReferenceString()
		{
			return "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ ";
		}

		public override void InitializeBoxes()
		{
			base.InitializeBoxes();

			AddCharacterBox(new Rectangle(8, 0, 48, 128));
			AddCharacterBox(new Rectangle(64, 0, 56, 128));
			AddCharacterBox(new Rectangle(128, 0, 80, 128));
			AddCharacterBox(new Rectangle(216, 0, 80, 128));
			AddCharacterBox(new Rectangle(304, 0, 88, 128));
			AddCharacterBox(new Rectangle(400, 0, 88, 128));
			AddCharacterBox(new Rectangle(496, 0, 32, 128));
			AddCharacterBox(new Rectangle(536, 0, 48, 128));
			AddCharacterBox(new Rectangle(592, 0, 48, 128));
			AddCharacterBox(new Rectangle(648, 0, 80, 128));
			AddCharacterBox(new Rectangle(736, 0, 64, 128));
			AddCharacterBox(new Rectangle(808, 0, 32, 128));
			AddCharacterBox(new Rectangle(848, 0, 72, 128));
			AddCharacterBox(new Rectangle(928, 0, 32, 128));
			AddCharacterBox(new Rectangle(968, 0, 64, 128));
			AddCharacterBox(new Rectangle(1040, 0, 64, 128));
			AddCharacterBox(new Rectangle(1112, 0, 48, 128));
			AddCharacterBox(new Rectangle(1168, 0, 64, 128));
			AddCharacterBox(new Rectangle(1240, 0, 64, 128));
			AddCharacterBox(new Rectangle(1312, 0, 72, 128));
			AddCharacterBox(new Rectangle(1392, 0, 64, 128));
			AddCharacterBox(new Rectangle(1464, 0, 64, 128));
			AddCharacterBox(new Rectangle(1536, 0, 64, 128));
			AddCharacterBox(new Rectangle(1608, 0, 64, 128));
			AddCharacterBox(new Rectangle(1680, 0, 64, 128));
			AddCharacterBox(new Rectangle(1752, 0, 32, 128));
			AddCharacterBox(new Rectangle(1792, 0, 32, 128));
			AddCharacterBox(new Rectangle(1832, 0, 72, 128));
			AddCharacterBox(new Rectangle(1912, 0, 56, 128));
			AddCharacterBox(new Rectangle(1976, 0, 72, 128));
			AddCharacterBox(new Rectangle(2056, 0, 64, 128));
			AddCharacterBox(new Rectangle(2128, 0, 80, 128));
			AddCharacterBox(new Rectangle(2216, 0, 64, 128));
			AddCharacterBox(new Rectangle(2288, 0, 64, 128));
			AddCharacterBox(new Rectangle(2360, 0, 64, 128));
			AddCharacterBox(new Rectangle(2432, 0, 72, 128));
			AddCharacterBox(new Rectangle(2512, 0, 64, 128));
			AddCharacterBox(new Rectangle(2584, 0, 64, 128));
			AddCharacterBox(new Rectangle(2656, 0, 64, 128));
			AddCharacterBox(new Rectangle(2728, 0, 64, 128));
			AddCharacterBox(new Rectangle(2800, 0, 48, 128));
			AddCharacterBox(new Rectangle(2856, 0, 72, 128));
			AddCharacterBox(new Rectangle(2936, 0, 64, 128));
			AddCharacterBox(new Rectangle(3008, 0, 64, 128));
			AddCharacterBox(new Rectangle(3080, 0, 80, 128));
			AddCharacterBox(new Rectangle(3168, 0, 72, 128));
			AddCharacterBox(new Rectangle(3248, 0, 64, 128));
			AddCharacterBox(new Rectangle(3320, 0, 64, 128));
			AddCharacterBox(new Rectangle(3392, 0, 72, 128));
			AddCharacterBox(new Rectangle(3472, 0, 72, 128));
			AddCharacterBox(new Rectangle(3552, 0, 64, 128));
			AddCharacterBox(new Rectangle(3624, 0, 64, 128));
			AddCharacterBox(new Rectangle(3696, 0, 64, 128));
			AddCharacterBox(new Rectangle(3768, 0, 64, 128));
			AddCharacterBox(new Rectangle(3840, 0, 80, 128));
			AddCharacterBox(new Rectangle(3928, 0, 72, 128));
			AddCharacterBox(new Rectangle(4008, 0, 64, 128));
			AddCharacterBox(new Rectangle(4080, 0, 64, 128));
			AddCharacterBox(new Rectangle(4152, 0, 48, 128));
			AddCharacterBox(new Rectangle(4208, 0, 64, 128));
			AddCharacterBox(new Rectangle(4280, 0, 48, 128));
			AddCharacterBox(new Rectangle(4336, 0, 88, 128));
			AddCharacterBox(new Rectangle(4432, 0, 64, 128));
			AddCharacterBox(new Rectangle(4504, 0, 48, 128));
			AddCharacterBox(new Rectangle(4560, 0, 64, 128));
			AddCharacterBox(new Rectangle(4632, 0, 64, 128));
			AddCharacterBox(new Rectangle(4704, 0, 64, 128));
			AddCharacterBox(new Rectangle(4776, 0, 64, 128));
			AddCharacterBox(new Rectangle(4848, 0, 64, 128));
			AddCharacterBox(new Rectangle(4920, 0, 56, 128));
			AddCharacterBox(new Rectangle(4984, 0, 64, 128));
			AddCharacterBox(new Rectangle(5056, 0, 64, 128));
			AddCharacterBox(new Rectangle(5128, 0, 48, 128));
			AddCharacterBox(new Rectangle(5184, 0, 48, 128));
			AddCharacterBox(new Rectangle(5240, 0, 64, 128));
			AddCharacterBox(new Rectangle(5312, 0, 40, 128));
			AddCharacterBox(new Rectangle(5360, 0, 80, 128));
			AddCharacterBox(new Rectangle(5448, 0, 64, 128));
			AddCharacterBox(new Rectangle(5520, 0, 64, 128));
			AddCharacterBox(new Rectangle(5592, 0, 64, 128));
			AddCharacterBox(new Rectangle(5664, 0, 72, 128));
			AddCharacterBox(new Rectangle(5744, 0, 64, 128));
			AddCharacterBox(new Rectangle(5816, 0, 64, 128));
			AddCharacterBox(new Rectangle(5888, 0, 64, 128));
			AddCharacterBox(new Rectangle(5960, 0, 64, 128));
			AddCharacterBox(new Rectangle(6032, 0, 64, 128));
			AddCharacterBox(new Rectangle(6104, 0, 80, 128));
			AddCharacterBox(new Rectangle(6192, 0, 64, 128));
			AddCharacterBox(new Rectangle(6264, 0, 64, 128));
			AddCharacterBox(new Rectangle(6336, 0, 64, 128));
			AddCharacterBox(new Rectangle(6408, 0, 56, 128));
			AddCharacterBox(new Rectangle(6472, 0, 32, 128));
			AddCharacterBox(new Rectangle(6512, 0, 56, 128));
			AddCharacterBox(new Rectangle(6576, 0, 72, 128));
			AddCharacterBox(new Rectangle(6656, 0, 56, 128));
		}
	}
}
