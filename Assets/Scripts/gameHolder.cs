﻿using UnityEngine;
using System.Collections;

public class gameHolder : MonoBehaviour {

    public static int SURV_SAVED;
    public static int SURV_DIED;
    public static int SURV_ONBOARD;

    public static void SurvOnBoard()
    {
        SURV_ONBOARD += 1;
    }

    public static void SurvDied()
    {
        SURV_DIED += 1;
    }

    public static void SurvSaved()
    {
        SURV_SAVED += 1;
    }

	// Use this for initialization
	public static void GameOver() {
        SURV_DIED = 0;
        SURV_SAVED = 0;
        SURV_ONBOARD = 0;


    }

    public static void HeliCrashed()
    {
        SURV_DIED += SURV_ONBOARD;
        SURV_ONBOARD = 0;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }




}
