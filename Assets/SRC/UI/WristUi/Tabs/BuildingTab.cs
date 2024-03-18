using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BuildingTab : MonoBehaviour
{
    private int minPage = 0;
    private int currentPage = 0;
    private int maxPage;


    [SerializeField] private GameObject buildingContainer;

    private List<GameObject> buildings = new();

    [SerializeField] private TMP_Text _textMeshPro;

    private void Start()
    {
        Debug.Log("YEAHHH");
        foreach (Transform child in buildingContainer.transform)
        {
            buildings.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        buildings[0].SetActive(true);
        buildings[1].SetActive(true);
        buildings[2].SetActive(true);
        // buildings[3].SetActive(true);
        // buildings[4].SetActive(true);
        // buildings[5].SetActive(true);
        maxPage = (int)Math.Ceiling((double)buildings.Count / 6) - 1;

        updateText();
    }

    private void reload()
    {
        buildings.Clear();

        var sortedChildren = buildingContainer.transform.Cast<Transform>()
            .OrderBy(t => t.name)
            .Select(t => t.gameObject)
            .ToList();


        foreach (var child in sortedChildren)
        {
            buildings.Add(child);
            child.SetActive(false);
        }
    }


    public void loadNextPage()
    {
        if (currentPage == maxPage)
        {
            return;
        }
        reload();

        for (var i = currentPage; i < currentPage + 6; i++)
        {
            buildings[i].SetActive(false);
        }

        currentPage++;
        for (var i = currentPage * 6; i < currentPage * 6 + 6; i++)
        {
            buildings[i].SetActive(true);
        }

        updateText();
    }

    private void updateText()
    {
        Debug.Log("UPDATE TEXT" + maxPage);
        _textMeshPro.SetText("Seite " + (currentPage + 1) + " / " + (int)Math.Ceiling((double)buildings.Count / 6));
    }

    public void loadPreviousPage()
    {
        if (currentPage == minPage) return;
        
        reload();

        for (var i = currentPage * 6; i < currentPage * 6 + 6; i++)
        {
            buildings[i].SetActive(false);
        }

        currentPage--;

        for (var i = currentPage * 6; i < currentPage * 6 + 6; i++)
        {
            buildings[i].SetActive(true);
        }

        updateText();
    }
}