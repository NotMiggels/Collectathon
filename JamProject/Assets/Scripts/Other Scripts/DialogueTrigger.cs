using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    private UI_healthbar UI_manager;
    public Dialogue dialogue;

    public void Start()
    {
        UI_manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UI_healthbar>();
    }
    public void TriggerDialogue()
    {
        Debug.Log("here we are");
        UI_manager.ShowDialogueBox();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, gameObject);
    }

}
