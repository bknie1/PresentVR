# PresentVR

## Documentation

### Class Notes

#### PresentationData : Runtime Script
- Does not need to be attached to an object.
- Responsible for loading presentation images (textures).
- Increments/decrements current slide index. User input occurs elsewhere, though.
- Returns the current presentation image. The request is made elsewhere.

### Behavior

#### Controller
- By default, clicking will increment the current slide index and load the next slide.
- Clicking AND interacting with a specific object will decrement and load the previous slide. Forced due to a limitation of the Daydream Controller UI.