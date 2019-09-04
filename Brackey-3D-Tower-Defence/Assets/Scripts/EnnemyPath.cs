using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPath : MonoBehaviour
{
    public static Transform[] points;

    //Get all childrens in an array
    void Awake()
    {
        points = new Transform[transform.childCount];
        for(int i = 0;i < points.Length; i++)
        {
            points[i] = transform.GetChild(0);
        }
    }
}
