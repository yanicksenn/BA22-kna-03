using UnityEngine;

[RequireComponent(typeof(Grabbable))]
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
    private Grabbable grababble;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        grababble = GetComponent<Grabbable>();
    }

    private void OnEnable()
    {
        grababble.OnGrab.AddListener(Grab);
        grababble.OnRelease.AddListener(Release);
    }

    private void OnDisable()
    {
        grababble.OnGrab.RemoveListener(Grab);
        grababble.OnRelease.RemoveListener(Release);
    }

    private void Start()
    {
        originalMaterial = renderer.material;
    }
    
    private void Grab() => renderer.material = highlightMaterial;
    private void Release() => renderer.material = originalMaterial;
}
