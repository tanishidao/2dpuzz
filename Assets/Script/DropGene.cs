using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGene : MonoBehaviour
{

    public GameObject D, L;/// <summary>
    /// dはドロップを入れるLは知らん、後でかけ
    /// </summary>

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject l = Instantiate(L) ;
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
                GameObject.Find("D").GetComponent<GameDirector>().Obj[i, j] = d;
                GameObject.Find("D").GetComponent<GameDirector>().Field[i, j] = type;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
