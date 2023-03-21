using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public DialogueBarController dialogueBar;
    //public BackgroundController backgroundController;

    void Start()
    {
        dialogueBar.PlayScene(currentScene);
        //backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (dialogueBar.IsCompleted())
            {
                if (dialogueBar.IsLastSentence())
                {
                    currentScene = currentScene.nextScene;
                    dialogueBar.PlayScene(currentScene);
                    //backgroundController.SwitchImage(currentScene.background);
                }
                else
                {
                    dialogueBar.PlayNextSentence();
                }
            }
        }
    }
}
