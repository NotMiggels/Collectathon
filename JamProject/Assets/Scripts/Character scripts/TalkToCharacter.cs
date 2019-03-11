using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToCharacter : MonoBehaviour {

	// if Jelly is in the circle collider trigger of an NPC, the player should be able to talk to them by pressing a key
    // when those two conditions are met, it should trigger a function on the DialogueTrigger script called TriggerDialogue, which stores the character's dialogue
    // the trigger dialogue script will then trigger a function on DialogueManager to actually start the dialogue
}
