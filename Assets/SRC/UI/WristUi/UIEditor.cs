using UnityEngine;

public class UIEditor : MonoBehaviour
{
    [SerializeField] private GameObject gravitySidePanel;

    [SerializeField] private GameObject storeSidePanel;

    [SerializeField] private GameObject gravityContainer;

    [SerializeField] private GameObject velocityContainer;

    [SerializeField] private GameObject tracingContainer;

    [SerializeField] private GameObject storeContainer;

    [SerializeField] private GameObject wallContainer;

    [SerializeField] private GameObject items;

    [SerializeField] private GameObject buildings;

    public void deleteGameobjects()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("spawned"))
        {
            Destroy(obj);
        }
    }

    private int lastClickedUi = -1;

    public void resetTracing()
    {
        foreach (var pathVisualizer in FindObjectsOfType<PathVisualizer>())
        {
            pathVisualizer.ClearPoints();
        }
    }

    public void openGravitySideMenu()
    {
        items.SetActive(false);
        buildings.SetActive(false);
        storeSidePanel.SetActive(false);
        if (lastClickedUi == 0 && gravitySidePanel.activeSelf)
        {
            gravitySidePanel.SetActive(false);
        }
        else if (!gravitySidePanel.activeSelf)
        {
            gravitySidePanel.SetActive(true);
        }

        gravityContainer.SetActive(true);
        tracingContainer.SetActive(false);
        velocityContainer.SetActive(false);


        lastClickedUi = 0;
    }
    

    public void openVelocitySideMenu()
    {
        items.SetActive(false);
        buildings.SetActive(false);
        storeSidePanel.SetActive(false);
        if (lastClickedUi == 1 && gravitySidePanel.activeSelf)
        {
            gravitySidePanel.SetActive(false);
        }
        else if (!gravitySidePanel.activeSelf)
        {
            gravitySidePanel.SetActive(true);
        }

        gravityContainer.SetActive(false);
        tracingContainer.SetActive(false);
        velocityContainer.SetActive(true);
        lastClickedUi = 1;
    }

    public void openTracingSideMenu()
    {
        items.SetActive(false);
        buildings.SetActive(false);
        storeSidePanel.SetActive(false);
        if (lastClickedUi == 2 && gravitySidePanel.activeSelf)
        {
            gravitySidePanel.SetActive(false);
        }
        else if (!gravitySidePanel.activeSelf)
        {
            gravitySidePanel.SetActive(true);
        }

        gravityContainer.SetActive(false);
        velocityContainer.SetActive(false);
        tracingContainer.SetActive(true);
        lastClickedUi = 2;
    }

    public void openStoreSideMenu()
    {
        gravitySidePanel.SetActive(false);
        buildings.SetActive(false);
        items.SetActive(true);
        if (lastClickedUi == 3 && storeSidePanel.activeSelf)
        {
            items.SetActive(false);
            storeSidePanel.SetActive(false);
        }
        else if (!storeSidePanel.activeSelf)
        {
            storeSidePanel.SetActive(true);
        }

        storeContainer.SetActive(true);
        wallContainer.SetActive(false);
        lastClickedUi = 3;
    }

    public void openWallSideMenu()
    {
        gravitySidePanel.SetActive(false);
        buildings.SetActive(true);
        items.SetActive(false);
        if (lastClickedUi == 4 && storeSidePanel.activeSelf)
        {
            buildings.SetActive(false);
            storeSidePanel.SetActive(false);
        }
        else if (!storeSidePanel.activeSelf)
        {
            storeSidePanel.SetActive(true);
        }

        storeContainer.SetActive(false);
        wallContainer.SetActive(true);
        lastClickedUi = 4;
    }
}