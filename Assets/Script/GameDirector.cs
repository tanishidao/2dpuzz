using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    GameObject[,] o = new GameObject[5, 6];
    public GameObject[,] Obj
    {
        get { return o; }
        set { o = value; }
    }

    int[,] f = new int[5, 6];
    public int[,] Field
    {
        get { return f; }
        set { f = value; }
    }

    void Start()
    {

    }


    void Update()
    {

    }
    public bool CheckPos(Vector2 p1, Vector2 p2)
    {
        float x = p1.x - p2.x;
        float y = p1.y - p2.y;
        float r = Mathf.Sqrt(x * x + y * y);
        if (r < 93.75f)

        {
            return true;

        }
        return false;

    }

    public void ChangePos(GameObject obj1, GameObject obj2)
    {
        DropCnt d1 = obj1.GetComponent<DropCnt>();
        DropCnt d2 = obj2.GetComponent<DropCnt>();
        GameObject tempObj;//////ドロップ本体

        Vector2 tempPos;///盤面情報

        int temp;///

        tempObj = Obj[d1.ID1, d1.ID2];
        Obj[d1.ID1, d1.ID2] = Obj[d2.ID1, d2.ID2];
        Obj[d2.ID1, d2.ID2] = tempObj;

        temp = Field[d1.ID1, d1.ID2];
        Field[d1.ID1, d1.ID2] = Field[d2.ID1, d2.ID2];
        Field[d2.ID1, d2.ID2] = temp;

        tempPos = d1.P1;
        d1.P1 = d2.P1;
        d2.P1 = tempPos;

        tempPos = d1.P2;
        d1.P2 = d2.P2;
        d2.P2 = tempPos;

        temp = d1.ID1;
        d1.ID1 = d2.ID1;
        d2.ID1 = temp;

        temp = d1.ID2;
        d1.ID2 = d2.ID2;
        d2.ID2 = temp;

        Debug.Log("change発生");
    }

    public void DeleteDrop()
    {
        int c = 0, t = 0;
        int[,] temp = new int[5, 6];
        int[,] temp2 = new int[5, 6];

        for (int i = 0; i < 5; i++)///tempの処理
        {
            for (int j = 0; j < 6; j++)
            {

                if (j == 0)
                {
                    c = 1;
                    t = Field[i, j];
                    continue;
                }
                if (t == Field[i, j])
                {
                    c++;
                    if (c >= 3)
                    {
                        temp[i, j] = c;
                    }  
                }
                else
                {
                    c = 1;
                    t = Field[i, j];
                }
            }
        }
        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < 5; i++)///temp2の処理
            {

                if (i == 0)
                {
                    c = 1;
                    t = Field[i, j];
                    continue;
                }
                if (t == Field[i, j])
                {
                    c++;
                    if (c >= 3)
                    {
                        temp2[i, j] = c;
                    }
                   
                }
                else
                {
                    c = 1;
                    t = Field[i, j];
                }
            }
        }
        ///印があったら消すドロップに変更
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (temp[i, j] >= 3)

                {
                    for (int k = j; temp[i, j] > 0; k--, temp[i, j]--)
                    {
                        Field[i, k] = 6;
                        Obj[i, k].GetComponent<DropCnt>().Set(6);
                    }
                    
                }
                if (temp2[i, j] >= 3)///temp2
                {

                    for (int k = i; temp2[i, j] > 0; k--, temp2[i, j]--)
                    {
                        Field[k, j] = 6;
                        Obj[k, j].GetComponent<DropCnt>().Set(6);
                    }
                }
                Debug.Log("けすよ＝＝！");
            }
           
        }
    
    }
public void DowmDrop()
    {
        for(int j = 0; j < 6; j++)
        {
            for(int i = 1; i < 5; i++)
            {
                if(Field[i,j]==6)
                {
                    for(int k= i; k > 0; k--)
                    {
                        if (Field[k - 1,j] != 6)
                        {
                            ChangePos(Obj[k, j],Obj[k - 1, j]);
                        }
                    }

                }
            }
        }
    }
    public void ResetDrop()
    {
       for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                if(Field[i,j]==6)
                {
                    int type = Random.Range(0, 6);
                    Field[i, j] = type;
                    Obj[i, j].GetComponent<DropCnt>().Set(type);
                }
            }
        }
    }

}
