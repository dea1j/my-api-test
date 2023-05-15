using System;
using MAUIapi.Models;

namespace MAUIapi.Contracts
{
	public interface IImageRepository
	{
		public Task UploadImage(ImageEntity imageEntity);
	}
}

