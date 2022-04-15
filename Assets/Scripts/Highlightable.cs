using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Highlightable : MonoBehaviour
{
    [SerializeField] 
    private Material highlightMaterial;
    public Material HighlightMaterial
    {
        get => highlightMaterial;
        set => highlightMaterial = value;
    }

    private Material originalMaterial;
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        originalMaterial = renderer.material;
    }
    
    public void Grab() => renderer.material = highlightMaterial;
    public void Release() => renderer.material = originalMaterial;
}
