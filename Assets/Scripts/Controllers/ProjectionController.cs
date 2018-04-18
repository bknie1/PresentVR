using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For RawImage

public class ProjectionController : MonoBehaviour {
	private PresentationModel _pm; // Loads presentation images, tracks current slide, returns current image.
	private RawImage _projection;
	private string _currentAction;
	private Texture _currentSlideImage;
	//------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		_currentAction = "";
		_pm = new PresentationModel (); // Initialize model.
		_projection = gameObject.GetComponentInChildren<RawImage> (); // Image display.
		try
		{
			Debug.Log("PC: Loading initial slide.");
			_currentSlideImage = (Texture)_pm.getCurrentSlide(); // Fetches the first slide.
			_projection.texture = _currentSlideImage; // Push slide on to display.
		}
		// If, for whatever reason, we're missing both the desired slides and error/placeholder.
		catch(MissingReferenceException mre)
		{
			print (mre.StackTrace);
		}
	}
	//------------------------------------------------------------------------------------------
	// Update is called once per frame
	/// <summary>
	/// Fetches the most recent input protocol action. See GoogleController for protocol specifics.
	/// </summary>
	void Update ()
	{
		// Fetch action from GoogleController. We're only interested in left/right swipes.
		_currentAction = GoogleController.Instance.getAction();

		switch (_currentAction)
		{
		case "LEFT_SWIPE":
			_pm.previousSlide ();
			loadSlide ();
			break;
		case "RIGHT_SWIPE":
			_pm.nextSlide ();
			loadSlide ();
			break;
		default:
			// Protocol message not applicable to the projection. Ignore it.
			break;
		}
	}
	//------------------------------------------------------------------------------------------
	void loadSlide()
	{
		_currentSlideImage = (Texture)_pm.getCurrentSlide ();
		_projection.texture = _currentSlideImage; // Push slide on to display.
	}
	//------------------------------------------------------------------------------------------
}
