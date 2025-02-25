using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq.Expressions;
using TMPro;

public class CommentController : MonoBehaviour
{
    public RectTransform comment;
    public TextMeshProUGUI playerLogo;
    public float StartY;
    public float EndY;

    public float EndMinutes;
    public float playerMinutes;

    private float posX;


    // Start is called before the first frame update
    void Start()
    {
        posX =  comment.anchoredPosition.x;
        Color currentColor = playerLogo.color;
        currentColor.a = 0.0f;
        playerLogo.color = currentColor;

        comment.anchoredPosition = new Vector2(posX, StartY);
        comment.DOAnchorPos(new Vector2(posX, EndY), EndMinutes).SetEase(Ease.Linear)
        .OnComplete(setPlayerColor);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void setPlayerColor(){
        DOTween.ToAlpha(
	            ()=> playerLogo.color,
	            color => playerLogo.color = color,
	            1.0f, // 目標値
	            playerMinutes // 所要時間
        );
    }
}
