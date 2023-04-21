using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogue : MonoBehaviour
{
    public GameScene currentScene;
    public DialogueManager bottomBar;
    public Transition backgroundController;
    public SelectionScreen chooseController;

    private State state = State.IDLE;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }
    

    // Start is called before the first frame update
    void Start()
    {
        if (currentScene is Scenes)
        {
            Scenes storyScene = currentScene as Scenes;
            bottomBar.PlayScene(storyScene);
            backgroundController.SetImage(storyScene.background);
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.ChangeCat())
                {
                    backgroundController.NoCat();
                }
                if (state == State.IDLE && bottomBar.IsLastSentence())
                {
                    backgroundController.NoCat();
                    PlayScene((currentScene as Scenes).nextScene);
                    
                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
                
            } 
            else
            {
                DialogueManager.finished = true;
                bottomBar.FinishSentence();
                
            }
        }
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        if (scene is Scenes)
        {
            Scenes storyScene = scene as Scenes;
            if (backgroundController.CheckImage(storyScene.background))
            {
                backgroundController.SwitchImage(storyScene.background);
                yield return new WaitForSeconds(1f);
            }
            
            bottomBar.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }

}
