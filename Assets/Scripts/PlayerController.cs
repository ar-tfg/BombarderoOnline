using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    string p_name;
    public float speed = 10f;
    public float rotationSpeed = 100.0f;
    public FloatingJoystick joystick;
     JoyButton joybutton;
    bool bombShot = false;
    public GameObject bombPrefab;

    Rigidbody rb;
    // Update is called once per frame
    private void Start()
    {
     
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        if (joystick != null)
        {
            Vector3 moveVector = transform.forward * speed;

            Vector3 yaw = joystick.Horizontal * transform.right * rotationSpeed * Time.deltaTime;
            Vector3 pitch = joystick.Vertical * transform.up * rotationSpeed * Time.deltaTime;
            Vector3 dir = yaw + pitch;

            float max = Quaternion.LookRotation(moveVector + dir).eulerAngles.x;
            
         
            if (max < 90 && max > 70 || max > 270 && max < 290 )
            { }
            else moveVector += dir;

            transform.rotation = Quaternion.LookRotation(moveVector);

            transform.position += moveVector * Time.deltaTime;



        }
        if (!joybutton.Pressed) bombShot = false;
        if (!bombShot && joybutton.Pressed)
        {
            bombShot = true;
           
            GameManager.instance.CmdSpawnObject(bombPrefab,transform.position,transform.rotation);
            // Give the cloned object an initial velocity along the current
            // object's Z axis
        }
    }
    public void SetInputButton(JoyButton jb)
    {
        joybutton = jb;
    }
    public void SetInput(FloatingJoystick js)
    {
        joystick = js;
        
    }
    public void SetPlayerName(string n)
    {

        p_name = n;
        GetComponent<DisplayName>().CmdSetPlayerName(n);
    }
}
   

