using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using unityroom.Api;

public class ButtonController : MonoBehaviour
{

   //parametorController para;
   //public GameObject[] Omakes;

   private int isPushed;
   parameterController para;
    
    
    void Start()
    {
     /*
     if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
     }
     */

     isPushed = 0;
     para = GameObject.Find("UnityroomApiClient").GetComponent<parameterController>();
      
    }

    public void goTweet(){

        UIController ui = GameObject.Find("Canvas").GetComponent<UIController>();

        if(ui != null){
            if(para != null){
                if(!para.isHonke) naichilab.UnityRoomTweet.Tweet ("nic0movie_negi", "あなたは破壊された^^動画のために"+ui.score+"回"+"「いいね！」しました。 \n #unityroom #nic0_negi \n");
                else naichilab.UnityRoomTweet.Tweet ("nic0movie_negi", "あなたはニコニコ動画のために"+ui.score+"回"+"「いいね！」しました。 \n #unityroom #nic0_negi \n");
            }
        }
               //StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("あなたは破壊された動画サイトのために"+100+"回"+"「いいね」しました。"));//画像あり
    }

    public void goRanking(){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);

        UIController ui = GameObject.Find("Canvas").GetComponent<UIController>();
         if(ui != null){
            UnityroomApiClient.Instance.SendScore(1, ui.score, ScoreboardWriteMode.HighScoreDesc);
         }
    }

    public void goResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 0);
        UnityroomApiClient.Instance.SendScore(1, 1, ScoreboardWriteMode.HighScoreDesc);
    }
    
    
    /*
    public void go2ndRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 1);
    }

    public void go2ndResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 1);
    }
    */
    

    public void ReStart(){
        FadeManager.Instance.LoadScene ("GameScene", 0.5f);

        /*
        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameScene", 1.0f);
        }
        */
        
        
    }

    public void FastReStart(){
         SceneManager.LoadScene("GameScene");
    }

    public void goLoadingScene(){
         FadeManager.Instance.LoadScene ("Tutorial", 1.0f);
         //SceneManager.LoadScene("Tutorial");
    }

    public void Re2ndStart(){

        //FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);

        /*
        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);
        }
        */
        
        
    }

     public void Fast2ndReStart(){
         SceneManager.LoadScene("EndressGameScene");
    }

    public void goTutorial(){
        FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene ("Title", 0.5f);
    }

    public void PushIsHonke(){
        isPushed++;
        if(isPushed >= 20) para.isHonkeTrue();
    }

 
}
