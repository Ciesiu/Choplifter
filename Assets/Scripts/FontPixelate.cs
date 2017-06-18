using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FontPixelate : MonoBehaviour {

    public Text text;
    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
        text.material.mainTexture.filterMode = FilterMode.Point;
    }
	
	// Update is called once per frame
	void Update () {

        if(text.name == "textSaved") text.text = (gameHolder.SURV_SAVED < 10)? "0"+ gameHolder.SURV_SAVED : gameHolder.SURV_SAVED+"";
        if (text.name == "textDead") text.text = (gameHolder.SURV_DIED < 10) ? "0" + gameHolder.SURV_DIED : gameHolder.SURV_DIED + "";
        if (text.name == "textOnBoard") text.text = (gameHolder.SURV_ONBOARD < 10) ? "0" + gameHolder.SURV_ONBOARD : gameHolder.SURV_ONBOARD + "";

    }
}
