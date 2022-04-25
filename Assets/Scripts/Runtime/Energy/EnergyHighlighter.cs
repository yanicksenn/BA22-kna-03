using UnityEngine;

public class EnergyHighlighter : MonoBehaviour
{
    [SerializeField] private Cable cable;
    [SerializeField] private Material trueMaterial;
    [SerializeField] private Material falseMaterial;

    private Renderer renderer;
    private Material originalMaterial;
    private void Awake()
    {
        if (cable == null)
            Debug.LogError("cable is missing", this);
        
        if (trueMaterial == null)
            Debug.LogError("trueMaterial is missing", this);
        
        if (falseMaterial == null)
            Debug.LogError("falseMaterial is missing", this);
        
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    private void OnEnable()
    {
        cable.GetEnergyChangeEvent().AddListener(OnEnergyChange);
        OnEnergyChange();
    }

    private void OnDisable()
    {
        cable.GetEnergyChangeEvent().RemoveListener(OnEnergyChange);
        OnEnergyChange();
    }
    
    private void OnEnergyChange()
    {
        var energy = cable.GetEnergy();
        renderer.material = energy switch
        {
            EnergyType.True => trueMaterial,
            EnergyType.False => falseMaterial,
            _ => originalMaterial
        };
    }
}