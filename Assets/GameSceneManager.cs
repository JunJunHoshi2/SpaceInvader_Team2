using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] Text UIText;
    int timer = 3; //タイマーです。初期値は3
    [SerializeField] List<GameObject> EnemyPortList = new List<GameObject>();
    public static int Score = 0;
    AudioSource audioSource;
    [SerializeField] AudioClip BGM = null;
    [SerializeField] Button button;

    void Start()
    {
        Invoke("DecreaseTimer", 1); // 3 -> 2 に変更 
        Invoke("DecreaseTimer", 2); //2 -> 1 に変更
        Invoke("CallStart", 3); //GameStart!と表示
    }

    void DecreaseTimer() //timerの数字を1だけ減らしてUIに表示する
    {
        timer -= 1;
        UIText.text = timer.ToString();
        //audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(BGM);
    }

    public void AddScoreToText() //他のスクリプトからアクセスするからpublicで！
    {
        UIText.text = "Score: " + Score.ToString();  //テキストにスコアを代入
        UIText.gameObject.SetActive(true);  //テキストをアクティブにする
        button.gameObject.SetActive(true);
        for (int i = 0; i < EnemyPortList.Count; i++)
        {
            EnemyPortList[i].SetActive(false);

        }
    }

    void CallStart() //GameStart!と表示
    {
        UIText.text = "GameStart!!";
        Invoke("DeactiveText", 1);
        for(int i = 0; i < EnemyPortList.Count; i++)
        {
            EnemyPortList[i].SetActive(true);
            
        }
        
    }
    void DeactiveText()
    {
        UIText.gameObject.SetActive(false);
    }
}
