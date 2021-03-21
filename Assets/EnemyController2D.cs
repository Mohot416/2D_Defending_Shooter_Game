using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    private float nowTime;
    private int count;
    public EnemySetting enemy;
    public BarrierStatusController barriers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.Attacking == true)   //攻擊
        {
            enemy.CurrentSpeed = 0.0f;    //stop to attack
            
        }
        else
        {
            enemy.CurrentSpeed = enemy.InitialSpeed;
        }

        if (enemy.CurrentSpeed <= 0.0f)
        {
            StartToAttack();
        }

        //print(enemy.Attacking);
        print(enemy.CurrentSpeed);
        print(barriers.HealthPoints);
    }

    //開始攻擊並呼叫攻擊函式
    private void StartToAttack()
    {
        
        InvokeRepeating("AttackingBarriers", 1.0f, 2.0f);
    }

    //攻擊函式
    private void AttackingBarriers()
    {
        nowTime = Time.time;
        Debug.Log("執行重復方法：" + nowTime);
        barriers.HealthPoints = barriers.HealthPoints - enemy.atk;
    }
}
