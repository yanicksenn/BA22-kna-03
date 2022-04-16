using UnityEngine;

public class CableAnchor : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    void LateUpdate()
    {
        transform.position = anchor.position;
    }
}
