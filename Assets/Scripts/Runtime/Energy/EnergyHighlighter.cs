using UnityEngine;

public class EnergyHighlighter : MonoBehaviour
{
    [SerializeField] private Material trueMaterial;
    [SerializeField] private Material falseMaterial;
    
    private Renderer renderer;
    private IConductor conductor;
    
    private Material originalMaterial;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        conductor = GetComponentInParent<IConductor>();
    }
    
    private void Start()
    {
        originalMaterial = renderer.material;
    }

    private void Update()
    {
        var energy = conductor.GetEnergy();
        switch (energy)
        {
            case EnergyType.True when renderer.material != trueMaterial:
                renderer.material = trueMaterial;
                break;
            
            case EnergyType.False when renderer.material != falseMaterial:
                renderer.material = falseMaterial;
                break;
            
            default:
            {
                if (renderer.material != originalMaterial)
                    renderer.material = originalMaterial;
                break;
            }
        }
    }
}