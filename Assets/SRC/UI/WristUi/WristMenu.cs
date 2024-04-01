using DialogueEditor;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WristMenu : MonoBehaviour
{
    [SerializeField] private GameObject itemContainer;

    [SerializeField] private GameObject canvas;

    [SerializeField] private UxrAvatar avatar;

    [SerializeField] private GameObject storePanel;

    [SerializeField] private GameObject manipulationPanel;

    [SerializeField] private GameObject wallContainer;

    [SerializeField] private NPCConversation _npcConversation;
    private bool isTutorial;
    private bool hasTutorialSkipped = false;

    private void Start()
    {
        isTutorial = SceneManager.GetActiveScene().name == "Tutorial";
    }

    private void Update()
    {
        var viewDirection = UxrAvatar.LocalAvatar.CameraForward;
        var toUITransform = (gameObject.transform.position - UxrAvatar.LocalAvatar.CameraPosition).normalized;

        var angle = Vector3.Angle(viewDirection, toUITransform);

        var hand = avatar.GetHand(UxrHandSide.Left);
        hand.GetPalmOutDirection(UxrHandSide.Left, out var palmOut);
        var isPointingUp = palmOut.y > 0.0f;

        var isActive = angle <= 30f && isPointingUp;
        canvas.SetActive(isActive);
        if (isTutorial && !hasTutorialSkipped && isActive)
        {
            hasTutorialSkipped = true;
            ConversationManager.Instance.StartConversation(_npcConversation);
        }

        if (isActive) return;
        storePanel.SetActive(false);
        wallContainer.SetActive(false);
        manipulationPanel.SetActive(false);
        itemContainer.SetActive(false);

        // if (itemPanel.activeSelf)
        // {
        //     itemContainer.SetActive(angle <= 30f && isPointingUp);
        // }
    }
}