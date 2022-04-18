using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelPathConst
{
    /// <summary>
    /// Excel�ļ���
    /// </summary>
    public static string ExcelDirectory = Application.dataPath + "/Excel";

    /// <summary>
    /// �����ļ������ļ���
    /// </summary>
    public static string ScriptableObjectDirectory = Application.dataPath + "/Resources/ScriptableObjs";

    /// <summary>
    /// Excel�ļ�����λ��
    /// </summary>
    public static string ExcelPos = Application.dataPath + "/Excel/AllPuzzle.xlsm";

    /// <summary>
    /// DataInfoģ������λ��
    /// </summary>
    public static string DataInfoTemplate = Application.dataPath + "/ThirdParty/ExcelToScriptable/Template/DataInfoTemplate.txt";

    /// <summary>
    /// Dataģ������λ��
    /// </summary>
    public static string DataTemplate = Application.dataPath + "/ThirdParty/ExcelToScriptable/Template/DataTemplate.txt";

    /// <summary>
    /// DataInfo��չģ������λ��
    /// </summary>
    public static string DataInfoExtensionTemplate = Application.dataPath + "/ThirdParty/ExcelToScriptable/Template/DataInfoExtensionTemplate.txt";

    /// <summary>
    /// �������ݴ�����ļ���
    /// </summary>
    public static string GenerateScripts = Application.dataPath + "/Scripts/GenerateCode/DataCode";

    /// <summary>
    /// ����������չ������ļ���
    /// </summary>
    public static string ExtentionCode = Application.dataPath + "/Scripts/GenerateCode/ExtensionCode";

    /// <summary>
    /// ���ɵ������ļ�����λ��
    /// </summary>
    public static string ScriptableObject = "Assets/Resources/ScriptableObjs";
}