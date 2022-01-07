using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] GameObject boomEffect;
    [SerializeField] AudioClip destroySound;

    public float minDamage = 10f;
    public float maxDamage = 30f;
    private float _projectileDamage;

    private void Start() 
    {
        _projectileDamage = (int)Random.Range(minDamage, maxDamage);
    }

    private void OnEnable()
    {
        if(spawnSound)
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 6f, 0f));
    }

    private void Update() 
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(_projectileDamage);
        }

        if(collision.CompareTag(TagManager.ENEMY_TAG) || collision.CompareTag(TagManager.METEOR_TAG))
        {
            // deal Damage
            collision.GetComponent<EnemyHealth>().TakeDamage(_projectileDamage, 0f);
        }

        if(!collision.CompareTag(TagManager.UNTTAGED_TAG) && !collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            gameObject.SetActive(false);
        }
    }

}
