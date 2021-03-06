using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Supyrb
{
	/// <summary>
	/// removes a warning popup for mobile builds, that this platform might not be supported:
	/// "Please note that Unity WebGL is not currently supported on mobiles. Press OK if you wish to continue anyway."
	/// </summary>
	/// test
	public class RemoveMobileSupportWarningWebBuild
	{
		[PostProcessBuild]
		public static void OnPostProcessBuild(BuildTarget target, string targetPath)
		{
			if (target != BuildTarget.WebGL)
			{
				return;
			}

			var info = new DirectoryInfo(targetPath);
			var files = info.GetFiles("index.html");
			for (int i = 0; i < files.Length; i++)
			{
				var file = files[i];
				var filePath = file.FullName;
				var text = File.ReadAllText(filePath);
				text = text.Replace("unityShowBanner('WebGL builds are not supported on mobile devices.');", "//" + "unityShowBanner('WebGL builds are not supported on mobile devices.');");
				text = text.Replace("loadingBar.style.display = \"none\";", "window.unityInstance = unityInstance;" + "\n" + "loadingBar.style.display = \"none\";");

				File.WriteAllText(filePath, text);
			}
		}
	}
}