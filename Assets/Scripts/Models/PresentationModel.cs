using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Directory navigation.
using UnityEngine.UI;

public class PresentationModel {

	private int currentSlide;
	private Object[] resources; // Stores our slide pictures (*.PNG, probably)
	private string presentationDir = "Assets\\Images\\Presentation";
	private string presentationPlaceholderDir = "Assets\\Images\\Presentation\\ERROR";
	private string imageType = "*.png";
	//-----------------------------------------------------------------------------------
	public PresentationModel()
	{
		currentSlide = 0; // We always want to start at the first slide.
		// Load all slide textures found in the folder.
		Debug.Log("PM: Loading slides.");
		try
		{
			// directoryTrace(presentationDir, imageType); // DEBUG

			// Import images from directory for global use.
			this.resources = Resources.LoadAll(presentationDir, typeof(Texture));

			Debug.Log("PM: " + resources.Length + " slides loaded from Resources.");
		} catch(MissingReferenceException mre) { Debug.Log (mre.StackTrace); }
		//--------------------------------------------------------------------------------------
		// Loads placeholder if our initial load yields no data. Included in APK, so should exist!
		if (resources.Length <= 0)
		{
			Debug.Log("PM: Missing slides! Slide Count: " + resources.Length);
			try
			{
				// directoryTrace(presentationPlaceholderDir, imageType); // DEBUG

				this.resources = Resources.LoadAll(presentationPlaceholderDir, typeof(Texture));
				Debug.Log("PM: Loaded placeholder slide.");
			} catch(MissingReferenceException mre) { Debug.Log (mre.StackTrace); }
		}
	}
	//-----------------------------------------------------------------------------------
	private void directoryTrace(string directory, string type)
	{
		Debug.Log ("Directory File Trace:");
		DirectoryInfo dir = new DirectoryInfo(directory); // Data folder.
		FileInfo[] files = dir.GetFiles(type); // Fetch all PNG files. Could inject other formats later, if we wanted.
		foreach(var i in files)
		{
			Debug.Log(i);
		}
	}
	//-----------------------------------------------------------------------------------
	/**
	 * User input determines how we iterate through our slides.
	**/
	public void nextSlide()
	{
		Debug.Log("PM: Next slide.");
		if(currentSlide < resources.Length) ++currentSlide;
	}
	//-----------------------------------------------------------------------------------
	public void previousSlide()
	{
		Debug.Log("PM: Previous slide.");
		if (currentSlide > 0) --currentSlide;
	}
	//-----------------------------------------------------------------------------------
	public Object getCurrentSlide()
	{
		Debug.Log("PM: Returning current slide.");
		return resources [currentSlide]; // Returns the current slide image.
	}
}
