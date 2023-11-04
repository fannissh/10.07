using System;
using System.Collections;
using UnityEngine;

class HPObject : MonoBehaviour
{
    [SerializeField] int startHP = 10;
    [SerializeField] float invincibilityFrames = 2f;
    [SerializeField] float flickTime = 0.06f;

    int hp;

    void Start()
    {
        hp = startHP;
    }

    public void Damage(int damage)
    {
        if (hp <= 0) return;

        hp -= damage;
        StartCoroutine(StartInvincibility());

        if(hp <0)
           hp = 0;

        if(hp <= 0)
        {
            Debug.Log("I'm dead");
        }
    }
    IEnumerator StartInvincibility()
    {
        Collider coll = GetComponentInChildren<Collider>();
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        coll.enabled = false;
        float maxTime = Time.time + invincibilityFrames;
        while (Time.time < maxTime)
        {
            yield return new WaitForSeconds(flickTime);
            foreach (var renderer in renderers)
                renderer.enabled = !renderer.enabled;
            
        }

        foreach (Renderer renderer in renderers)
            renderer.enabled = true;

        coll.enabled = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            hp = startHP;
        }
    }
}
