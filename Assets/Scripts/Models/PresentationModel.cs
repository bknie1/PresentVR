using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Directory navigation.
using UnityEngine.UI;

public class PresentationModel {

	private int currentSlide;
	private Object[] slides; // Stores our slide pictures (*.PNG, probably)
	private string presentationDir = "Images\\Presentation";
	private string presentationPlaceholderDir = "Images\\Presentation\\ERROR";
	private string imageType = "*.png";
	//-----------------------------------------------------------------------------------
	public PresentationModel()
	{
		currentSlide = 0; // We always want to start at the first slide.
		// Load all slide textures found in the folder.
		Debug.Log("PM: Loading slides.");
		try
		{
			// Import images from directory for global use.
			slides = Resources.LoadAll(presentationDir, typeof(Texture));

			Debug.Log("PM: " + slides.Length + " slides loaded from Resources.");
		} catch(MissingReferenceException mre) { Debug.Log (mre.StackTrace); }
		//--------------------------------------------------------------------------------------
		// Loads placeholder if our initial load yields no data. Included in APK, so should exist!
		if (slides.Length <= 0)
		{
			Debug.Log("PM: Missing slides! Slide Count: " + slides.Length);
			try
			{
				this.slides = Resources.LoadAll(presentationPlaceholderDir, typeof(Texture2D));
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
		if(currentSlide < slides.Length) ++currentSlide;
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
		return slides [currentSlide]; // Returns the current slide image.
	}
}
