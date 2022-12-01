using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror; 

public class ChooseCharacter : NetworkManager
{
    Vector3 spawnPos = new Vector3(0, 0, 0);
    public override void OnStartServer()
    {
        base.OnStartServer();
    }


    public override void OnClientConnect()
    {
        base.OnClientConnect();
        InstantiatePrefab();
    }
    void InstantiatePrefab()
    {
        GameObject gameobject = Instantiate(playerPrefab);
       // NetworkServer.AddPlayerForConnection(gameobject);
    }
}
