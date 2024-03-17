using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Melee;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    //public AudioClip AttackSound;
    public bool isAttacking = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Melee"))
        {
            if (CanAttack)
            {
                MeleeAttack();
                //Debug.Log("Attack Executed.");
            }
        }
    }

    public void MeleeAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator colliderAnim = Melee.GetComponent<Animator>();
        colliderAnim.SetTrigger("Attack");
        //AudioSource as = GetComponent<AudioSource>();
        //as.PlayOneShot(AttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
