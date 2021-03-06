using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCnt : MonoBehaviour
{
    [SerializeField] Sprite[] sp;
    /// <summary>
    /// dropIDの設定
    /// </summary>
    ///下は消すときに役立つらしい、要検証
    public int ID1
    {
        get;
        set;
    }
    public int ID2
    {
        get;
        set;
    }
    bool touchFlag;
    Vector2 m;
    RectTransform r,r2;

    void Start()
    {
        ///rにRectTransformを入れる
        r = GetComponent<RectTransform>();
        r2 = transform.parent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchFlag)
        { var pos = Vector2.zero;///zero desu yo
            m = Input.mousePosition;///mouseの位置取る
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (r2, m, Camera.main, out pos);///
            r.localPosition = pos;
        }
    }
    /// <summary>
    /// drop画像に変更
    /// </summary>
    /// <param name="n"></param>
    public void Set(int n)
    {
        GetComponent<SpriteRenderer>().sprite = sp[n];
    }
public void set(int n)///dropにさわってますぜ関数
    {
        GetComponent<SpriteRenderer>().sprite = sp[n];

    }
public void GetDrop()///drop浮いてる！
    {
        touchFlag = true;
    }public void SetDrop()///dropおいた！
    {
        touchFlag = false;
    }

}
