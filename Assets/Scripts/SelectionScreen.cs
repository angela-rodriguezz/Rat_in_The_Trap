using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectionScreen : MonoBehaviour
{

    public ChooseOptionController label;
    public PlayDialogue gameController;
    private RectTransform rectTransform;
    private Animator animator;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public TextMeshProUGUI buttonChoice1;
    public TextMeshProUGUI buttonChoice2;
    public TextMeshProUGUI buttonChoice3;
    private ChooseScene main;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ChooseScene scene)
    {
        
        animator.SetTrigger("Show");
        main = scene;

        
        buttonChoice1.text = scene.labels[0].text;
        buttonChoice2.text = scene.labels[1].text;
        buttonChoice3.text = scene.labels[2].text;

    }

    public void PerformChoice(int num)
    {
        
        gameController.PlayScene(main.labels[num].nextScene);
        animator.SetTrigger("Hide");
    }
    

    

   
}
