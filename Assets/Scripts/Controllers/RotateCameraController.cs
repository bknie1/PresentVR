using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateCameraController : MonoBehaviour {
    private float _speed = 5.0f;
    private float _spacing = 0.2f;
    //------------------------------------------------------------------------------------------
    // Use this for initialization
    // Implements a rotation.
    void Start () {
    }
    //------------------------------------------------------------------------------------------
    // Update is called once per frame
    // Turns the player's view.
    void Update () {
        //WASD_Input ();
        Mouse_Input ();
    }
    //------------------------------------------------------------------------------------------
    // Detects camera rotation.
    void Mouse_Input() {
        if (Input.GetMouseButton(1)) {
            float mouse_x = Input.GetAxis ("Mouse X") * _speed;
            float mouse_y = Input.GetAxis ("Mouse Y") * _speed;
            Camera camera = GetComponentInChildren<Camera> ();
            // Camera Gimble
            camera.transform.localRotation = Quaternion.Euler (-mouse_y, 0, 0) * camera.transform.localRotation;
            // Player Body
            this.transform.localRotation = Quaternion.Euler (0, mouse_x, 0) * transform.localRotation;
        }
    }
    //------------------------------------------------------------------------------------------
    // Strafe Input
    void WASD_Input() {
        // Camera position in scene space.
        Vector3 pos = this.transform.position;
        if (Input.GetKey (KeyCode.W)) {
            pos.z += _spacing;
            Debug.Log ("Moving forward.");
        }
        if (Input.GetKey (KeyCode.A)) {
            pos.x -= _spacing;
            Debug.Log ("Turning left.");
        }
        if (Input.GetKey (KeyCode.S)) {
            pos.z -= _spacing;
            Debug.Log ("Moving backward.");
        }
        if (Input.GetKey (KeyCode.D)) {
            pos.x += _spacing;
            Debug.Log ("Turning right.");
        }
        // Update the x/z position at the end of each frame.
        this.transform.position = pos;
    }
}