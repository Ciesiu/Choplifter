using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextBehavior : MonoBehaviour {

    public Text text;
    private static float timeLeft;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.material.mainTexture.filterMode = FilterMode.Point;
        timeLeft = 3;
    }

    public static void ResetTime()
    {
        timeLeft = 3F;
    }
    public void UpdateUI()
    {
        
        if (gameHolder.ROUND_NUMBER == 1) { text.text = "FIRST SORTIE"; }
        if (gameHolder.ROUND_NUMBER == 2) { text.text = "SECOND SORTIE"; }
        if (gameHolder.ROUND_NUMBER == 3) { text.text = "THIRD SORTIE"; }
        if (gameHolder.ROUND_NUMBER == 4) { text.text = "THE END"; }
        if (gameHolder.ROUND_NUMBER == 5) { text.text = "MAGNIFICIENT"; }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft>0)
        {
            UpdateUI();
        }
        else if (timeLeft <= 0)
        {
            text.text = "";
        }
    }
}
