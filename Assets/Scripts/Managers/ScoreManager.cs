using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    TextMeshProUGUI text;


    void Awake ()
    {
        text = GetComponent <TextMeshProUGUI> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
    }
}
