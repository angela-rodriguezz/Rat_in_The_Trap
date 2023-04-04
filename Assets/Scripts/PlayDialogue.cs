using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogue : MonoBehaviour
{
    public Scenes currentScene;
    public DialogueManager bottomBar;
    // Start is called before the first frame update
    void Start()
    {
        bottomBar.PlayScene(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                bottomBar.PlayNextSentence();
            } 
            else
            {
                DialogueManager.finished = true;
                bottomBar.FinishSentence();
                
            }
        }
    }
}
