using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TutorialConroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(5.0f, () => gotoGamestart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void gotoGamestart(){
        //FadeManager.Instance.LoadScene ("GameScene", 0.5f);
        SceneManager.LoadScene("GameScene");
    }
}
