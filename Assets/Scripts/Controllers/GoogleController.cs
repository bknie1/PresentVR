using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleController : MonoBehaviour {

	private static GoogleController _instance;
	private readonly string[] _actions = { "DOWN_SWIPE", "UP_SWIPE", "RIGHT_SWIPE", "LEFT_SWIPE", "APP_BTN_DOWN", "CLICK_BTN_DOWN" };
	private string _action; // Protocol for ProjectionController. Our last recorded action.
	private float _SwipeThreshold = 0.5f;
	private Vector2 _startingPosition; // Tracks our starting position.
	private Vector2 _currentPosition; // Tracks the last position touched.
	private bool _startedTouch; // Have we started swiping?
	private bool _pressingButton; // Is the user pressing a button? Ignore other input.
	//-----------------------------------------------------------------------------------------------
	void Awake()
	{
		if (_instance == null) {
			_instance = this;
		} else Object.Destroy (this);
	}
	//-----------------------------------------------------------------------------------------------
	public static GoogleController Instance { get { return _instance; } }
	//-----------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start ()
	{
		_action = "";
		_startedTouch = false;
		_pressingButton = false;
		_startingPosition = GvrControllerInput.TouchPosCentered;
		_currentPosition = GvrControllerInput.TouchPosCentered;
	}
	//-----------------------------------------------------------------------------------------------
	// Update is called once per frame.
	/// <summary>
	/// Listens for touch controller input.
	/// </summary>
	void Update ()
	{
		_action = ""; // Reset protocol.
		if (GvrControllerInput.AppButtonDown)
		{
			_pressingButton = true;
			_action = _actions[4]; // APP_BTN_DOWN
			print("Click App button down: " + _action);
		}

		else if (GvrControllerInput.ClickButtonDown)
		{
			_pressingButton = true;
			_action = _actions[5]; // CLICK_BTN_DOWN
			print("Click Touchpad down: " + _action);
		}

		else if (GvrControllerInput.IsTouching)
		{
			if (!_startedTouch)
			{
				// Start our swiping motion.
				_startedTouch = true;
				_startingPosition = GvrControllerInput.TouchPos;
				_currentPosition = GvrControllerInput.TouchPos;
			}
			else
			{
				// Tracks our position of where we're swiping.
				_currentPosition = GvrControllerInput.TouchPos;
			}
		}
		else
		{
			if (_startedTouch)
			{
				// Let go of our touchpad, see if we made any swiping motions.
				_startedTouch = false;
				Vector2 delta = _currentPosition - _startingPosition; // The difference between our start and end motion.
				DetectSwipe(delta);
			}
		}
	}
	//-----------------------------------------------------------------------------------------------
	/// <summary>
	/// Prints out the swipe direction (if any) based off of the Vector2 representation of the direction swiped.
	/// </summary>
	/// <param name="delta">Swipe distance delta (start to end)</param>
	private void DetectSwipe(Vector2 delta)
	{
		float y = delta.y;
		float x = delta.x;
		print(delta);

		// x = 0 is far left of touchpad.
		// y = 0 is far top of touchpad.
		if (!_pressingButton)
		{
			if (y > 0 && Mathf.Abs(x) < _SwipeThreshold)
			{
				_action = _actions [0]; // DOWN_SWIPE
				print("Swiped down: " + _action);
			}
			else if (y < 0 && Mathf.Abs(x) < _SwipeThreshold) 
			{
				// Laser Pointer
				_action = _actions [1]; // UP_SWIPE
				print("Swiped up: " + _action);
			}
			else if (x > 0 && Mathf.Abs(y) < _SwipeThreshold)
			{
				// Next slide.
				_action = _actions [2]; // RIGHT_SWIPE
				print("Swiped right: " + _action);
			}
			else if (x < 0 && Mathf.Abs(y) < _SwipeThreshold)
			{
				// Previous slide.
				_action = _actions [3]; // LEFT_SWIPE
				print("Swiped left: " + _action);
			}
			// Send message to ProjectionController.
		}
		else
		{
			print ("Button release ghost swipe ignored.");
			_pressingButton = false; // Button press reset.
		}
	}
	//-----------------------------------------------------------------------------------------------
	/// <summary>
	///  Allows ProjectionController to monitor our input protocol and act accordingly.
	/// </summary>
	/// <returns>The most recent action.</returns>
	public string getAction()
	{
		return _action;
	}
	//-----------------------------------------------------------------------------------------------
}
