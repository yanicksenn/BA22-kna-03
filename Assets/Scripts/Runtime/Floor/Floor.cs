using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Floor : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDestroy = new UnityEvent();
    private void OnCollisionEnter(Collision collision)
    {
        var gatter = collision.gameObject.GetComponent<Gatter>();
        if (gatter != null)
        {
            OnDestroy.Invoke();
            Destroy(gatter.gameObject);
        }
            
    }
}