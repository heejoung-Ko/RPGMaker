using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour
{
    // private List<string[]> studentData = new List<string[]>();
    // 
    // void static WriteMap()
    // {
    //     string[] tempStudentData = new string[3];
    //     tempStudentData[0] = ��Name";
    //     tempStudentData[1] = ��Age";
    //     tempStudentData[2] = ��ID";
    //     studentData.Add(tempStudentData);
    //     for (int i = 0; i < 10; i++)
    //     {
    //         tempStudentData = new string[3];
    //         tempStudentData[0] = ��Micheal"+i; // Name
    //         tempStudentData[1] = (i + 20).ToString(); // Age
    //         tempStudentData[2] = i.ToString() // ID
    //         studentData.Add(tempStudentData);
    //     }
    // 
    //     string[][] output = new string[studentData.Count][];
    // 
    //     for (int i = 0; i < output.Length; i++)
    //     {
    //         output[i] = studentData[i];
    //     }
    // 
    //     int length = output.GetLength(0);
    //     string delimiter = ",";
    // 
    //     StringBuilder sb = new StringBuilder();
    // 
    //     for (int index = 0; index < length; index++)
    //     {
    //         sb.AppendLine(string.Join(delimiter, output[index]));
    //     }
    // 
    //     string filePath = getPath();
    // 
    //     StreamWriter outStream = System.IO.File.CreateText(filePath);
    //     outStream.WriteLine(sb);
    //     outStream.Close();
    // }
    // 
    // private string getPath()
    // {
    // #if UNITY_EDITOR
    //     return Application.dataPath + "/CSV/��+��/Student Data.csv";
    // #elif UNITY_ANDROID
    //     return Application.persistentDataPath+"Student Data.csv";
    // #elif UNITY_IPHONE
    //     return Application.persistentDataPath+"/"+"Student Data.csv";
    // #else
    //     return Application.dataPath +"/"+"Student Data.csv";
    // #endif
    // }
}