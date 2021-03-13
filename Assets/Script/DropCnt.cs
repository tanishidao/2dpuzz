using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

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
    RectTransform r, r2;

   /// <summary>
   /// 位置移動防止用の座標ハコ2つ
   /// </summary>
    public Vector2 P1
    {
    get;
        set;
    }public Vector2 P2
    {
    get;
        set;
    }

    GameDirector d;
    void Start()
    {
        ///rにRectTransformを入れる
        r = GetComponent<RectTransform>();
        r2 = transform.parent.GetComponent<RectTransform>();
        d = GameObject.Find("D").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchFlag)
        { var pos = Vector2.zero;///zero desu yo
            m = Input.mousePosition;///mouseの位置取る
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (r2, m, Camera.main, out pos);///わからん
            r.localPosition = pos;
        }
        if (P1.x == 0)
        {
            P1 = GetComponent<RectTransform>().position;
            P2 = RectTransformUtility.WorldToScreenPoint(Camera.main, P1);
        }
        else
        {
            if(!touchFlag)///離れたときに戻す
            {
                GetComponent<RectTransform>().position = P1;
            }
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

public void GetDrop()///drop浮いてる！
    {
        touchFlag = true;
    }public void SetDrop()///dropおいた！
    {
        touchFlag = false;
        Delete();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(touchFlag)
        {
            if (d.CheckPos(m, collision.gameObject.GetComponent<DropCnt>().P2))
            {
                d.ChangePos(gameObject, collision.gameObject);
            }
        }
   
   
    }
    private async void Delete()
    {
        d.DeleteDrop();
        
    }
}
