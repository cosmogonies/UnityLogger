using UnityEngine;

using Goat;

class UnityLogger_Samples: MonoBehaviour
{

	void Start()
	{

		Goat.Logger.Log("test");

		Logger.Log("LIME","bla",null, false);

		Logger.Log("lightblue","My main camera is $t, isn't it?",Camera.main.transform, true);

		Logger.Log("SilVer","This is this",this.gameObject.transform, false);



	}


	void Update()
	{

	}


}