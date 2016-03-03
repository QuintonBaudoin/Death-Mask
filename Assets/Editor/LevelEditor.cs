using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
//[CustomEditor(typeof(LevelPath))]
public class LevelEditor : MonoBehaviour
{
    [MenuItem("Level Tool/Add Path %#c")]
    static void AddLevelPath()
    {
        if(FindObjectOfType<LevelPath>())
        {
            MonoBehaviour.print("Path for this scene already exists.");
            return;
        }

        GameObject a = new GameObject();
        a.name = "Level Path";
        a.AddComponent<LevelPath>();

    }

    [MenuItem("Level Tool/Add Path Node %#z")]
    static void AddNode()
    {
        GameObject[] selection = Selection.gameObjects;
        foreach(GameObject go in selection)
        LevelPath.SetNextNode(go);
    }

   [MenuItem("Level Tool/Remove Path Node %#x")]
   static void RemoveNode()
    {
        GameObject[] selection = Selection.gameObjects;
        foreach (GameObject go in selection)
            LevelPath.RemoveNode(go);
    }
   

    void Update()
    {
        Debug.Log("hello");
        var list = LevelPath.GetNodes();


        for(int i = 0; i > list.Count-1; i++)
        {
            

            MonoBehaviour.print("TESTING");
           Debug.DrawLine(list[i].gameObject.transform.position, list[i++].gameObject.transform.position);
        }
    }

}
