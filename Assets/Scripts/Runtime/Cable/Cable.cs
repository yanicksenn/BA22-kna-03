using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class Cable : MonoBehaviour, IConductor
{
    [SerializeField] 
    private Gatter gatter;

    [SerializeField] 
    private EnergySource source;
    
    [SerializeField, Space] 
    private Transform input;
    
    [SerializeField] 
    private CableOutputConnector output;

    [SerializeField] 
    private Grabbable handle;

    [SerializeField, Space] 
    private Transform connectionInput2Handle;

    [SerializeField] 
    private Transform connectionOutput2Handle;

    [SerializeField, Space] 
    private float pullThreshold;

    private Vector3 _initialScaleInput2Handle;
    private Vector3 _initialScaleOutput2Handle;
    
    public IEnumerable<IDependable> GetDependencies()
    {
        if (gatter != null && source == null)
            return new List<IDependable> {gatter};

        if (source != null && gatter == null)
            return new List<IDependable> {source};

        Debug.LogWarning("cable needs either a gatter or energy source", this);
        
        return new List<IDependable>();
    }

    public EnergyType GetEnergy()
    {
        if (gatter == null && source == null)
            return EnergyType.Invalid;
        
        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;

        if (gatter != null)
            return gatter.GetEnergy();
        else
            return source.GetEnergy();
    }

    private void Awake()
    {
        _initialScaleInput2Handle = connectionInput2Handle.localScale;
        _initialScaleOutput2Handle = connectionOutput2Handle.localScale;
    }

    private void OnEnable()
    {
        handle.OnRelease.AddListener(OnReleaseHandle);
        UpdateConnections();
    }
    
    private void OnDisable()
    {
        handle.OnRelease.RemoveListener(OnReleaseHandle);
    }

    private void Update()
    {
        UpdateOutputPosition();
        UpdateConnections();
        UpdateGrababbles();
    }

    private void UpdateGrababbles()
    {
        if (output.IsSnapped)
        {
            output.enabled = false;
            handle.enabled = true;
        }
        else
        {
            output.enabled = true;
            handle.enabled = false;
        }
    }

    private void UpdateOutputPosition()
    {
        if (!output.IsGrabbed && !output.IsSnapped && !output.CouldBeSnapped)
            ResetPositionOfOutput();
    }

    private void OnReleaseHandle()
    {
        // If the distance between the handle and the desired position is greater than the
        // the threshold, then invoke the pull event.
        var distance = Vector3.Distance(handle.transform.position, GetDesiredHandlePosition());
        if (!(distance >= pullThreshold)) 
            return;
        
        output.SnapZone.Unsnap();
        ResetPositionOfOutput();
    }

    private void PlaceHandleBetweenInputAndOutput()
    {
        var handleTransform = handle.transform;
        var handlePosition = handleTransform.position;
        var desiredPosition = GetDesiredHandlePosition();

        if (handlePosition != desiredPosition)
            handleTransform.position = desiredPosition;
    }

    private Vector3 GetDesiredHandlePosition()
    {
        var inputPosition = input.position;
        var outputPosition = output.transform.position;
        var handlePosition = (inputPosition + outputPosition) / 2f;
        return handlePosition;
    }

    private void UpdateConnections()
    {
        var isEverythingUnmoved = !input.hasChanged && !output.transform.hasChanged && !handle.transform.hasChanged;
        if (isEverythingUnmoved) 
            return;
        
        if (!handle.isGrabbed)
            PlaceHandleBetweenInputAndOutput();
        
        var inputPosition = input.position;
        var outputPosition = output.transform.position;
        var handlePosition = handle.transform.position;

        var distanceInput2Handle = Vector3.Distance(inputPosition, handlePosition);
        var distanceOutput2Handle = Vector3.Distance(outputPosition, handlePosition);

        connectionInput2Handle.localScale =
            new Vector3(_initialScaleInput2Handle.x, distanceInput2Handle / 2f, _initialScaleInput2Handle.z);

        connectionOutput2Handle.localScale =
            new Vector3(_initialScaleOutput2Handle.x, distanceOutput2Handle / 2f, _initialScaleOutput2Handle.z);

        var middleInput2Handle = (inputPosition + handlePosition) / 2f;
        connectionInput2Handle.position = middleInput2Handle;

        var middleOutput2Handle = (outputPosition + handlePosition) / 2f;
        connectionOutput2Handle.position = middleOutput2Handle;

        var directionInput2Handle = handlePosition - inputPosition;
        connectionInput2Handle.up = directionInput2Handle;

        var directionOutput2Handle = handlePosition - outputPosition;
        connectionOutput2Handle.up = directionOutput2Handle;
    }

    private void ResetPositionOfOutput()
    {
        output.transform.position = input.position;
    }
}