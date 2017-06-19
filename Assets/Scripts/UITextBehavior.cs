using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextBehavior : MonoBehaviour {

    public Text text;
    private int ROUND_REMEMBERED;
    private float timeLeft;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.material.mainTexture.filterMode = FilterMode.Point;
        ROUND_REMEMBERED = 0;
        timeLeft = 3;
    }

    public void UpdateUI()
    {
        
        if ((ROUND_REMEMBERED == 0) && (gameHolder.ROUND_NUMBER == 1)) { text.text = "FIRST SORTIE"; ROUND_REMEMBERED = 1; timeLeft = 3; }
        if ((ROUND_REMEMBERED == 1) && (gameHolder.ROUND_NUMBER == 2)) { text.text = "SECOND SORTIE"; ROUND_REMEMBERED = 2; timeLeft = 3; }
        if ((ROUND_REMEMBERED == 2) && (gameHolder.ROUND_NUMBER == 3)) { text.text = "THIRD SORTIE"; ROUND_REMEMBERED = 3; timeLeft = 3; }
        if ((ROUND_REMEMBERED == 3) && (gameHolder.ROUND_NUMBER == 4)) { text.text = "GAME OVER"; ROUND_REMEMBERED = 0; timeLeft = 3; }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        UpdateUI();
        if (timeLeft < 0)
        {
            text.text = "";
        }
    }
}
