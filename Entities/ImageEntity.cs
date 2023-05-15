using System;
using System.ComponentModel.DataAnnotations;

namespace MAUIapi.Models
{
	public class ImageEntity
	{
		public int Id { get; set; }
		public byte[]? ImageData { get; set; }
		public DateTime Timestamp { get; set; }
	}
}

