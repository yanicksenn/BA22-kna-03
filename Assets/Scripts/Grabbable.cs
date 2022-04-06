using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    [SerializeField] 
    private Material isGrabbableMaterial;
    public Material IsGrabbableMaterial
    {
        get => isGrabbableMaterial;
        set => isGrabbableMaterial = value;
    }

    private Material originalMaterial;
    private Renderer renderer;
    
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }
    
    public void Grab() => renderer.material = isGrabbableMaterial;
    public void Release() => renderer.material = originalMaterial;
}
