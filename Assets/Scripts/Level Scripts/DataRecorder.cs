﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;



/*
 * this Heatmap tool was originally developed by: Garen O'Donnell
 * Date Created: 04/10/2019
 * Modified by: Hadi Mehrpouya
 * Date last modified: 11/10/2019
 */
public static class DataRecorder {
    public static string m_path= "Assets/Resources/";
    /*
     * This function will open the file using the path variable
     * and then adds whatever the user is sending to the end of the file
     * If you don't specify a seperator for this function, it will automatically uses ;
     * if the user doesn'tspecity whether to add timestamp. by default this funciton will add it as the last column for each line or before the seperator.
     */
    public static bool recordDeathPosition3D(Vector3 _pos)
    {
        string filePath = m_path + SceneManager.GetActiveScene().name;
        bool result = false;
        string lineToAdd= _pos.x + "," + _pos.y + "," + _pos.z;
        using (StreamWriter sw = File.AppendText(filePath+".txt")) //This line will try to open the file and if it doesn't exist, if will make it!
        {
            //Write death position vector to our text file as a new line
            sw.WriteLine(lineToAdd);
            sw.Close();
        }
        ////Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(filePath);
        TextAsset asset = Resources.Load<TextAsset>(filePath + ".txt");
        ////Print the text from the file
        result = true;//If we get to this part of our code, this means things went ok, so we return true. 
        return result;
    }
    public static bool recordDeathPosition2D(Vector2 _pos)
    {
        string filePath = m_path + SceneManager.GetActiveScene().name + ".txt";
        bool result = false;
        string lineToAdd = _pos.x + "," + _pos.y;
        using (StreamWriter sw = File.AppendText(m_path + ".txt")) //This line will try to open the file and if it doesn't exist, if will make it!
        {
            //Write death position vector to our text file as a new line
            sw.WriteLine(lineToAdd);
            sw.Close();
        }
        ////Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(filePath);
        TextAsset asset = Resources.Load<TextAsset>(filePath + ".txt");
        ////Print the text from the file
        result = true;//If we get to this part of our code, this means things went ok, so we return true. 
        return result;
    }
}
