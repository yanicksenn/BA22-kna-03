using TMPro;
using UnityEngine;

public class GatterLabel : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private TMP_Text label;
    public string GetLabel()
    {
        if (text != null && text.Length > 0)
            return text;

        var gatter =  GetComponentInChildren<Gatter>();
        if (gatter == null)
            return "";

        return gatter.GatterLogic.LabelText;
    }

    private void Awake()
    {
        if (label != null)
            label.text = GetLabel();
    }
}