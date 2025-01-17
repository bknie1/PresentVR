using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInterface : MonoBehaviour {
	//-------------------------------------------------------------------------
	public void LoadPresentation() {
		Debug.Log ("Starting presentation.");
		SceneManager.LoadScene ("01_Presentation");
	}
	//-------------------------------------------------------------------------
	public void ExitApplication() {
		Debug.Log ("Quitting application.");
		Application.Quit ();
	}
	//-------------------------------------------------------------------------
}
