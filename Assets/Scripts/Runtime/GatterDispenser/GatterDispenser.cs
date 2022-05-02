using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GatterDispenser : MonoBehaviour
{
    [SerializeField] private TMP_Text gatterDisplay;
    public TMP_Text GatterDisplay => gatterDisplay;

    [SerializeField] private List<GameObject> gatterList;

    private List<AbstractGatter> gatterListRefined;

    private void showGatterName(AbstractGatter currentGatter)
    {
        gatterDisplay.text = currentGatter.LabelText;
    }

    private void Awake()
    {
        gatterListRefined = gatterList
            .Select(g => g.GetComponentInChildren<AbstractGatter>())
            .Where(g => g != null)
            .ToList();
        
    }

    private void Start()
    {
        if (gatterListRefined.Count == 0)
            return;
        
        showGatterName(gatterListRefined.First());
    }
}
