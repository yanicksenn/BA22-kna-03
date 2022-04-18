using UnityEngine;

public class Anchorable : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    void LateUpdate()
    {
        transform.position = anchor.position;
    }
}
