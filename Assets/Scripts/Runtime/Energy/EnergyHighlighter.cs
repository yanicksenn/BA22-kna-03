using System;
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
        originalMaterial = renderer.material;
    }


    private void EnergyUpdate()
    {
        if (conductor == null)
            return;
        
        var energy = conductor.GetEnergy();

        renderer.material = energy switch
        {
            EnergyType.True => trueMaterial,
            EnergyType.False => falseMaterial,
            _ => originalMaterial
        };
    }

    private void OnEnable()
    {
        conductor.GetEnergyChangeEvent().AddListener(EnergyUpdate);
        EnergyUpdate();
    }

    private void OnDisable()
    {
        conductor.GetEnergyChangeEvent().RemoveListener(EnergyUpdate);
        EnergyUpdate();
    }
}