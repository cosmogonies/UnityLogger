using UnityEngine;


//using Goat;

using GoatUtils;

class UnityLogger_Samples: MonoBehaviour
{

	void Start()
	{
		GoatUtils.GoatDebug.Log("test");

		GoatDebug.Log("LIME","bla",null, false);

		GoatDebug.Log("lightblue","My main camera is $t, isn't it?",Camera.main.transform, true);

		GoatDebug.Log("SilVer","This is this",this.gameObject.transform, false);

		GoatDebug.Log("LIME","bla");

		GoatDebug.Log("LIME","bla",true);

		GoatDebug.Log("Some text...",this.gameObject.transform,true);
		
	}


	void Update()
	{

	}


}