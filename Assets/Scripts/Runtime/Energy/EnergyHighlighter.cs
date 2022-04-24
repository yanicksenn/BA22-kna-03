using UnityEngine;

public class EnergyHighlighter : MonoBehaviour
{
    [SerializeField] private Material trueMaterial;
    [SerializeField] private Material falseMaterial;

    private IConductor conductor;
    public IConductor Conductor
    {
        get => conductor;
        set => conductor = value;
    }

    private Renderer renderer;
    private Material originalMaterial;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    
    private void Start()
    {
        originalMaterial = renderer.material;
    }

    private void Update()
    {
        if (conductor == null)
            return;
        
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