using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public EnemyController ec;
    [SerializeField] private AudioClip damagesoundclip;
    public bool soundPlayed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.tag == "Enemy" && !soundPlayed)
        {
            SoundEffectScripts.instance.PlaySoundClip(damagesoundclip, transform, 1f);
            soundPlayed = true;
            StartCoroutine(ResetAttackSound());
        }

        if(trigger.tag == "Boss" && !soundPlayed)
        {
            SoundEffectScripts.instance.PlaySoundClip(damagesoundclip, transform, 1f);
            soundPlayed = true;
            StartCoroutine(ResetAttackSound());
        }
        
        if (trigger.tag == "Enemy" && wc.isAttacking)
        {
            trigger.gameObject.GetComponent<EnemyController>().EnemyTakeDamage(6);
            //Debug.Log("collision detected");
        }

        if (trigger.tag == "Boss" && wc.isAttacking)
        {
            trigger.gameObject.GetComponent<BossEnemyController>().EnemyTakeDamage(6);

        }
    }

    IEnumerator ResetAttackSound()
    {
        yield return new WaitForSeconds(1.0f);
        soundPlayed = false;
    }
}
