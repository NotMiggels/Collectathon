using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_StageLoad : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("scene");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(string SceneName)
    {
        Debug.Log(SceneName);
        SceneManager.LoadScene(SceneName);

    }
}