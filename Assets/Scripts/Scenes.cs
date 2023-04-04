using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]

public class Scenes : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public Scenes nextScene;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speakers speaker;
    }
}
