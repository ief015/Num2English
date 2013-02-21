using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Num2English
{
	class N2E
	{
		public static string process(decimal n, uint places = 0)
		{
			// Negative numbers
			if (n < 0)
			{
				return "negative " + process(-n);
			}

			// Process decimal places
			if (n != Math.Floor(n))
			{
				string dStr = "";
				decimal d = n;

				for (int i = 0; i < places; ++i, d *= 10)
				{
					if (i == 0)
						dStr += " point";

					dStr += " " + process((long)Math.Floor( d*10 - Math.Floor(d)*10 ));
				}

				// Process integer portion of n
				return process(Math.Floor(n)) + dStr;
			}

			// 0 - 9
			if (n < 10)
			{
				if (n == 0) return "zero";
				if (n == 1) return "one";
				if (n == 2) return "two";
				if (n == 3) return "three";
				if (n == 4) return "four";
				if (n == 5) return "five";
				if (n == 6) return "six";
				if (n == 7) return "seven";
				if (n == 8) return "eight";
				if (n == 9) return "nine";
			}

			// 11 - 19
			if (n > 10 && n < 20)
			{
				if (n == 11) return "eleven";
				if (n == 12) return "twelve";
				if (n == 13) return "thirteen";
				if (n == 14) return "fourteen";
				if (n == 15) return "fifteen";
				if (n == 16) return "sixteen";
				if (n == 17) return "seventeen";
				if (n == 18) return "eighteen";
				if (n == 19) return "ninetine";
			}

			// Tens (under 100)
			if (n < 100)
			{
				// Multiples of 10
				if (n % 10 == 0)
				{
					if (n == 10) return "ten";
					if (n == 20) return "twenty";
					if (n == 30) return "thirty";
					if (n == 40) return "fourty";
					if (n == 50) return "fifty";
					if (n == 60) return "sixty";
					if (n == 70) return "seventy";
					if (n == 80) return "eighty";
					if (n == 90) return "ninety";
				}

				// Everything else in between
				return process( Math.Floor( Math.Floor(n / 10) * 10 ) )
					+ "-" + process( Math.Floor(n - (Math.Floor(n / 10) * 10)) );
			}

			// Hundreds (under 1 000)
			if (n < 1000)
			{
				decimal top, btm;
				top = Math.Floor(n / 100);
				btm = Math.Floor(n - (Math.Floor(n / 100) * 100));

				if (btm == 0)
				{
					return process(top) + " hundred";
				}
				else
				{
					return process(top) + " hundred " + process(btm);
				}
			}

			// Thousands (under 1 000 000)
			if (n < 1000000)
			{
				decimal top, btm;
				top = Math.Floor(n / 1000);
				btm = Math.Floor(n - (Math.Floor(n / 1000) * 1000));

				if (btm == 0)
				{
					return process(top) + " thousand";
				}
				else
				{
					return process(top) + " thousand " + process(btm);
				}
			}

			// Millions (under 1 000 000 000)
			if (n < 1000000000)
			{
				decimal top, btm;
				top = Math.Floor(n / 1000000);
				btm = Math.Floor(n - (Math.Floor(n / 1000000) * 1000000));

				if (btm == 0)
				{
					return process(top) + " million";
				}
				else
				{
					return process(top) + " million " + process(btm);
				}
			}

			// Billions (under 1 000 000 000 000)
			if (n < 1000000000000)
			{
				decimal top, btm;
				top = Math.Floor(n / 1000000000);
				btm = Math.Floor(n - (Math.Floor(n / 1000000000) * 1000000000));

				if (btm == 0)
				{
					return process(top) + " billion";
				}
				else
				{
					return process(top) + " billion " + process(btm);
				}
			}

			// Trillions (and larger numbers)
			{
				decimal top, btm;
				top = Math.Floor(n / 1000000000000);
				btm = Math.Floor(n - (Math.Floor(n / 1000000000000) * 1000000000000));

				if (btm == 0)
				{
					return process(top) + " trillion";
				}
				else
				{
					return process(top) + " trillion " + process(btm);
				}
			}
		}
	}
}
