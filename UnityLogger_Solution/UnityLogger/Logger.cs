using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goat
{
	public static class Logger
	{
		
		public static void Log(string _Text)
		{
			Log("white", _Text, null, true);
		}

		public static void Log(string _Text, bool _IncludeFrameCount)
		{
			Log("white", _Text, null, _IncludeFrameCount);
		}

		public static void Log(string _Text, UnityEngine.Transform _Transform)
		{
			Log("white", _Text, _Transform, true);
		}
		
		public static void Log(string _Color, string _Text, UnityEngine.Transform _Transform, bool _IncludeFrameCount)
		{
			
			string TextFormatted = "";

			//Frame Prefixing
			if(_IncludeFrameCount)
				TextFormatted += "["+UnityEngine.Time.frameCount+"] ";		//Maybe put a ZFILL-like rule to keep same number of digits ?



			//Coloring			http://docs.unity3d.com/Manual/StyledText.html
			if(! ValidateColor(_Color))
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
			UnityEngine.Debug.Log(TextFormatted);

		}


		private static  bool ValidateColor(string _ColorName)
		{
			// Determine if given color is correct according to:
		
			//http://docs.unity3d.com/Manual/StyledText.html


			Dictionary<string,string> Database = new Dictionary<string,string>();
			Database["aqua"] = "#00ffffff";//(same as cyan)
			Database["black"] = "#000000ff";
			Database["blue"] = "#0000ffff";
			Database["brown"] = "#a52a2aff";
			Database["cyan"] = "#00ffffff";	//(same as aqua)
			Database["darkblue"] = "#0000a0ff";
			Database["fuchsia"] = "#ff00ffff";//(same as magenta)
			Database["green"] = "#008000ff";
			Database["grey"] = "#808080ff";
			Database["lightblue"] = "#add8e6ff";
			Database["lime"] = "#00ff00ff";
			Database["magenta"] = "#ff00ffff";//(same as fuchsia)
			Database["maroon"] = "#800000ff";
			Database["navy"] = "#000080ff";
			Database["olive"] = "#808000ff";
			Database["orange"] = "#ffa500ff";
			Database["purple"] = "#800080ff";
			Database["red"] = "#ff0000ff";
			Database["silver"] = "#c0c0c0ff";
			Database["teal"] = "#008080ff";
			Database["white"] = "#ffffffff";
			Database["yellow"] = "#ffff00ff";

			if(Database.ContainsKey( _ColorName.ToLower() ) )
			{
				return true;
			}
			else
				return false;
		}
		
		
	}
}


/*



 */