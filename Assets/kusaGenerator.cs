using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class kusaGenerator : MonoBehaviour
{

    UIController ui;

    private float gameTime;

    public GameObject[] kusaObject;

    public GameObject kusaParent_base;

    private GameObject kusaParent;


    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        kusaParent = Instantiate(kusaParent_base, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void FixedsUpdate()
    {
        gameTime = ui.time;
    }

    public void GenerateNewKusa(){

        float tmp_x = 7.0f;
        float tmp_y = 0;
        float tmp_z = 5.0f;

        int num = 0;

        //座標の抽選
        int rand = Random.Range(0, 101);
        
        int y_pos = 0;
        if(rand < 70){//7割の確率で上のほうに出る
            y_pos = Random.Range(3, 8);//3~7
        }else{
            y_pos = Random.Range(-3, 3);//-3~2
        }

        //y_pos = Random.Range(-3, 8);//-3~2
        
        tmp_y = (float)y_pos * 0.5f;//yが0.5ごとに区切りでコメントを表示

        //x軸に生成時のばらつきをややつけることで、かぶりを回避？
        tmp_x += (float) (3 * Random.Range(0, 4));
        
        //コメントの種類の抽選
        //num = Random.Range(-1, kusaObject.Length);

        if(ui.time >= 32){//開始直後
            num = Random.Range(0, 4);//0~3
        }else if( 1 < ui.time && ui.time <= 8){//終了間際
            num = Random.Range(kusaObject.Length - 4, kusaObject.Length );//kusaObject.Length-4 ~ kusaObject.Length -1
        }else{
            if(! ui.isgameEnd) num = Random.Range(4, kusaObject.Length - 5);// 4 ~ kusaObject.Length - 6
            else num = Random.Range(4, kusaObject.Length - 4);// 4 ~ kusaObject.Length - 5
        }

        //Debug.Log(num);

        //生成
        GameObject obj = Instantiate(kusaObject[num], new Vector3(tmp_x, tmp_y, tmp_z), Quaternion.identity);

        //爆破する前に、
        if(kusaParent != null) obj.transform.parent = kusaParent.transform;

        //消すべきコメントは消すフラグを作る
        /*if(){
            obj.GetComponent<kusaController>().isDeleteCommnet = true;
        }*/


    }

    public void deleteAllComments(){
        Destroy(kusaParent);
        kusaParent = null;
    }
}
