﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlirtingApp.Application.Common.Interfaces.ThirdPartyVendors.Cloudinary
{
	public class ImageUploadOptions
	{
		public string FileName { get; set; }
		public Stream FileStream { get; set; }
	}
}
