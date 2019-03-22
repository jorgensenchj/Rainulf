using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour {
    public float strikeRoll;
    public float woundRoll;
    public float armorsave;
    public float playerDurablity = 5;
    public float skill;
    public GameObject target;
    public int damagePerHit = 45;
    public AudioClip missClip;
    public AudioClip noWound;
    public AudioClip armorSave;
    AudioSource swingAudio;

    // Use this for initializationwo
    void Start ()
    {
        swingAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        Strike();
        target = collider.gameObject;
    }

        public void Strike()
    {
        strikeRoll = Random.Range(0, 10);
       
        if(strikeRoll >= skill)
        {
            Wound();
        }
        else if(strikeRoll < skill)
        {
            Debug.Log("miss");
            swingAudio.clip = missClip;
            swingAudio.Play();
        }
    }
    public void Wound()
    {
        woundRoll = Random.Range(0, 10);
        if (target != null)
        {
            EnemyDamage enemyDamage = target.GetComponent<EnemyDamage>();

            if (playerDurablity > enemyDamage.EnemyDuriablity)
            {
                if (woundRoll >= 3)
                {
                    ArmorSave();
                }else if (woundRoll < 3)
                {
                    Debug.Log("No wound taken");
                    swingAudio.clip = noWound;
                    swingAudio.Play();
                }
            }
            else
                if (playerDurablity < enemyDamage.EnemyDuriablity)
            {
                if (woundRoll >= 7)
                {
                    ArmorSave();
                }
                else if (woundRoll < 7)
                {
                    Debug.Log("No wound taken");
                    swingAudio.clip = noWound;
                    swingAudio.Play();
                }
            }
            else
             if (playerDurablity == enemyDamage.EnemyDuriablity)
            {
                if (woundRoll >= 5)
                {
                    ArmorSave();
                }
                else if (woundRoll < 5)
                {
                    Debug.Log("No wound taken");
                    swingAudio.clip = noWound;
                    swingAudio.Play();
                }
            }
           
        }
    }
    public void ArmorSave()
    {
        EnemyDamage enemyDamage = target.GetComponent<EnemyDamage>();
        armorsave = Random.Range(0, 10);
        Debug.Log("armorsave" + armorsave);
        if(armorsave <= enemyDamage.armorPlus)
        {
            Debug.Log(" Damage taken");
            enemyDamage.TakeDamage(damagePerHit);
        }
        else
        {
            Debug.Log("armorProtects");
            swingAudio.clip = armorSave;
            swingAudio.Play();
        }
    }
}
