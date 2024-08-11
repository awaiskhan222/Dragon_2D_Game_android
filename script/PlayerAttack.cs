using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float timeafterattack;
    [SerializeField] private float attackTimer = Mathf.Infinity;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        /*if (Input.GetMouseButton(0) && attackTimer > timeafterattack && playerMovement.CanAttack())
        {
            print("attack");
            attack();

        }*/

        attackTimer += Time.deltaTime;

    }
    public void attack()
    {
        if (attackTimer > timeafterattack && playerMovement.CanAttack())
        {
            anim.SetTrigger("attack");

            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<ProjectileFireball>().SetDirection(Mathf.Sign(transform.localScale.x));

            attackTimer = 0;
        }
        
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
