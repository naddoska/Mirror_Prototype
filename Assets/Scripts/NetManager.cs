using UnityEngine;
using Mirror;

public class NetManager : NetworkManager
{
    [Header("Network State")]
    [SerializeField] bool isClient = false;
    [SerializeField] bool isHost = true;
    [SerializeField] bool isServer = false;
    public override void Awake()
    {
        base.Awake();
        ChooseConnectionState();
    }
    void ChooseConnectionState()
    {
        if (isClient)
        {
            StartClient();
        }
        else if (isHost)
        {
            StartHost();
        }
        else if (isServer)
        {
            StartServer();
        }
    }
}