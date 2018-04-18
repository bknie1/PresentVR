using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleController : MonoBehaviour {

	public float SwipeThreshold = 0.5f;
	private Vector2 startingPosition; // Tracks our starting position.
	private Vector2 currentPosition; // Tracks the last position touched.
	private bool startedTouch; // Have we started swiping?
	private bool pressingButton; // Is the user pressing a button? Ignore other input.
	//-----------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start ()
	{
		startedTouch = false;
		pressingButton = false;
		startingPosition = GvrControllerInput.TouchPosCentered;
		currentPosition = GvrControllerInput.TouchPosCentered;
	}
	//-----------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update ()
	{
		{
			if (GvrControllerInput.AppButtonDown)
			{
				pressingButton = true;
				print("Click App button down.");
			}

			else if (GvrControllerInput.ClickButtonDown)
			{
				pressingButton = true;
				print("Click Touchpad down.");
			}

			else if (GvrControllerInput.IsTouching)
			{
				if (!startedTouch)
				{
					// Start our swiping motion.
					startedTouch = true;
					startingPosition = GvrControllerInput.TouchPos;
					currentPosition = GvrControllerInput.TouchPos;
				}
				else
				{
					// Tracks our position of where we're swiping.
					currentPosition = GvrControllerInput.TouchPos;
				}
			}
			else
			{
				if (startedTouch)
				{
					// Let go of our touchpad, see if we made any swiping motions.
					startedTouch = false;
					Vector2 delta = currentPosition - startingPosition; // The difference between our start and end motion.
					DetectSwipe(delta);
				}
			}
		}
	}
	//-----------------------------------------------------------------------------------------------
	// Prints out the swipe direction (if any) based off of the Vector2 representation of
	// the direction swiped
	private void DetectSwipe(Vector2 delta)
	{
		float y = delta.y;
		float x = delta.x;
		print(delta);

		// x = 0 is far left of touchpad
		// y = 0 is far top of touchpad
		if (!pressingButton)
		{
			if (y > 0 && Mathf.Abs(x) < SwipeThreshold)
			{
				print("Swiped down.");
			}
			else if (y < 0 && Mathf.Abs(x) < SwipeThreshold) 
			{
				print("Swiped up.");
			}
			else if (x > 0 && Mathf.Abs(y) < SwipeThreshold)
			{
				print("Swiped right.");
			}
			else if (x < 0 && Mathf.Abs(y) < SwipeThreshold)
			{
				print("Swiped left.");
			}
		}
		else
		{
			print ("Button release ghost swipe ignored.");
			pressingButton = false; // Button press reset.
		}
	}
	//-----------------------------------------------------------------------------------------------
}
