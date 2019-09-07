using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour {

    // Use this for initialization
    public float TTL;
    

    void Start () {
        Destroy(this.gameObject, TTL);
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }


}
