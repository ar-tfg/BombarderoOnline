using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class FloorLogic : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomba"))
        {
            GameObject.Find("LocalPlayer").GetComponent<PlayerController>().CmdDestroyObject(gameObject);
            //GameManager.instance.CmdfloorDestroyed(this.gameObject);
            // Destroy(this.gameObject);

        }
    }
    
}
