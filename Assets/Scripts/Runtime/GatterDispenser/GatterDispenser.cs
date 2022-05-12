using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.GatterDispenser;
using TMPro;
using UnityEngine;

public class GatterDispenser : MonoBehaviour
{
    [SerializeField] private TMP_Text gatterDisplay;

    [SerializeField] private Transform refrencePoint;

    [SerializeField] private GatterList gatterList;
    

    private int currentIndex = 0;

    private void ShowGatterName(GatterLabel currentGatter)
    {
        ShowText(currentGatter.GetLabel());
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
        if (gatterList.Gatters.Count== 0)
        {
            ShowText("EMPTY");
        }
        else ShowGatterName(GetCurentGatterLabel());
    }

    private GatterLabel GetCurentGatterLabel()
    {
        return gatterList.Gatters[currentIndex];
    }

    public void NextGatter()
    {
        if(gatterList.Gatters.Count is 0 or 1)
            return;

        currentIndex++;
        if (currentIndex > gatterList.Gatters.Count -1)
            currentIndex = 0;
        UpdateLabel();
    }

    public void PreviousGatter()
    {
        if(gatterList.Gatters.Count is 0 or 1)
            return;

        currentIndex--;
        if (currentIndex < 0)
            currentIndex = gatterList.Gatters.Count - 1;
        UpdateLabel();
    }

    public void DispenseGatter()
    {
        if (gatterList.Gatters.Count != 0)
        {
            var currentGatterLabel = gatterList.Gatters[currentIndex];
            Instantiate(currentGatterLabel, refrencePoint.position, refrencePoint.rotation);
        }
    }
        

    public void OnGatterAddedToList()
    {
        UpdateLabel();
        
    }
}
