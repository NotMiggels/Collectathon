using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogue_box;
    public GameObject dialogue_indicator;
    public Text nameText;
    public Text dialogueText;
    public GameObject talking;
    private float delay;
    private Queue<string> sentences;
    private Queue<string> names;
    private GameObject npc;
    private GameObject player;
    private bool skippable;
    private GameObject[] UIElement;

    private bool skippy;
    private float time1;
    private float time2;
    private bool doubletap = false;
   //public Animator animator;


	void Start () {
        skippy = false;
        sentences = new Queue<string>();
        names = new Queue<string>();
        player = GameObject.FindGameObjectWithTag("Player");
        UIElement = GameObject.FindGameObjectsWithTag("UI");
        delay = 0.03f;
	}

  void Update (){
        if (npc != null)
        {
            if (npc.GetComponent<TalkToCharacter>() != null)
            {
                if (npc.GetComponent<TalkToCharacter>().leftArea())
                {
                    EndDialogue();
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            if(skippy == true)
            {
                time1 = Time.time;
                skippy = false;

                if(time1 - time2 < 0.4f)
                {
                    doubletap = true;
                    Debug.Log("double TAP");
                    time1 = 0;
                    time2 = 1;
                }
                else
                {
                    doubletap = false;
                }
            }
        }
        else{
            if(skippy == false)
            {
                time2 = Time.time;
                skippy = true;
            }
        }
    }


    public void StartDialogue(Dialogue dialogue, GameObject da_npc)
    {
        player.SendMessage("InDialogue");
        dialogue_indicator.SetActive(false);
        npc = da_npc;
        talking.GetComponent<changeIcon>().changeBackground();
        if(npc.GetComponent<DialogueTrigger>() != null){
            skippable = npc.GetComponent<DialogueTrigger>().talkedTo;
        }
        //animator.SetBool("IsOpen", true);

        if (!skippable) {
          player.GetComponent<Scr_PlayerControl>().DisableControl();
        }

        names.Clear();
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        DisplayNextSentence();
        foreach(GameObject UI in UIElement) {
          UI.SetActive(false);
        }
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(names.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        StopAllCoroutines();
        doubletap = false;
        StartCoroutine(TypeSentence(sentence, name));
    }

    IEnumerator TypeSentence (string sentence, string name)
    {
        dialogueText.text = "";
        nameText.text = name;
        talking.GetComponent<changeIcon>().changeTalking(name);
        foreach (char letter in sentence.ToCharArray())
        {
          //Debug.Log(delay);
          dialogueText.text += letter;
          if (doubletap) {
            continue;
          }
          else{
            if(doubletap == true)
            {
                continue;
            }
            yield return new WaitForSeconds(delay);
          }
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.S));
        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        player.GetComponent<Scr_PlayerControl>().EnableControl();
        dialogue_box.SetActive(false);
        if(npc.GetComponent<TalkToCharacter>() != null){
            npc.GetComponent<TalkToCharacter>().DoneTalking();
        }
        foreach(GameObject UI in UIElement) {
          UI.SetActive(true);
        }
        if(npc.GetComponent<DialogueTrigger>() != null){
            npc.GetComponent<DialogueTrigger>().talkedTo = true;
        }
        if(npc.GetComponent<auto_dialogue_trigger>() != null){
            if(npc.GetComponent<auto_dialogue_trigger>().is_deity){
                int CT_req = npc.GetComponent<auto_dialogue_trigger>().required_CT;
                if(CT_req == 0){
                    GameObject.FindGameObjectWithTag("Portal Controls").GetComponent<triggereventlist>().Unlockjungle();
                }
                else if(CT_req == 2){
                    GameObject.FindGameObjectWithTag("Portal Controls").GetComponent<triggereventlist>().Unlockspicyvolcano();

                }
                else if(CT_req == 8){
                    GameObject.FindGameObjectWithTag("Portal Controls").GetComponent<triggereventlist>().Unlockcheesemoon();
                }
            }
        }
        npc = null;
        if(GameObject.FindGameObjectWithTag("Boss") != null){
            GameObject.FindGameObjectWithTag("Boss").GetComponent<boss_script>().DoneTalking();
        }
        player.SendMessage("ExitDialogue");
        //gameObject.SetActive(false);
        //animator.SetBool("IsOpen", false);
    }
}
