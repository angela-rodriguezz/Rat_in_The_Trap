using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public bool isSwitched = false;
    public bool catOut = false;
    public Sprite Cat;
    public Image background1;
    public Image background2;
    public Animator animator;
    public Animator animator2;

    public void NoCat()
    {
        if (!catOut)
        {
            animator2.SetTrigger("Leaving");
        }
        catOut = true;
    }

    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched && !(background1.sprite == (background2.sprite)))
        {
            background2.sprite = sprite;
            animator.SetTrigger("SwitchBG");
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background1.sprite = sprite;
        }
        else
        {
            background2.sprite = sprite;
        }
    }
}
