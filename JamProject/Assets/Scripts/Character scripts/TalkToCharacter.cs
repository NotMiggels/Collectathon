using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToCharacter : MonoBehaviour
{
    private bool talking;
    private CircleCollider2D cc;
    private bool touching;
    private UI_healthbar UI_manager;
    public void Start()
    {
        talking = false;
        UI_manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UI_healthbar>();
        touching = false;
        cc = GetComponent<CircleCollider2D>();
    }
    public void Update()
    {

        if (cc.IsTouchingLayers(LayerMask.GetMask("Player")) && !touching)
        {
            touching = true;
            UI_manager.ShowConvIndicator();
        }
        else if (!(cc.IsTouchingLayers(LayerMask.GetMask("Player"))) && touching)
        {
            touching = false;
            UI_manager.HideConvIndicator();
        }
        if (touching && !talking)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("space received");
                talking = true;
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }

        // if Jelly is in the circle collider trigger of an NPC, the player should be able to talk to them by pressing a key
        // when those two conditions are met, it should trigger a function on the DialogueTrigger script called TriggerDialogue, which stores the character's dialogue
        // the trigger dialogue script will then trigger a function on DialogueManager to actually start the dialogue

    }
    public void DoneTalking()
    {
        talking = false;
    }
}
