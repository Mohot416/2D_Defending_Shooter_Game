using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    public Rigidbody2D enemy;
    //敵人隨機速度的下限與上限
    public float slowest = 1.0f, fastest = 10.0f;
    public int atk = 2; //敵人攻擊力，初始為2
    public int def = 0; //敵人防禦力，初始為0
    public int health = 100;    //敵人生命值，初始為100
    public int firePower = 55;

    //敵人預設速度(常數)、當前速度(變數)
    private float initialSpeed, currnetSpeed = 1.0f;
    public float InitialSpeed
    {
        get { return initialSpeed; }
        set { initialSpeed = value; }
    }
    public float CurrentSpeed
    {
        get { return currnetSpeed; }
        set { currnetSpeed = value; }
    }

    private void Start()
    {
        initialSpeed = Random.Range(slowest, fastest);
        currnetSpeed = initialSpeed;
        //獲取敵人剛體
        enemy = enemy.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //向左水平移動
        enemy.velocity = new Vector2(-currnetSpeed, enemy.velocity.y);
        if (health <= 0)
        {
            Destroy(gameObject, 0);
        }
    }

    //接觸到barriers就停下
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barriers")
            currnetSpeed = 0.0f;
    }

    //離開barriers就照原速度繼續前進
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Barriers")
            currnetSpeed = initialSpeed;
    }

    private void OnMouseDown()
    {
        health = health - (firePower - def);
    }
}
