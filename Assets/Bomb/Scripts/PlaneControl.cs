using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {

    Joystick joystick;
   // JoyButton joybutton;
    bool disparado = false;
    // Use this for initialization
    public GameObject bomba;
	void Start () {
        joystick = FindObjectOfType<Joystick>();
      //  joybutton = FindObjectOfType<JoyButton>();
	}
	
	// Update is called once per frame
	void Update () {
        var x = joystick.Horizontal *  Time.deltaTime * 150.0f;
        var z = joystick.Vertical *  Time.deltaTime  *3.0f;
        
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    /*    if (!joybutton.Pressed) disparado = false;
        if (!disparado && joybutton.Pressed)
        {
            disparado = true;
            GameObject clone;
            clone = Instantiate(bomba, transform.position - new Vector3(0,0.3f,0), transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down * 2);
        }*/
        
    }
}
