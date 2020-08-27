using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialMonologue : MonoBehaviour
{
    public Text ParrotText;
    public RawImage ParrotLeft;
    public RawImage ParrotRight;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Change();
        }
    }

    void Change()
    {
        ParrotText.text = "Und das sind deine Gegner! Der obere ist schnell und hält wenig aus, der untere ist langsam, hält aber viel aus. Für jeden besiegten Gegner erhälst du Futter, um neue Tiere zu rufen. Dein Ziel ist es das Safarihaus zu beschützen und seine Leben dürfen nicht auf 0 fallen. Wenn du bereit bist, drücke Start!";
        ParrotLeft.gameObject.SetActive(false);
        ParrotRight.gameObject.SetActive(true);
    }
}
