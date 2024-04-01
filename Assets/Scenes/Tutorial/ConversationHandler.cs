using System;
using DialogueEditor;
using UnityEngine;

public class ConversationHandler : MonoBehaviour
{
    [SerializeField] private NPCConversation _npcConversation;

    [SerializeField] private GameObject _gameObject;

    

    public void StartConvo()
    {
        ConversationManager.Instance.StartConversation(_npcConversation);
    }

    public void enableUI()
    {
        _gameObject.GetComponent<WristMenu>().enabled = true;
    }
}