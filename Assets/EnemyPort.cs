using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPort : MonoBehaviour
{
    [SerializeField] public float time = 180f;
    [SerializeField] GameObject NormalEnemy;
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SetNextEnemy();
        Invoke("Destroy", time);
    }

    //次の敵を生成するタイミングを決定する関数
    void SetNextEnemy()   //ランダムな時間後にGenerateEnemyを呼び出す
    {
        float interval = Random.Range(1f, 6f);  //0~3秒のランダムな時間をintervalと置く
        Invoke("GenerateEnemy", interval);  //interval時間後にGenerateEnemyを呼び出す
    }

    //敵を生成する関数
    void GenerateEnemy()  //敵を生成してからSetNextEnemy呼び出す
    {
        int enemyindex = Random.Range(0, 3);  //変数enemyindexに0~2のランダムな数字を入れる（範囲は0以上3未満）
        GameObject enemy = Instantiate(EnemyList[enemyindex]);  //敵を生成
        enemy.transform.position = this.transform.position; //生成した敵の位置を、このEnemyPortの位置に調整
        SetNextEnemy();
    }

    private void Destroy()
    {

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
