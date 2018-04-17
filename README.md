# PresentVR

## Documentation

### Class Notes

#### PresentationModel (A Runtime Class)
- Does not need to be attached to an object.
- Responsible for loading presentation images (textures).
- Increments/decrements current slide index. User input occurs elsewhere, though.
- Returns the current presentation image. The request is made elsewhere.

#### ProjectionController (Monobehavior)
- Instantiates our PresentationModel.
- Updates our Projection object (View) by fetching the appropriate slide image from PresentationModel.
- Reacts to requests from our Google Controller event listener interface.

#### GoogleController (Monobehavior)
- Listens for user input.
- Makes requests to ProjectionController.
- Ideally, the Controller would feature directional trackpad controls, but the reality is that we only have touch, click, and the app button to work with.
- Most of the Google Daydream's interactions need to rely on being able to point at objects (via raycast), digesting what we're pointing at, and reacting accordingly. It's a glorified Wiimote.

### Behavior

#### Controller
- By default, clicking will increment the current slide index and load the next slide.
- Clicking AND interacting with a specific object will decrement and load the previous slide. Forced due to a limitation of the Daydream Controller UI.

### Design

![alt text](https://github.com/bknie1/PresentVR/blob/master/Documentation/Diagrams/InitialDesign.png "Initial Design Concept")

### Images

## Day 1 - The Ugly Truth

![alt_text](https://github.com/bknie1/PresentVR/blob/master/Documentation/Images/Early-1.png "Day 1")

## Day 2 - Wow, that's better.

![alt_text](https://github.com/bknie1/PresentVR/blob/master/Documentation/Images/Early-2.png "Day 2 -1")

![alt_text](https://github.com/bknie1/PresentVR/blob/master/Documentation/Images/Early-3.PNG "Day 2 -2")

![alt_text](https://github.com/bknie1/PresentVR/blob/master/Documentation/Images/Early-4.PNG "Day 2 -3")

![alt_text](https://github.com/bknie1/PresentVR/blob/master/Documentation/Images/Early-5.PNG "Day 2 -4")
