using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguageMgr
{
    private LanguageDataInfo multiLanguageData;
    private static MultiLanguageMgr mInstance;
    private SystemLanguage   mCurrLanguage;

    public MultiLanguageMgr()
    {
        mInstance = this;
    }
    public void Init()
    {
        mCurrLanguage     = GetCurrLanguage();
        multiLanguageData = Resources.Load<LanguageDataInfo>("ScriptableObjs/LanguageObjs/" + mCurrLanguage.ToString());
        multiLanguageData.AddDataToDict();
        Debug.Log("多语言初始化完成");
    }

    public void OnDestroy()
    {
        multiLanguageData = null;
        mInstance         = null;
    }

    private string GetValueByStringKey(string wordKey)
    {
        return multiLanguageData.GetStrByKey(wordKey);
    }

    private string GetValueByEnumKey(WordKey wordKey)
    {
        return GetValueByStringKey(wordKey.ToString());
    }

    private SystemLanguage GetCurrLanguage()
    {
        return mCurrLanguage = SystemLanguage.English;
    }

    public static string GetValue(string wordKey)
    {
        return mInstance.GetValueByStringKey(wordKey);
    }

    public static string GetValue(WordKey wordKey)
    {
        return mInstance.GetValueByEnumKey(wordKey);
    }


}