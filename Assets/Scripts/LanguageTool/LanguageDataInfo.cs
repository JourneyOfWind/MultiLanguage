using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class LanguageDataInfo:ScriptableObject,IDataInfo
{
    public List<LanguageData> mLanguageDataList = new List<LanguageData>();

    private Dictionary<string, string> mLanguageDataDict = new Dictionary<string, string>();
    public void AddData(BaseData data) {
        mLanguageDataList.Add((LanguageData)data);
    }

    public void AddDataToDict() {
        foreach (LanguageData data in mLanguageDataList)
        {
            mLanguageDataDict.Add(data.LanguageKey,data.LanguageValue);
        }
    }

    public string GetStrByKey(string wordKey) {
        if (mLanguageDataDict == null)
        {
            Debug.LogError("多语言初始化失败");
            return wordKey;
        }

        if (mLanguageDataDict.ContainsKey(wordKey))
            return mLanguageDataDict[wordKey];

        Debug.LogWarning($"多语言Key{wordKey}不存在");
        return wordKey;
    }
}
[Serializable]
public class LanguageData:BaseData
{
    public string LanguageKey;
    public string LanguageValue;
}
