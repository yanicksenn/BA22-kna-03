using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItems : OVRGrabbable
{
    [SerializeField] private Material isGrabbableMaterial;
    
    public Material IsGrabbableMaterial
    {
        get => isGrabbableMaterial;
        set => isGrabbableMaterial = value;
    }

    private Material originalMaterial;
    private Renderer renderer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    // Update is called once per frame
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        renderer.material = isGrabbableMaterial;
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        renderer.material = originalMaterial;
    }
}
