using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemTab : MonoBehaviour
{
    private int currentIndex = 0;


    [SerializeField] private GameObject itemContainer;

    private List<GameObject> items = new();

    [SerializeField]
    private TMP_Text _textMeshPro;

    private void Start()
    {
        foreach (Transform child in itemContainer.transform)
        {
            items.Add(child.gameObject);
        }

        updateText();
    }

    public void loadNextPage()
    {
        if (currentIndex >= items.Count - 1) return;
        items[currentIndex].SetActive(false);
        currentIndex++;
        items[currentIndex].SetActive(true);
        updateText();
    }

    private void updateText()
    {
        _textMeshPro.SetText((currentIndex + 1) + " / " + items.Count);
    }
    
    public void loadPreviousPage()
    {
        if (currentIndex <= 0) return;
        items[currentIndex].SetActive(false);
        currentIndex--;
        items[currentIndex].SetActive(true);
        updateText();
    }
}