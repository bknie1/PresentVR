using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For RawImage

public class ProjectionController : MonoBehaviour {
	private PresentationModel pm; // Loads presentation images, tracks current slide, returns current image.
	private RawImage projection;
	//------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		PresentationModel pm = new PresentationModel (); // Initialize model.

		projection = gameObject.GetComponentInChildren<RawImage> (); // Image display.
		try
		{
			Debug.Log("PC: Loading initial slide.");
			Texture currentSlideImage = (Texture)pm.getCurrentSlide(); // Fetches the first slide.
			projection.texture = currentSlideImage; // Push slide on to display.
		}
		// If, for whatever reason, we're missing both the desired slides and error/placeholder.
		catch(MissingReferenceException mre)
		{
			print (mre.StackTrace);
		}
	}
	//------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update ()
	{
		// TODO: If button pressed -> Get next slide.
		// TODO: If button pressed and projection selected -> Get previous slide.
	}
	//------------------------------------------------------------------------------------------
	private void loadSlide()
	{

	}
}
