using System.Collections.Generic;
using System.Linq;
using Runtime.GatterDispenser;
using TMPro;
using UnityEngine;

public class GatterDispenser : MonoBehaviour
{
    [SerializeField] private TMP_Text gatterDisplay;
    public TMP_Text GatterDisplay => gatterDisplay;

    [SerializeField] private Transform refrencePoint;

    [SerializeField] private GatterList gatterList;

    private List<Gatter> gatterListRefined;

    private int currentIndex = 0;

    private void ShowGatterName(Gatter currentGatter)
    {
        gatterDisplay.text = currentGatter.GatterLogic.LabelText;
    }

    private void Awake()
    {
        gatterListRefined = gatterList.Gatters
            .Select(g => g.GetComponentInChildren<Gatter>())
            .Where(g => g != null)
            .ToList();
        
    }

    private void Start()
    {
        if (gatterListRefined.Count == 0)
            return;
        
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        ShowGatterName(GetCurentGatter());
    }

    private Gatter GetCurentGatter()
    {
        return gatterListRefined[currentIndex];
    }

    public void NextGatter()
    {
        if(gatterListRefined.Count is 0 or 1)
            return;

        currentIndex++;
        if (currentIndex > gatterListRefined.Count -1)
            currentIndex = 0;
        UpdateLabel();
    }

    public void PreviousGatter()
    {
        if(gatterListRefined.Count is 0 or 1)
            return;

        currentIndex--;
        if (currentIndex < 0)
            currentIndex = gatterListRefined.Count - 1;
        UpdateLabel();
    }

    public void DispenseGatter()
    {
        var currentGatter = gatterList.Gatters[currentIndex];
        Instantiate(currentGatter, refrencePoint.position, refrencePoint.rotation);
    }
}
