using System;
using System.IO;

public static class FileHelper
{
	public static int JSONFileCount(DirectoryInfo d)
	{
		int i = 0;
		FileInfo[] fis = d.GetFiles();
		foreach (FileInfo fi in fis)
		{
			if (fi.Extension.Contains("json"))
				i++;
		}
		return i;
	}
}
