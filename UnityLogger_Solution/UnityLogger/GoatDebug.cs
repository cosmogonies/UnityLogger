using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoatUtils
{
	
	
	public static class GoatDebug
	{
		const bool DEFAULT_INCLUDE_FRAMECOUNT = false;
		const string DEFAULT_COLOR = "white";
		const Transform DEFAULT_TRANSFORM = null;

		private static readonly Dictionary<string, string> ColorDatabase
			= new Dictionary<string, string>
		{
			//  { Database["aqua"] = "#00ffffff";//(same as cyan)
			//  { Database["black"] = "#000000ff";
			{ "blue" , "#5883edff" },
			//  { Database["brown"] = "#a52a2aff" },
			{ "cyan" , "#00ffffff" }, //(same as aqua)
			//  { "darkblue" , "#0000a0ff" },
			//  { "fuchsia" , "#ff00ffff" },//(same as magenta)
			{ "green" , "#4dd14dff" },
			{ "gray" , "#808080ff" },
			{ "grey" , "#808080ff" },
			{ "lightblue" , "#add8e6ff" },
			{ "lime" , "#00ff00ff" },
			{ "magenta" , "#ff00ffff" },//(same as fuchsia)
			//{ "maroon" , "#800000ff" },
			//{ "navy" , "#000080ff" },
			{ "olive" , "#9e9e4bff" },
			{ "orange" , "#ffa500ff" },
			//{ "purple" , "#800080ff" },
			{ "red" , "#ff0000ff" },
			//{ "silver" , "#c0c0c0ff" },
			//{ "teal" , "#008080ff" },
			{ "white" , "#ffffffff" },
			{ "yellow" , "#ffff00ff" }
		};

		private enum Severity {Normal, Warning, Error};

		public static void Log(string _Text)																	{ Log(Severity.Normal, DEFAULT_COLOR, _Text, DEFAULT_TRANSFORM, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void Log(string _Color, string _Text)														{ Log(Severity.Normal, _Color, _Text, DEFAULT_TRANSFORM, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void Log(string _Color, string _Text, bool _IncludeFrameCount)							{ Log(Severity.Normal, _Color, _Text, DEFAULT_TRANSFORM, _IncludeFrameCount);}
		public static void Log(string _Color, string _Text, Transform _Transform)								{ Log(Severity.Normal, _Color, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void Log(string _Text, bool _IncludeFrameCount)											{ Log(Severity.Normal, DEFAULT_COLOR, _Text, DEFAULT_TRANSFORM, _IncludeFrameCount);}
		public static void Log(string _Text, Transform _Transform)												{ Log(Severity.Normal, DEFAULT_COLOR, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void Log(string _Text, Transform _Transform, bool _IncludeFrameCount)						{ Log(Severity.Normal, DEFAULT_COLOR, _Text, _Transform, _IncludeFrameCount);}
		public static void Log(Transform _Transform, string _Text)												{ Log(Severity.Normal, DEFAULT_COLOR, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void Log(string _Color, string _Text, Transform _Transform, bool _IncludeFrameCount)		{ Log(Severity.Normal, _Color, _Text,_Transform, _IncludeFrameCount);}
		
		public static void LogWarning(string _Text)																{ Log(Severity.Warning, DEFAULT_COLOR, _Text, DEFAULT_TRANSFORM, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogWarning(string _Color, string _Text)												{ Log(Severity.Warning, _Color, _Text, DEFAULT_TRANSFORM, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogWarning(string _Color, string _Text, bool _IncludeFrameCount)						{ Log(Severity.Warning, _Color, _Text, DEFAULT_TRANSFORM, _IncludeFrameCount);}
		public static void LogWarning(string _Color, string _Text, Transform _Transform)						{ Log(Severity.Warning, _Color, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogWarning(string _Text, bool _IncludeFrameCount)									{ Log(Severity.Warning, DEFAULT_COLOR, _Text, DEFAULT_TRANSFORM, _IncludeFrameCount);}
		public static void LogWarning(string _Text, Transform _Transform)										{ Log(Severity.Warning, DEFAULT_COLOR, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogWarning(string _Text, Transform _Transform, bool _IncludeFrameCount)				{ Log(Severity.Warning, DEFAULT_COLOR, _Text, _Transform, _IncludeFrameCount);}
		public static void LogWarning(Transform _Transform, string _Text)										{ Log(Severity.Warning, DEFAULT_COLOR, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogWarning(string _Color,string _Text, Transform _Transform, bool _IncludeFrameCount){ Log(Severity.Warning, _Color, _Text,_Transform, _IncludeFrameCount);}
		
		public static void LogError(string _Text)																{ Log(Severity.Error, DEFAULT_COLOR, _Text, DEFAULT_TRANSFORM, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogError(string _Color, string _Text)												{ Log(Severity.Error, _Color, _Text, DEFAULT_TRANSFORM, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogError(string _Color, string _Text, bool _IncludeFrameCount)						{ Log(Severity.Error, _Color, _Text, DEFAULT_TRANSFORM, _IncludeFrameCount);}
		public static void LogError(string _Color, string _Text, Transform _Transform)							{ Log(Severity.Error, _Color, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogError(string _Text, bool _IncludeFrameCount)										{ Log(Severity.Error, DEFAULT_COLOR, _Text, DEFAULT_TRANSFORM, _IncludeFrameCount);}
		public static void LogError(string _Text, Transform _Transform)											{ Log(Severity.Error, DEFAULT_COLOR, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogError(string _Text, Transform _Transform, bool _IncludeFrameCount)				{ Log(Severity.Error, DEFAULT_COLOR, _Text, _Transform, _IncludeFrameCount);}
		public static void LogError(Transform _Transform, string _Text)											{ Log(Severity.Error, DEFAULT_COLOR, _Text, _Transform, DEFAULT_INCLUDE_FRAMECOUNT);}
		public static void LogError(string _Color, string _Text, Transform _Transform, bool _IncludeFrameCount)	{ Log(Severity.Error, _Color, _Text,_Transform, _IncludeFrameCount);}
		
		private static void Log(Severity _Severity, string _Color, string _Text, UnityEngine.Transform _Transform, bool _IncludeFrameCount)
		{
			if (! Debug.isDebugBuild )
				return;


			string TextFormatted = "";
			
			//Frame Prefixing
			if(_IncludeFrameCount)
				TextFormatted += "["+UnityEngine.Time.frameCount+"] ";		//Maybe put a ZFILL-like rule to keep same number of digits ?

			//Coloring			http://docs.unity3d.com/Manual/StyledText.html
			if( ColorDatabase.ContainsKey(_Color))
				_Color=ColorDatabase[_Color];
			else
				_Color="white";
			TextFormatted += "<color=\""+_Color+"\">" + _Text + "</color>";
			
			
			//Transforming
			if(_Transform != null)
			{
				if(TextFormatted.Contains("$t"))
					TextFormatted = TextFormatted.Replace("$t","<i>\""+_Transform.name+"</i>\"");
				else
					TextFormatted += "\t{"+"<i>\""+_Transform.name+"</i>\""+"}";
			}

			//http://docs.unity3d.com/ScriptReference/Debug.Log.html
			if( _Severity == Severity.Normal )
				UnityEngine.Debug.Log(TextFormatted);
			if( _Severity == Severity.Warning )
				UnityEngine.Debug.LogWarning(TextFormatted);
			if( _Severity == Severity.Error )
				UnityEngine.Debug.LogError(TextFormatted);
		}
		
		
	}
}


/*
 */