using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_dialogue_trigger : MonoBehaviour
{
    private UI_healthbar UI_manager;
    public Dialogue dialogue;
    private bool triggered;
    private BoxCollider2D bc;
    public int required_CT;
    public bool is_deity;
    private GameObject ms;

    public void Start()
    {
        ms = GameObject.FindGameObjectWithTag("MasterScript");
        UI_manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UI_healthbar>();
        triggered = false;
        if(is_deity){
            if(required_CT == 0 && ms.GetComponent<master_script>().GetPortalStatus()[0] == 1){
                triggered = true;
            }
            else if(required_CT == 2 && ms.GetComponent<master_script>().GetPortalStatus()[1] == 1){
                triggered = true;
            }
            else if(required_CT == 8 && ms.GetComponent<master_script>().GetPortalStatus()[2] == 1){
                triggered = true;
            }
        }
        bc = GetComponent<BoxCollider2D>();
        if(dialogue.sentences.Length == 0){
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        if(!triggered && (ms.GetComponent<master_script>().getCT() >= required_CT)){
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
        //check if jelly is celebrating for CT too
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, gameObject);
    }
    public bool Get_triggered(){
        return triggered;
    }

}
