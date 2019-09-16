using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    string p_name;
    public float speed = 10f;
    public float rotationSpeed = 100.0f;
    public FloatingJoystick joystick;
     JoyButton joybutton;
    bool bombShot = false;
    public GameObject bombPrefab;
    [SyncVar] int puntos = 0;
    Rigidbody rb;
    // Update is called once per frame
    private void Start()
    {
     
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (isLocalPlayer) { 
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
        if (!bombShot && joybutton.Pressed)
        {
            bombShot = true;
                Invoke("setBombShotFalse", 1.0f);
            CmdSpawnObject(transform.position,transform.rotation);
            // Give the cloned object an initial velocity along the current
            // object's Z axis
        }
        }
    }

    [Command]
    public void CmdSpawnObject( Vector3 p, Quaternion r)
    {
        GameObject clone;
        clone = Instantiate(bombPrefab, p - new Vector3(0, 0.1f, 0), r);
        clone.GetComponent<Rigidbody>().velocity = Vector3.down;
        NetworkServer.Spawn(clone);

    }

    [Command]
    public void CmdDestroyObject(GameObject goDestroy)
    {
        puntos++;
        NetworkServer.Destroy(goDestroy);
    }
    void setBombShotFalse()
    {
        bombShot = false;

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
   

