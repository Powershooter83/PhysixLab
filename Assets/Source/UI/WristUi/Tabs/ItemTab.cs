using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemTab : MonoBehaviour
{
    private int currentIndex = 0;


    [SerializeField] private GameObject itemContainer;

    private List<GameObject> items = new();

    [SerializeField] private TMP_Text _textMeshPro;

    private void Start()
    {
        foreach (Transform child in itemContainer.transform)
        {
            items.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        items[0].SetActive(true);
        items[1].SetActive(true);
        items[2].SetActive(true);
        items[3].SetActive(true);
        items[4].SetActive(true);
        items[5].SetActive(true);


        updateText();
    }

    private void reload()
    {
        
        items.Clear();
        
        var sortedChildren = itemContainer.transform.Cast<Transform>()
            .OrderBy(t => t.name)
            .Select(t => t.gameObject)
            .ToList();


        foreach (var child in sortedChildren)
        {
            items.Add(child);
            child.SetActive(false);
        }
        
        
    }
    
    

    public void loadNextPage()
    {
        reload();
        if (currentIndex >= (int)Math.Ceiling((double)items.Count / 6) - 1) return;

        for (var i = currentIndex; i < currentIndex + 6; i++)
        {
            items[i].SetActive(false);
        }

        currentIndex++;
        for (var i = currentIndex * 6; i < currentIndex * 6 + 6; i++)
        {
            items[i].SetActive(true);
        }

        updateText();
    }

    private void updateText()
    {
        _textMeshPro.SetText("Seite " + (currentIndex + 1) + " / " + (int)Math.Ceiling((double)items.Count / 6));
    }

    public void loadPreviousPage()
    {
        reload();
        if (currentIndex <= 0) return;

        for (var i = currentIndex * 6; i < currentIndex * 6 + 6; i++)
        {
            items[i].SetActive(false);
        }

        currentIndex--;

        for (var i = currentIndex * 6; i < currentIndex * 6 + 6; i++)
        {
            items[i].SetActive(true);
        }

        updateText();
    }
}