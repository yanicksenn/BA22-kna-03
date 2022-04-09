using UnityEngine;

public class Socket : MonoBehaviour
{
    [SerializeField] 
    private SnapZone snapZone;
    public SnapZone SnapZone
    {
        get => snapZone;
        set => snapZone = value;
    }

    public bool HasGatter()
    {
        if (SnapZone == null)
            return false;
                
        return SnapZone.SnappedObject != null;
    }
}