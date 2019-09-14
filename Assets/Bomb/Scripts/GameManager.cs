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
    public void CmdfloorDestroyed(GameObject objToDestroy)
    {
        NetworkServer.UnSpawn(objToDestroy);
        NetworkServer.Destroy(objToDestroy);
    }
    [Command]

    public void CmdSpawnObject(GameObject objToSpawn, Vector3 p, Quaternion r)
    {
        GameObject clone;
        clone = Instantiate(objToSpawn, p - new Vector3(0, 0.1f, 0), r);
        NetworkServer.Spawn(clone);
        clone.GetComponent<Rigidbody>().velocity = Vector3.down;

    }
}
