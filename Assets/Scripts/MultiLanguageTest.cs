using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguageTest:MonoBehaviour
{
    MultiLanguageMgr languageMgr;
    private void Start() {
        languageMgr = new MultiLanguageMgr();
        languageMgr.Init();
        MultiLanguageMgr.GetValue(WordKey.Login_Follow_Gift);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(MultiLanguageMgr.GetValue(WordKey.Login_Follow_Gift));
        }
    }
}
