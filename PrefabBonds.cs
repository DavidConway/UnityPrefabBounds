using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBonds : MonoBehaviour
{
    static private Bounds result;

    static public Bounds redererBonds(GameObject i)
    {
        result = new Bounds(i.transform.position, new Vector3(0, 0,0));
        growRederBonds(i);
        return result;
    }

    static void growRederBonds(GameObject i)
    {
        List<GameObject> children = new List<GameObject>();

        if (i.GetComponent<Renderer>() != null)
        {
            result.Encapsulate(i.GetComponent<Renderer>().bounds);
        }

        foreach (Transform j in i.transform)
        {
            children.Add(j.gameObject);
        }

        foreach (GameObject k in children)
        {
            growRederBonds(k);
        }
    }
}
