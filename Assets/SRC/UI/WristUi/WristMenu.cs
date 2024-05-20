using UltimateXR.Avatar;
using UltimateXR.Core;
using UnityEngine;

public class WristMenu : MonoBehaviour
{
    [SerializeField] private GameObject itemContainer;

    [SerializeField] private GameObject canvas;

    [SerializeField] private UxrAvatar avatar;

    [SerializeField] private GameObject storePanel;

    [SerializeField] private GameObject manipulationPanel;

    [SerializeField] private GameObject wallContainer;
    
    private bool hasTutorialSkipped = false;
    

    private void Update()
    {
        var viewDirection = UxrAvatar.LocalAvatar.CameraForward;
        var toUITransform = (gameObject.transform.position - UxrAvatar.LocalAvatar.CameraPosition).normalized;

        var angle = Vector3.Angle(viewDirection, toUITransform);

        var hand = avatar.GetHand(UxrHandSide.Left);
        hand.GetPalmOutDirection(UxrHandSide.Left, out var palmOut);
        var isPointingUp = palmOut.y > 0.0f;
        
        canvas.SetActive(isPointingUp);

        if (isPointingUp) return;
        storePanel.SetActive(false);
        wallContainer.SetActive(false);
        manipulationPanel.SetActive(false);
        itemContainer.SetActive(false);
    }
}