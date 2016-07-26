using SQLite;
using System;
using Xamarin.Forms;

namespace Simsip.Demo.Models
{
    public class History
	{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

		public string EntryName { get; set; }

		public DateTime EntryDate { get; set; }

		public decimal EntryValue { get; set; }

        [Ignore]
        public Color Background { get; set; }
	}
}