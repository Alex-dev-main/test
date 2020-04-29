using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactable
{
    public string[] dialogue;
    public string name;

    public GameObject engagePanel;
    Text engageText;

    public void Awake()
    {
        engageText = engagePanel.transform.Find("Text").GetComponent<Text>();
        engagePanel.SetActive(false);
    }

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
        Debug.Log("Interacting with NPC.");
    }

    public override void DisplayEngage(bool displayEngage)
    {
        engagePanel.SetActive(displayEngage);
    }
}
