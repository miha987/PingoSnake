using Microsoft.Xna.Framework;
using PingoSnake.Code.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Spritefonts
{
	class MyFont32 : Spritefont
	{
		public MyFont32() : base("spritefont32")
		{
			
		}

		public override string SetReferenceString()
		{
			return "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ ";
		}

		public override void InitializeBoxes()
		{
			base.InitializeBoxes();

			// TO GET THE BOXES I HELPED WITH https://www.leshylabs.com/apps/sstool/

			AddCharacterBox(new Rectangle(2, 0, 12, 32));
			AddCharacterBox(new Rectangle(16, 0, 14, 32));
			AddCharacterBox(new Rectangle(32, 0, 20, 32));
			AddCharacterBox(new Rectangle(54, 0, 20, 32));
			AddCharacterBox(new Rectangle(76, 0, 22, 32));
			AddCharacterBox(new Rectangle(100, 0, 22, 32));
			AddCharacterBox(new Rectangle(124, 0, 8, 32));
			AddCharacterBox(new Rectangle(134, 0, 12, 32));
			AddCharacterBox(new Rectangle(148, 0, 12, 32));
			AddCharacterBox(new Rectangle(162, 0, 20, 32));
			AddCharacterBox(new Rectangle(184, 0, 16, 32));
			AddCharacterBox(new Rectangle(202, 0, 8, 32));
			AddCharacterBox(new Rectangle(212, 0, 18, 32));
			AddCharacterBox(new Rectangle(232, 0, 8, 32));
			AddCharacterBox(new Rectangle(242, 0, 16, 32));
			AddCharacterBox(new Rectangle(260, 0, 16, 32));
			AddCharacterBox(new Rectangle(278, 0, 12, 32));
			AddCharacterBox(new Rectangle(292, 0, 16, 32));
			AddCharacterBox(new Rectangle(310, 0, 16, 32));
			AddCharacterBox(new Rectangle(328, 0, 18, 32));
			AddCharacterBox(new Rectangle(348, 0, 16, 32));
			AddCharacterBox(new Rectangle(366, 0, 16, 32));
			AddCharacterBox(new Rectangle(384, 0, 16, 32));
			AddCharacterBox(new Rectangle(402, 0, 16, 32));
			AddCharacterBox(new Rectangle(420, 0, 16, 32));
			AddCharacterBox(new Rectangle(438, 0, 8, 32));
			AddCharacterBox(new Rectangle(448, 0, 8, 32));
			AddCharacterBox(new Rectangle(458, 0, 18, 32));
			AddCharacterBox(new Rectangle(478, 0, 14, 32));
			AddCharacterBox(new Rectangle(494, 0, 18, 32));
			AddCharacterBox(new Rectangle(514, 0, 16, 32));
			AddCharacterBox(new Rectangle(532, 0, 20, 32));
			AddCharacterBox(new Rectangle(554, 0, 16, 32));
			AddCharacterBox(new Rectangle(572, 0, 16, 32));
			AddCharacterBox(new Rectangle(590, 0, 16, 32));
			AddCharacterBox(new Rectangle(608, 0, 18, 32));
			AddCharacterBox(new Rectangle(628, 0, 16, 32));
			AddCharacterBox(new Rectangle(646, 0, 16, 32));
			AddCharacterBox(new Rectangle(664, 0, 16, 32));
			AddCharacterBox(new Rectangle(682, 0, 16, 32));
			AddCharacterBox(new Rectangle(700, 0, 12, 32));
			AddCharacterBox(new Rectangle(714, 0, 18, 32));
			AddCharacterBox(new Rectangle(734, 0, 16, 32));
			AddCharacterBox(new Rectangle(752, 0, 16, 32));
			AddCharacterBox(new Rectangle(770, 0, 20, 32));
			AddCharacterBox(new Rectangle(792, 0, 18, 32));
			AddCharacterBox(new Rectangle(812, 0, 16, 32));
			AddCharacterBox(new Rectangle(830, 0, 16, 32));
			AddCharacterBox(new Rectangle(848, 0, 18, 32));
			AddCharacterBox(new Rectangle(868, 0, 18, 32));
			AddCharacterBox(new Rectangle(888, 0, 16, 32));
			AddCharacterBox(new Rectangle(906, 0, 16, 32));
			AddCharacterBox(new Rectangle(924, 0, 16, 32));
			AddCharacterBox(new Rectangle(942, 0, 16, 32));
			AddCharacterBox(new Rectangle(960, 0, 20, 32));
			AddCharacterBox(new Rectangle(982, 0, 18, 32));
			AddCharacterBox(new Rectangle(1002, 0, 16, 32));
			AddCharacterBox(new Rectangle(1020, 0, 16, 32));
			AddCharacterBox(new Rectangle(1038, 0, 12, 32));
			AddCharacterBox(new Rectangle(1052, 0, 16, 32));
			AddCharacterBox(new Rectangle(1070, 0, 12, 32));
			AddCharacterBox(new Rectangle(1084, 0, 22, 32));
			AddCharacterBox(new Rectangle(1108, 0, 16, 32));
			AddCharacterBox(new Rectangle(1126, 0, 12, 32));
			AddCharacterBox(new Rectangle(1140, 0, 16, 32));
			AddCharacterBox(new Rectangle(1158, 0, 16, 32));
			AddCharacterBox(new Rectangle(1176, 0, 16, 32));
			AddCharacterBox(new Rectangle(1194, 0, 16, 32));
			AddCharacterBox(new Rectangle(1212, 0, 16, 32));
			AddCharacterBox(new Rectangle(1230, 0, 14, 32));
			AddCharacterBox(new Rectangle(1246, 0, 16, 32));
			AddCharacterBox(new Rectangle(1264, 0, 16, 32));
			AddCharacterBox(new Rectangle(1282, 0, 12, 32));
			AddCharacterBox(new Rectangle(1296, 0, 12, 32));
			AddCharacterBox(new Rectangle(1310, 0, 16, 32));
			AddCharacterBox(new Rectangle(1328, 0, 10, 32));
			AddCharacterBox(new Rectangle(1340, 0, 20, 32));
			AddCharacterBox(new Rectangle(1362, 0, 16, 32));
			AddCharacterBox(new Rectangle(1380, 0, 16, 32));
			AddCharacterBox(new Rectangle(1398, 0, 16, 32));
			AddCharacterBox(new Rectangle(1416, 0, 18, 32));
			AddCharacterBox(new Rectangle(1436, 0, 16, 32));
			AddCharacterBox(new Rectangle(1454, 0, 16, 32));
			AddCharacterBox(new Rectangle(1472, 0, 16, 32));
			AddCharacterBox(new Rectangle(1490, 0, 16, 32));
			AddCharacterBox(new Rectangle(1508, 0, 16, 32));
			AddCharacterBox(new Rectangle(1526, 0, 20, 32));
			AddCharacterBox(new Rectangle(1548, 0, 16, 32));
			AddCharacterBox(new Rectangle(1566, 0, 16, 32));
			AddCharacterBox(new Rectangle(1584, 0, 16, 32));
			AddCharacterBox(new Rectangle(1602, 0, 14, 32));
			AddCharacterBox(new Rectangle(1618, 0, 8, 32));
			AddCharacterBox(new Rectangle(1628, 0, 14, 32));
			AddCharacterBox(new Rectangle(1644, 0, 18, 32));
			AddCharacterBox(new Rectangle(1664, 0, 18, 32));
		}
	}
}
