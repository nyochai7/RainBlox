using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BloxManager))]
public class BoxManagerEditor : Editor
{
    string size="1";
    string lives = "9";
    public override void OnInspectorGUI()
    {
        GUILayout.Label("blox editor");
        DrawDefaultInspector();

        BloxManager blox = (BloxManager)target;
        
        GUILayout.Space(10);

        GUILayout.Label("Use in play mode");
        GUILayout.Label("blox size");
        size = GUILayout.TextArea(size);
        GUILayout.Label("blox lives");
        lives = GUILayout.TextArea(lives);
       
        if (GUILayout.Button("Update Size"))
        {
            int sizeNum =0 ;
               if(int.TryParse(size,out sizeNum)){
                blox.BloxSize = sizeNum;
               }
        }

         if (GUILayout.Button("Update Lives"))
        {
             int livesNum =0 ;
               if(int.TryParse(lives,out livesNum)){
                blox.BloxLives = livesNum;
               }
            
        }
    }
}
