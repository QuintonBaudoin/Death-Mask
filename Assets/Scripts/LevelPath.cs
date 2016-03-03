#define UnityEditor

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



#if UnityEditor
[ExecuteInEditMode]
#endif

public class LevelPath : MonoBehaviour
{
    static List<LevelNode> nodes = new List<LevelNode>();

    static public void SetNextNode(GameObject go)
    {
        if(!go.GetComponent<LevelNode>())
        go.AddComponent<LevelNode>();


        nodes.Add(go.GetComponent<LevelNode>());
    }
    static public void RemoveNode(GameObject go)
    {
        if(go.GetComponent<LevelNode>() && nodes.Contains(go.GetComponent<LevelNode>()))
        {
           LevelNode tmp = go.GetComponent<LevelNode>();

            nodes.Remove(tmp);

            DestroyImmediate(tmp);
        }
    }

    static public List<LevelNode> GetNodes()
    {
        return nodes;
    }


    void Update()
    {
        print(nodes.Count);
#if UnityEditor

        for(int i = 0; i < nodes.Count; i++)
        {
            if(i + 1 < nodes.Count)
            {
                Debug.DrawLine(nodes[i].gameObject.transform.position, nodes[i + 1].gameObject.transform.position,Color.green);

            }
        }
#endif
    }
}
