using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D myBody;

    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float damageAmount = 25f;
    [SerializeField] private float deactivateTimer = 3f;
    [SerializeField] private bool destroyObj;

    private bool deathDamage;


    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();

        // get Anim

        Invoke("DeactivateBullet", deactivateTimer);

    }

    public void MoveInDirection(Vector3 direction)
    {
        myBody.velocity = direction * moveSpeed;
    }

    void DeactivateBullet()
    {
        if(destroyObj)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.ENEMY_TAG) || 
            collision.CompareTag(TagManager.SHOOTER_ENEMY_TAG) || 
            collision.CompareTag(TagManager.BOSS_TAG))
        {

        }

        if(collision.CompareTag(TagManager.BLOCKING_TAG))
        {

        }
    }
}
