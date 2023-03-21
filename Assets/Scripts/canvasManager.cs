using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasManager : MonoBehaviour
{
    public List<Button> doorList = new List<Button>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button door in doorList) {
            door.onClick.AddListener(clicked);
        }
    }

    private void clicked() {
        Debug.Log("I was clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
