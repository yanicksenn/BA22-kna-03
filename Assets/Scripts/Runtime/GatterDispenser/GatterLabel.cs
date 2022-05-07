using TMPro;
using UnityEngine;

public class GatterLabel : MonoBehaviour
{
    [SerializeField] private string gatterLabel;
    
    public string GetLabel()
    {
        if (gatterLabel != null && gatterLabel.Length > 0)
        {
            return gatterLabel;
        }

        var gatter =  GetComponentInChildren<Gatter>();

        if (gatter == null)
        {
            return "";
        }

        return gatter.GatterLogic.LabelText;
    }
}