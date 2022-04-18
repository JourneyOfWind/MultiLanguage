using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileTool
{
    /// <summary>
    /// ��ȡ�ļ�����
    /// </summary>
    /// <param name="filePath">�ļ�����׺��ȫ·��</param>
    /// <returns></returns>
    public static string ReadFile(string filePath)
    {
        FileStream   fileStream = new FileStream(filePath, FileMode.Open);
        StreamReader sw         = new StreamReader(fileStream);
        string       readTxt    = sw.ReadToEnd();
        fileStream.Close();
        sw.Close();
        return readTxt;
    }
    /// <summary>
    /// д���ļ�
    /// </summary>
    /// <param name="filePath">�ļ�����׺��ȫ·��</param>
    /// <param name="fileContent">�ļ�����</param>
    public static void WriteFile(string filePath, string fileContent)
    {
        FileStream   fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        StreamWriter sw         = new StreamWriter(fileStream);
        sw.Write(fileContent);
        sw.Close();
        fileStream.Close();
    }

    /// <summary>
    /// ɾ���ļ�
    /// </summary>
    /// <param name="filePath">�ļ�����׺��ȫ·��</param>
    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath)) {
            File.Delete(filePath);
        }
        else {
            Debug.LogWarning($"λ��{filePath}���ļ�������");
        }
    }

    /// <summary>
    /// �Ƿ�����ļ�
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static bool FileExist(string filePath)
    {
        return File.Exists(filePath);
    }
}