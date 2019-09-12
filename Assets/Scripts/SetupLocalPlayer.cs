using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject mainInputField;
    public GameObject inputField;
    public GameObject js;
    public GameObject jb;


    public Material[] texturas;
    void Start()
    {

        makeVisible(false);

        if (isLocalPlayer)
        {
            GetComponent<PlayerController>().enabled = true;
            GameObject input = Instantiate(js, GameObject.FindGameObjectWithTag("Canvas").transform);
            GameObject inputButton = Instantiate(jb, GameObject.FindGameObjectWithTag("Canvas").transform);
       //     inputField =  Instantiate(mainInputField.gameObject, GameObject.FindGameObjectWithTag("Canvas").transform);
            GetComponent<PlayerController>().SetInput(input.GetComponent<FloatingJoystick>());
            GetComponent<PlayerController>().SetInputButton(inputButton.GetComponent<JoyButton>());

            GetComponent<MeshRenderer>().material = texturas[2];

            //  inputField.gameObject.SetActive(true);

        }
        else GetComponent<MeshRenderer>().material = texturas[3];
    }
    

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
               // if (inputField.GetComponent<InputField>().text != "" && Input.GetMouseButtonUp(0))
            {

                //   getName();
            }
        }
    }
    public void getName()
    {
        if (isLocalPlayer)
        {
            //Camera.main.GetComponent<SmoothCamera>().setTarget(transform);
            //inputField.SetActive(false);

            //GetComponent<PlayerController>().SetPlayerName(inputField.GetComponent<InputField>().text);
        }
    }

  
    public void makeVisible(bool b)
    {
      //  gameObject.SetActive(b);
        gameObject.GetComponent<MeshRenderer>().enabled = b;
        
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = b;
    }
    public void Reposisionate()
    {
        gameObject.transform.position = new Vector3( (float)GameObject.FindGameObjectsWithTag("Player").Length/10,0.5f,0);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
