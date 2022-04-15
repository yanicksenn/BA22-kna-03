using UnityEngine;

public class Cable : MonoBehaviour, IConductor
{
    [SerializeField] 
    private CableInputConnector input;
    
    [SerializeField] 
    private CableOutputConnector output;

    [SerializeField] 
    private OVRGrabbableExtension handle;

    [SerializeField, Space] 
    private Transform connectionInput2Handle;

    [SerializeField] 
    private Transform connectionOutput2Handle;

    [SerializeField, Space] 
    private float pullThreshold;

    [SerializeField, Space] 
    private CableEvent onPull = new CableEvent();

    private Vector3 _initialScaleInput2Handle;
    private Vector3 _initialScaleOutput2Handle;

    public EnergyType GetEnergy()
    {
        return output.GetEnergy();
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
        if (IsEverythingUnmoved()) 
            return;
        
        if (!handle.isGrabbed)
            PlaceHandleBetweenInputAndOutput();

        UpdateConnections();
    }

    private void OnReleaseHandle()
    {
        // If the distance between the handle and the desired position is greater than the
        // the threshold, then invoke the pull event.
        var distance = Vector3.Distance(handle.transform.position, GetDesiredHandlePosition());
        if (distance >= pullThreshold)
            onPull.Invoke(this);
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
        var inputPosition = input.transform.position;
        var outputPosition = output.transform.position;
        var handlePosition = (inputPosition + outputPosition) / 2f;
        return handlePosition;
    }

    private bool IsEverythingUnmoved()
    {
        return !input.transform.hasChanged && !output.transform.hasChanged && !handle.transform.hasChanged;
    }

    private void UpdateConnections()
    {
        var inputPosition = input.transform.position;
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
}