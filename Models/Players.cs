using System;
using System.Collections.Generic;

namespace QuizKnock12HourPlayer.Models
{
    public partial class Players
    {
        public string Userid { get; set; }
        public string Username { get; set; }
        public int? Seikai { get; set; }
        public int? Gotou1 { get; set; }
        public bool Reset1 { get; set; }
        public int? Gotou2 { get; set; }
        public bool Reset2 { get; set; }
        public int? Gotou3 { get; set; }

		public int? ResetKaisu()
		{
			if (this.Reset2)
			{
				return 2;
			}
			else if (this.Reset1)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public int? Goto()
		{
			var gotou = this.Gotou1;
			if (this.Reset1)
			{
				gotou += this.Gotou2;
			}
			if (this.Reset2)
			{
				gotou += this.Gotou3;
			}
			return gotou;
		}

		public int? NextDownPoint()
		{
			if (this.Reset2)
			{
				return this.Gotou3 + 1;
			}
			if (this.Reset1)
			{
				return this.Gotou2 + 1;
			}
			return this.Gotou1 + 1;
		}

		public int? Tokuten()
		{
			var point = this.Seikai;
			point -= this.Sowa(this.Gotou1);
			if (this.Reset1)
			{
				point -= this.Sowa(this.Gotou2);
			}
			if (this.Reset2)
			{
				point -= this.Sowa(this.Gotou3);
			}
			return point;
		}

		private int? Sowa(int? n)
		{
			return n * (n + 1) / 2;
		}
    }
}
