using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Floor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var gatter = collision.gameObject.GetComponent<Gatter>();
        if (gatter != null)
            Destroy(gatter.gameObject);
    }
}