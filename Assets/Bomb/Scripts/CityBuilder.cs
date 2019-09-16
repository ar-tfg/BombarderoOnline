using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CityBuilder : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject floor;
    int[,] map = new int[5, 5] { { 1, 2 ,1,2,1},
                                { 2, 3,2,3,2 }, 
                                { 1, 3 ,5,3,1},
                                { 2, 3,2,3,2 },
                                 { 1, 2,1,2,1 }};
    void Start()
    {
        for(int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                int aux = map[i + 2, j + 2];
                for (int e = 0; e < aux; e++)
                Cmdbuild(i ,e, j);

            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Command]
    void Cmdbuild(int x,int y,int z)
    {
        GameObject clone;
        clone = Instantiate(floor, new Vector3(x,y,z)/5.0f, Quaternion.identity, transform);
        NetworkServer.Spawn(clone);
    }
}
