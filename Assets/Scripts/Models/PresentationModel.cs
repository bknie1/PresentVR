using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Directory navigation.
using UnityEngine.UI;

public class PresentationModel {

	private int _currentSlide;
	private Object[] _slides; // Stores our slide pictures (*.PNG, probably)
	private readonly string _PRESENTATIONDIR = "Images\\Presentation";
	private readonly string _PRESENTATIONPLACEHOLDERDIR = "Images\\Presentation\\ERROR";
	private string _imageType = "*.png";
	//-----------------------------------------------------------------------------------
	/// <summary>
	/// Initializes a new instance of the <see cref="PresentationModel"/> class.
	/// </summary>
	public PresentationModel()
	{
		_currentSlide = 0; // We always want to start at the first slide.
		// Load all slide textures found in the folder.
		Debug.Log("PM: Loading slides.");
		try
		{
			// Import images from directory for global use.
			_slides = Resources.LoadAll(_PRESENTATIONDIR, typeof(Texture));

			Debug.Log("PM: " + _slides.Length + " slides loaded from Resources.");
		} catch(MissingReferenceException mre) { Debug.Log (mre.StackTrace); }
		//--------------------------------------------------------------------------------------
		// Loads placeholder if our initial load yields no data. Included in APK, so should exist!
		if (_slides.Length <= 0)
		{
			Debug.Log("PM: Missing slides! Slide Count: " + _slides.Length);
			try
			{
				this._slides = Resources.LoadAll(_PRESENTATIONPLACEHOLDERDIR, typeof(Texture2D));
				Debug.Log("PM: Loaded placeholder slide.");
			} catch(MissingReferenceException mre) { Debug.Log (mre.StackTrace); }
		}
	}
	//-----------------------------------------------------------------------------------
	/// <summary>
	/// Output of files in a given directory.
	/// </summary>
	/// <param name="directory">File directory.</param>
	/// <param name="type">File type.</param>
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
	/// <summary>
	/// User input determines how we iterate through our slides.
	/// </summary>
	public void nextSlide()
	{
		Debug.Log ("PM: Attempting next slide.");
		// -2 offset so we don't load the placeholder.
		if (_currentSlide < _slides.Length - 2) {
			++_currentSlide;
			Debug.Log ("Incrementing to slide " + _currentSlide);
		} else Debug.Log ("PM: Can't go to next slide.");
	}
	public void previousSlide()
	{
		Debug.Log("PM: Attempting previous slide.");
		if (_currentSlide > 0)
		{
			--_currentSlide;
			Debug.Log ("Decrementing to slide " + _currentSlide);
		} else Debug.Log ("PM: Can't go to previous slide.");
	}
	//-----------------------------------------------------------------------------------
	/// <summary>
	/// Returns the image associated with the current slide index.
	/// </summary>
	public Object getCurrentSlide()
	{
		Debug.Log("PM: Returning current slide.");
		return _slides [_currentSlide];
	}
}
