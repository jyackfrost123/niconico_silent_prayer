using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Security.Cryptography;
using unityroom.Api;

public class UIController : MonoBehaviour
{

    public GameObject deleteText;
    public GameObject bgm;
    public GameObject playerTextObject;

    public GameObject honkeDeletedText;
    public GameObject honkeBgm;
    public GameObject honkePlayerTextObject;

    public TextMeshProUGUI scoreText;

    public int score;

    public TextMeshProUGUI timeText;
    public float time;

    private bool isgameStart = false;
    public bool isgameEnd = false;

    public GameObject explosion;
    public Vector3 explosionPoint;
    private bool isExplosion = false;

    public GameObject buttons;
    public GameObject fooText;

    public TextMeshProUGUI playerText;
    bool isDeketepkayerText = false;

    private parameterController para;

    public kusaGenerator generator;

    private void Awake(){

        para = GameObject.Find("UnityroomApiClient").GetComponent<parameterController>();

        //曲、文章、fooTextの参照を変える
        if(!para.isHonke){ // 通常
            deleteText.SetActive(true);
            bgm.SetActive(true);
            playerTextObject.SetActive(true);

            honkeDeletedText.SetActive(false);
            honkeBgm.SetActive(false);
            honkePlayerTextObject.SetActive(false);

            playerText = playerTextObject.GetComponent<TextMeshProUGUI>();
        }else{ //本家
            deleteText.SetActive(false);
            bgm.SetActive(false);
            playerTextObject.SetActive(false);

            honkeDeletedText.SetActive(true);
            honkeBgm.SetActive(true);
            honkePlayerTextObject.SetActive(true);

            playerText = honkePlayerTextObject.GetComponent<TextMeshProUGUI>();

        }

    }

    void Start()
    {
        para = GameObject.Find("UnityroomApiClient").GetComponent<parameterController>();

        score = 0;
        scoreText.text = score.ToString();

        isgameStart = true;

        timeText.text = time.ToString();

        buttons.SetActive(false);

    }

    void FixedUpdate()
    {

        if(time >= 1){
            time -= Time.deltaTime;
            timeText.text = ((int)time+1).ToString();

            if(! isDeketepkayerText && time <= 33.0f){
                setplayerTextDelete();
                isDeketepkayerText = true;
            }
        }else{
            isgameEnd = true;
            if(!isExplosion){
                timeText.text = "";
                fooText.SetActive(false);
                generator.deleteAllComments();
                DOVirtual.DelayedCall(3, () => buttons.SetActive(true));
                UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);//スコア


                Instantiate(explosion, explosionPoint, Quaternion.identity );
                isExplosion = true;
            }
        }
    }

    public void AddScore(){
        if(!isgameEnd && isgameStart){
            score++;
            scoreText.text = score.ToString();

            if(score % 50 == 0){
                UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);//スコア
            }
        }
    }

    public void setplayerTextDelete(){
        DOTween.ToAlpha(
	            ()=> playerText.color,
	            color => playerText.color = color,
	            0.0f, // 目標値
	            1.0f // 所要時間
        );
    }

}
