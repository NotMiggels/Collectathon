using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogue_box;
    public GameObject dialogue_indicator;
    public Text nameText;
    public Text dialogueText;
    private float delay;
    private Queue<string> sentences;
    private Queue<string> names;
    private GameObject npc;
    private GameObject player;
    private bool skippable;
    private GameObject[] UIElement;
   //public Animator animator;


	void Start () {
        sentences = new Queue<string>();
        names = new Queue<string>();
        player = GameObject.FindGameObjectWithTag("Player");
        UIElement = GameObject.FindGameObjectsWithTag("UI");
        delay = 0.03f;
	}

  void Update (){
    if (npc !=null) {
      if (npc.GetComponent<TalkToCharacter>().leftArea()) {
        EndDialogue();
      }
    }
  }

    public void StartDialogue(Dialogue dialogue, GameObject da_npc)
    {
        dialogue_indicator.SetActive(false);
        npc = da_npc;
        skippable = npc.GetComponent<DialogueTrigger>().talkedTo;
        //animator.SetBool("IsOpen", true);

        if (!skippable) {
          player.GetComponent<Scr_PlayerControl>().DiasbleControl();
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
        Debug.Log(UIElement.Length);
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
        StartCoroutine(TypeSentence(sentence, name));
    }

    IEnumerator TypeSentence (string sentence, string name)
    {
        dialogueText.text = "";
        nameText.text = name;
        foreach (char letter in sentence.ToCharArray())
        {
          Debug.Log(delay);
          dialogueText.text += letter;
          if (Input.GetKey(KeyCode.Space)) {
            continue;
          }
          else{
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
        npc.GetComponent<DialogueTrigger>().talkedTo = true;
        npc = null;
        //gameObject.SetActive(false);
        //animator.SetBool("IsOpen", false);
    }
}
