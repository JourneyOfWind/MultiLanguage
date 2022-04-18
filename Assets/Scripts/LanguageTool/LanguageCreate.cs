#if UNITY_EDITOR
using Excel;
using System.Data;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class LanguageCreate
{
    public static  string ScriptableObjectPath = "Assets/Resources/ScriptableObjs";
    static         string LanguageExcelPos = Application.dataPath + "/Excel/Language.xlsm";
    private static string savePath         = ScriptableObjectPath + "/LanguageObjs/{0}.asset";
    private static string objSaveDirectory = "Assets/Resources/ScriptableObjs/LanguageObjs";
    private static string enumSaveDirectory = Application.dataPath + "/Scripts/GenerateCode/MultiLanguage";
    private static string enumCodeSavePath = Application.dataPath + "/Scripts/GenerateCode/MultiLanguage/WordKey.cs";
    [MenuItem("多语言/转换多语言文件")]
    public static void GenerateLanguageConfig()
    {
        FileStream stream = File.Open(LanguageExcelPos, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet dataSet = excelDataReader.AsDataSet();
        for (int i = 0; i < dataSet.Tables.Count; i++) {
            EditorUtility.DisplayProgressBar("配置文件生成中", dataSet.Tables[i].TableName, (float)i / dataSet.Tables.Count);
            if (dataSet.Tables[i].TableName == "Language") {
                GenerateOne(dataSet.Tables[i]);
            }
        }
        stream.Close();
        excelDataReader.Close();
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
        Debug.Log("多语言配置文件生成完毕");
    }

    private static void GenerateOne(DataTable dataTable)
    {
        DataRowCollection rowCollection = dataTable.Rows;
        if (!Directory.Exists(objSaveDirectory))
        {
            Directory.CreateDirectory(objSaveDirectory);
        }

        for (int i = 1; i < dataTable.Columns.Count; i++) {
            LanguageDataInfo singleLanguage = ScriptableObject.CreateInstance<LanguageDataInfo>();
            string path = string.Format(savePath, rowCollection[1][i]).ToString();
            FileTool.DeleteFile(path);

            AssetDatabase.CreateAsset(singleLanguage, path);

            for (int j = 2; j < dataTable.Rows.Count; j++) {
                LanguageData data = new LanguageData {
                    LanguageKey = rowCollection[j][0].ToString(),
                    LanguageValue = rowCollection[j][i].ToString()
                };
                singleLanguage.AddData(data);
            }
            EditorUtility.SetDirty(singleLanguage);
            AssetDatabase.SaveAssets();
        }
        //生成枚举

        StringBuilder sb = new StringBuilder();
        sb.Append("public enum WordKey\n");
        sb.Append("{\n");
        for (int i = 2; i < rowCollection.Count; i++) {
            sb.Append("    " + rowCollection[i][0] + ",\n");
        }
        sb.Append("}");

        if (!Directory.Exists(enumSaveDirectory))
        {
            Directory.CreateDirectory(enumSaveDirectory);
        }
        FileTool.DeleteFile(enumCodeSavePath);
        FileTool.WriteFile(enumCodeSavePath, sb.ToString());
    }
}
#endif

