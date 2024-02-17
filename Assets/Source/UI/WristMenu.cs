using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Manipulation;
using UnityEngine;
using UnityEngine.UI;

public class WristMenu : MonoBehaviour
{
    [SerializeField] private GameObject itemContainer;
    private List<GameObject> props = new();

    [SerializeField] private GameObject canvas;
    private int currentSelectedProp;

    [SerializeField] private UxrAvatar avatar;
    private Canvas _canvas;

    [SerializeField] private Slider slider;

    [SerializeField] private GameObject itemPanel;


    void Start()
    {
        canvas.SetActive(false);
        foreach (Transform child in itemContainer.transform)
        {
            props.Add(child.gameObject);
        }

        props[currentSelectedProp].gameObject.SetActive(true);
    }

    private void Update()
    {
        var viewDirection = UxrAvatar.LocalAvatar.CameraForward;
        var toUITransform = (gameObject.transform.position - UxrAvatar.LocalAvatar.CameraPosition).normalized;

        var angle = Vector3.Angle(viewDirection, toUITransform);

        var hand = avatar.GetHand(UxrHandSide.Left);
        hand.GetPalmOutDirection(UxrHandSide.Left, out var palmOut);
        var isPointingUp = palmOut.y > 0.0f;
        canvas.SetActive(angle <= 30f && isPointingUp);
        if (itemPanel.activeSelf)
        {
            itemContainer.SetActive(angle <= 30f && isPointingUp);
        }
    }


    public void selectNextProp()
    {
        if (currentSelectedProp + 1 >= props.Count) return;
        props[currentSelectedProp].gameObject.SetActive(false);
        currentSelectedProp++;
        props[currentSelectedProp].gameObject.SetActive(true);
    }

    public void controlDrag()
    {
        props[currentSelectedProp].gameObject.GetComponent<Rigidbody>().drag = slider.value;
    }


    public void lastProp()
    {
        if (currentSelectedProp == 0) return;
        props[currentSelectedProp].gameObject.SetActive(false);
        currentSelectedProp--;
        props[currentSelectedProp].gameObject.SetActive(true);
    }
}