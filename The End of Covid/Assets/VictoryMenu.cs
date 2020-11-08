using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    public GUIStyle myStyle;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnGUI()
    {
        myStyle.normal.textColor = Color.white;
        myStyle.fontSize = 50;
        //GUI.Box(new Rect(10, 10, 100, 30), "Time: " + (int)Time.timeSinceLevelLoad, myStyle);
        GUI.Box(new Rect(500, 232, 100, 100), " " + Player.score, myStyle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
