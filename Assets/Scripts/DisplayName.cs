using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class DisplayName : NetworkBehaviour
{
  
public TextMesh NameMesh;

    [Command]
    public void CmdSetPlayerName(string n)
    {

        NameMesh.text = n;
    }
}
