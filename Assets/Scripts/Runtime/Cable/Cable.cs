using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteAlways]
public class Cable : MonoBehaviour, IConductor
{
    [SerializeField] 
    private Gatter gatter;
    public Gatter Gatter
    {
        get => gatter;
        set => gatter = value;
    }

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

    [SerializeField] private float distanceThreshold;

    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();
    public UnityEvent OnEnergyChangeEvent => onEnergyChangeEvent;

    [SerializeField, Space] 
    private UnityEvent onCablePulled = new UnityEvent();
    public UnityEvent OnCablePulled => onCablePulled;

    public bool IsConnected => output.IsSnapped;

    private EnergyType energyType;

    private Vector3 _initialScaleInput2Handle;
    private Vector3 _initialScaleOutput2Handle;

    private void Awake()
    {
        _initialScaleInput2Handle = connectionInput2Handle.localScale;
        _initialScaleOutput2Handle = connectionOutput2Handle.localScale;
        
        SetToOutputMode();
    }

    private void OnEnable()
    {
        AddListeners();
        OnEnergyChange();
        UpdateConnections();
    }
    
    private void OnDisable()
    {
        RemoveListeners();   
        OnEnergyChange();
    }

    private void LateUpdate()
    {
        UpdateOutputPosition();
        UpdateConnections();
        UnsnapIfCableTooLong();
    }

    private void AddListeners()
    {
        handle.OnRelease.AddListener(OnReleaseHandle);
        output.OnConnect.AddListener(OnCableConnect);
        output.OnDisconnect.AddListener(OnCableDisconnect);
        
        if (gatter != null)
            gatter.OnEnergyChangeEvent.AddListener(OnEnergyChange);
        
        if (source != null)
            source.OnEnergyChangeEvent.AddListener(OnEnergyChange);
    }

    private void RemoveListeners()
    {
        handle.OnRelease.RemoveListener(OnReleaseHandle);
        output.OnConnect.RemoveListener(OnCableConnect);
        output.OnDisconnect.RemoveListener(OnCableDisconnect);
        
        if (gatter != null)
            gatter.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
        
        if (source != null)
            source.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
    }

    private void OnCableConnect(CableOutputSnapZone snapZone)
    {
        SetToHandleMode();
    }

    private void OnCableDisconnect(CableOutputSnapZone snapZone)
    {
        SetToOutputMode();
    }

    private void SetToOutputMode()
    {
        output.IsActive = true;
        handle.IsActive = false;
    }

    private void SetToHandleMode()
    {
        output.IsActive = false;
        handle.IsActive = true;
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
        var notExceedingThreshold = !(distance >= pullThreshold);
        if (notExceedingThreshold) 
            return;
        
        output.SnapZone.Unsnap();
        ResetPositionOfOutput();
        OnCablePulled.Invoke();
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
    public IEnumerable<IDependable> GetDependencies()
    {
        if (gatter != null && source == null)
            return new List<IDependable> {gatter};

        if (source != null && gatter == null)
            return new List<IDependable> {source};

        Debug.LogWarning("cable needs either a gatter or energy source", this);
        
        return new List<IDependable>();
    }

    private void OnEnergyChange()
    {
        var newEnergyType = RecalcEnergy();
        if (newEnergyType == energyType) 
            return;
        
        energyType = newEnergyType;
        GetEnergyChangeEvent().Invoke();
    }

    private EnergyType RecalcEnergy()
    {
        if (gatter == null && source == null)
            return EnergyType.Invalid;
        
        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;

        if (gatter != null)
            return gatter.GetEnergy();
        
        return source.GetEnergy();
    }
    
    public EnergyType GetEnergy()
    {
        return energyType;
    }

    public UnityEvent GetEnergyChangeEvent()
    {
        return onEnergyChangeEvent;
    }

    private void UnsnapIfCableTooLong()
    {
        if (!output.IsSnapped)
            return;
        
        var inputPosition = input.position;
        var outputPosition = output.transform.position;

        var distance = Vector3.Distance(outputPosition , inputPosition);
        Debug.Log($"BA22 Distance of cable: {distance} with a threshehold of {distanceThreshold}");
        if (distance < distanceThreshold)
            return;
        
        output.Unsnap();
        ResetPositionOfOutput();
    }
}