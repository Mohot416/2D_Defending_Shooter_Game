using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private int num;
    public int Num
    {
        get { return num; }
        set { num = value; }
    }
    private int atk;
    public int Atk
    {
        get { return atk; }
        set { atk = value; }
    }
    public Enemy(int inputAtk, int inputNum) //constructor
    {
        atk = inputAtk;
        num = inputNum;
    }
}

public class BarrierStatusController : MonoBehaviour
{
    private Enemy small = new Enemy(2, 0);
    private Enemy middle = new Enemy(5, 0);     //3 types of enemys
    private Enemy giant = new Enemy(10, 0);
    private bool IsCoroutine = false;
    public int HealthPoints = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints <= 0)
        {
            Destroy(gameObject, 0);
            //Game Over
            return;
        }
        if (IsCoroutine == false)   //防止同時重複過多Coroutine
        {
            if (small.Num > 0 || middle.Num > 0 || giant.Num > 0)
            {
                StartCoroutine(BeingAttacked(small, middle, giant));
                IsCoroutine = true;
            }
        }
    }

    IEnumerator BeingAttacked(Enemy small, Enemy middle, Enemy giant)
    {
        //Debug.Log("CoroutineTest Start At" + Time.time);
        //lose health
        HealthPoints = HealthPoints - (small.Atk * small.Num) - (middle.Atk * middle.Num) - (giant.Atk * giant.Num);
        yield return new WaitForSeconds(1f);
        IsCoroutine = false;
        //Debug.Log("CoroutineTest End At" + Time.time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Small_Enemy")
            small.Num++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Small_Enemy")
            small.Num--;
    }
}
