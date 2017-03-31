using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.InteropServices;
using System;

public class ViSPpluginAdapter {

// Selection of DLL depends from the system
#if UNITY_STANDALONE_WIN
	const string dllPath = "ViSPplugin";
#elif UNITY_STANDALONE_LINUX
	const string dllPath = "ViSPpluginUNIX";  
#else 
	const string dllPath = "";
#endif

	[DllImport(dllPath, EntryPoint = "GetProjection", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool GetProjectionP(double x, double y, double z, double[] results, int size);

	// Returns the plugin formatted output
	public static string GetProjection(Vector3 position) {
		if (string.Equals (dllPath, "", StringComparison.Ordinal)) {
			return "can't find library ViSPplugin";
		} else {
			// Allocate memory for the results
			double[] results = new double[10];
			// Get the plugin output
			if (!GetProjectionP (position.x, position.y, position.z, results, results.Length)) {
				return "Calculation fails";
			}
			// Converting the output
			StringBuilder builder = new StringBuilder ();
			builder.Append ("3D coordinates of the point in the object frame: ")
				.AppendFormat ("({0:0.00}, {1:0.00}, {2:0.00}) {3}", results [0], 
					results [1], results [2], Environment.NewLine);
			builder.Append ("3D coordinates of the point in the camera frame: ")
				.AppendFormat ("({0:0.00}, {1:0.00}, {2:0.00}) {3}", results [3], 
					results [4], results [5], Environment.NewLine);
			builder.Append ("2D coordinates of the point in the camera plane: ")
				.AppendFormat ("({0:0.00}, {1:0.00}) {2}", results [6], 
					results [7], Environment.NewLine);
			builder.Append ("2D coordinates of the point in the image: ")
				.AppendFormat ("({0:0.00}, {1:0.00}) {2}", results [8], 
					results [9], Environment.NewLine); 
			return builder.ToString ();
		}
	}
}
