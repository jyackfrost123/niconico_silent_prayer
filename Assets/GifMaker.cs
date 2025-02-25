using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifMaker : MonoBehaviour {
    //参考URL:https://qiita.com/aaaikmsu/items/ed9edf3622bd46ab5051

    public SpriteRenderer img;

    public Sprite[] anime;
    //public EffectAnimation animation; 
    private int spriteNum = -1;

    private bool Flg = false;

    private float flame;
    private float count = 0.0f;
    public float animeTime;

    public float fullCount = 0;

    void Start()
    {
        flame = animeTime / ( (float) anime.Length );
        //Debug.Log("flame"+flame);

        SetFlg(true);
    }

    void FixedUpdate()
    {
        if(!Flg) return;

        count += Time.deltaTime;
        //Debug.Log("count:"+count);
        fullCount += Time.deltaTime;

        if(count >= flame){


        spriteNum++;
        if(spriteNum < 0) spriteNum = 0;

        Sprite tex = anime[spriteNum];
        img.sprite = tex;

         if( anime.Length-1 <= spriteNum)
         {
             //SetFlg(false);
             spriteNum = 0;
             //Debug.Log("FullTime = " + fullCount);
             //Destroy(this.gameObject);
         }

        count = 0;

        }
    }

    public void SetFlg(bool _flg)
    {
        //Debug.Log("SetFlg( " + _flg + " )");

        if(_flg == true)
        {
            Sprite tex = anime[0];
            img.sprite = tex;
            //Debug.Log("img.sprite.name = " + img.sprite.name);
        }

        Flg = _flg;
    }

    public bool GetFlg()
    {
        return Flg;
    }
}
