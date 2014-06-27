This is a Unity3d logger extension.

The project started as a forked of github repository : kreso22/Unity-3D-Debug-console-with-color.


* Purposes

The main idea is to provide a toolkit to log into unity console easily,
adding some formating help, like richtext and framecount.

* Installation

Basically you just need to put in your project Assets folder:
Assets\...\Plugins\UnityLogger.dll

Then you have to write in your game scripts :
<blockquote>
using Goat;

Goat.Logger.Log("test");
Logger.Log("LIME","bla",null, false);
Logger.Log("lightblue","My main camera is $t, isn't it?",Camera.main.transform, true);
Logger.Log("SilVer","This is this",this.gameObject.transform, false);
</blockquote>

* How it work ?

We do not overwrite the "real" Debug.Log with a delegate-hack method.
The trick here is to create a logging function in c#, but as a compiled DLL, which call (after some additional logic), the real Debug.Log
When the user double-clic on the console, Unity CAN'T reach the Log function code definition because of its DLL encapsulation, so it skip the first call stack and teleport you to the next one... the one into the script user.


* How to modify/recompile myself ?

(This tutorial is based on methods decribed here : http://docs.unity3d.com/Manual/UsingDLL.html
Please notice they could have changed in next Unity version to (4.5) so follow them instead)

1) Open an empty MonoDevelop.

2) File > New ... Solution

3) Pick C# Empty Library

4) Choose your location and name (do not matter).

5) Overwrite the default file MyClass.cs by the UnityLogger.cs

6) Project>"Edit References" : in .NET Assembly tab, browse into C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll and click Add button.

7) Right click on the Solution Viewport on your project name, and select BuildALL

8) You will obtain the .\bin\Debug\UnityLogger.dll ! Copy it in your unity project, into a Plugins folder.






