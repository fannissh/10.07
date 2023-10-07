using System;
using UnityEngine;

class HPObject : MonoBehaviour
{
    [SerializeField] int startHP = 10;

    int hp;

    void Start()
    {
        hp = startHP;
    }

    public void Damage(int damage)
    {
        if (hp <= 0) return;

        hp -= damage;

        if(hp <0)
           hp = 0;

        if(hp <= 0)
        {
            Debug.Log("I'm dead");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            hp = startHP;
        }
    }
}
