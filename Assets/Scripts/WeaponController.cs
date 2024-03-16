using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Melee;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

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
        CanAttack = false;
        Animator colliderAnim = Melee.GetComponent<Animator>();
        colliderAnim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }
}
