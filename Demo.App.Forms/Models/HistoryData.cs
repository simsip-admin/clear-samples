using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace Simsip.Demo.Models
{
    public static class HistoryData
	{
        public static Color AlternateBackground = Color.FromHex("E9E9E9");


        public static List<History> GetData ()
		{
            return new List<History>
            {
                new History ()
                {
                    EntryName = "MONEY FUND PURCHASE",
                    EntryDate = new DateTime(2016, 5, 26),
                    EntryValue = (decimal)-112.46,
                    Background = Color.White
				},
                new History ()
                {
                    EntryName = "SECURITIES SPLIT ** EWISIN# US26...",
                    EntryDate = new DateTime(2016, 5, 25),
                    EntryValue = (decimal)0.00,
                    Background = AlternateBackground

                },
                new History ()
                {
                    EntryName = "SECURITIES SPLIT ** EOGISIN# US2...",
                    EntryDate = new DateTime(2016, 5, 25),
                    EntryValue = (decimal)0.00,
                    Background = Color.White
                },
                new History ()
                {
                    EntryName = "CASH IN LIEU OF FRACTIONAL **...",
                    EntryDate = new DateTime(2016, 5, 25),
                    EntryValue = (decimal)112.46,
                    Background = AlternateBackground
                },
                new History ()
                {
                    EntryName = "MONEY FUND PURCHASE",
                    EntryDate = new DateTime(2016, 5, 17),
                    EntryValue = (decimal)-50.00,
                    Background = Color.White
                },
                new History ()
                {
                    EntryName = "CASH DIVIDEND RECEIVEDISIN# US...",
                    EntryDate = new DateTime(2016, 5, 16),
                    EntryValue = (decimal)50.00,
                    Background = AlternateBackground
                },
                new History ()
                {
                    EntryName = "MONEY FUND PURCHASE",
                    EntryDate = new DateTime(2016, 5, 16),
                    EntryValue = (decimal)-152.46,
                    Background = Color.White
                },

            };
		}
	}
}