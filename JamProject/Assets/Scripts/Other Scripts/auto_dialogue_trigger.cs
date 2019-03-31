using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_dialogue_trigger : MonoBehaviour
{
    private UI_healthbar UI_manager;
    public Dialogue dialogue;
    private bool triggered;
    private BoxCollider2D bc;
    public void Start()
    {
        UI_manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UI_healthbar>();
        triggered = false;
        bc = GetComponent<BoxCollider2D>();
    }
    public void Update()
    {
        if(!triggered){
            if(bc.IsTouchingLayers(LayerMask.GetMask("Player"))){
                triggered = true;
                TriggerDialogue();
            }
        }
    }
    public void TriggerDialogue()
    {
        Debug.Log("here we are");
        UI_manager.ShowDialogueBox();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, gameObject);
    }

}
