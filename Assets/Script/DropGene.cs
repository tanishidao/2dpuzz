﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGene : MonoBehaviour
{

    public GameObject D, L;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject l = Instantiate(L) as GameObject;
            l.transform.SetParent(transform);
            l.transform.localScale = Vector3.one;
            for (int j = 0; j < 6; j++)
            {
                GameObject d = Instantiate(D) as GameObject;
                d.transform.SetParent(l.transform);
                int type = Random.Range(0, 6);
                d.GetComponent<DropCnt>().Set(type);
                d.GetComponent<DropCnt>().ID1 = i;
                d.GetComponent<DropCnt>().ID2 = j;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
