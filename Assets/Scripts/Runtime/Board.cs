using UnityEngine;

public class Board : MonoBehaviour
{
    private Socket[] sockets;

    private void Awake()
    {
        sockets = GetComponentsInChildren<Socket>();
    }
}