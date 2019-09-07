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
    Rigidbody rb;
    // Update is called once per frame
    private void Start()
    {
        transform.Rotate(-90, 0, 0);
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        if (joystick != null)
        {/*
            var x = joystick.Horizontal * Time.deltaTime * rotationSpeed;
            var z = joystick.Vertical * Time.deltaTime * speed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, z, 0);
           */
            Vector3 moveVector = transform.forward * speed;

            Vector3 yaw = joystick.Horizontal * transform.right * rotationSpeed * Time.deltaTime;
            Vector3 pitch = joystick.Vertical * transform.up * rotationSpeed * Time.deltaTime;
            Vector3 dir = yaw + pitch;

            float max = Quaternion.LookRotation(moveVector + dir).eulerAngles.x;

            if (max < 90 && max > 70 || max > 270 && max < 290)
            { }
            else moveVector += dir;

            transform.rotation = Quaternion.LookRotation(moveVector);

            transform.position += moveVector * Time.deltaTime;



        }
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
   

