using System;
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
        ShowText(currentGatter.GatterLogic.LabelText);
    }

    private void ShowText(string text)
    {
        gatterDisplay.text = text;
    }

    private void Awake()
    {
        OnGatterAddedToList();
        gatterList.AddedGatterToList.AddListener(OnGatterAddedToList);
    }

    private void Start()
    {
        UpdateLabel();
    }

    private void OnDestroy()
    {
        gatterList.AddedGatterToList.RemoveListener(OnGatterAddedToList);
    }

    private void UpdateLabel()
    {
        if (gatterListRefined.Count == 0)
        {
            ShowText("EMPTY");
        }
        else ShowGatterName(GetCurentGatter());
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

    public void OnGatterAddedToList()
    {
        gatterListRefined = gatterList.Gatters
            .Select(g => g.GetComponentInChildren<Gatter>())
            .Where(g => g != null)
            .ToList();
        Debug.Log($"BA22 should update label currently in our list:{gatterListRefined.Count}");
        UpdateLabel();
        
    }
}
