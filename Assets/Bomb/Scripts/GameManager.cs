using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {
   public static GameManager instance;
    public UnityEngine.UI.Text puntosText;
    int floorsD;
	// Use this for initialization
	void Start () {
        floorsD = 0;
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void floorDestroyed()
    {
        floorsD++;
        //puntosText.text = "Puntos = " + floorsD;
    }
    [Command]
    void CmdfloorDestroyed()
    {

    }
}
