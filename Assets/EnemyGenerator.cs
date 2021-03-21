using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawn enemy randomly

public class EnemyGenerator : MonoBehaviour
{
    //public就能容許從外部放入指定物件
    public Transform[] enemySpawnPoints;    //敵人的出生點
    public GameObject[] enemys;     //欲生成的敵人
    public float insTime = 1;  //每幾秒生成一次

    private void Start()
    {
        InvokeRepeating("GenerateEnemy", insTime, insTime);
        //重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)
    }
    
    void GenerateEnemy()
    {
        int Random_Objects = Random.Range(0, enemys.Length);
        //隨機產生0~物件陣列長度的整數-1(不包含最大值所以-1)

        int Random_Points = Random.Range(0, enemySpawnPoints.Length);
        //隨機產生0~生成點陣列長度的整數-1(不包含最大值所以-1)

        Instantiate(enemys[Random_Objects], enemySpawnPoints[Random_Points].transform.position, enemySpawnPoints[Random_Points].transform.rotation);
        //Instantiate實例化(要生成的物件, 物件位置, 物件旋轉值);
    }
}

