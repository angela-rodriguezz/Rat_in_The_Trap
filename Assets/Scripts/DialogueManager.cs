using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public Scenes currentScene;
    public static bool finished;
    private State state = State.COMPLETED;

    private IEnumerator lineAppear;

    private enum State
    {
        PLAYING, COMPLETED
    }
    
    public void PlayScene(Scenes scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public void FinishSentence()
    {
        barText.text = currentScene.sentences[sentenceIndex].text;
    }

    public void PlayNextSentence()
    {
        lineAppear = TypeText(currentScene.sentences[++sentenceIndex].text);
        StartCoroutine(lineAppear);
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED) 
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            StopCoroutine(lineAppear);
            state = State.COMPLETED;
            finished = false;
        }
    }
}
