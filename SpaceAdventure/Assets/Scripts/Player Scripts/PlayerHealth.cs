using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float playerMaxHealth = 100f;
    [SerializeField] private GameObject playerExplosionFX;
    [SerializeField] private GameObject playerDamageFX;

    private float playerHealth;
    private Collectable collectable;

    private Slider playerhealthSlider;

    private void Awake() 
    {
        playerhealthSlider = GameObject.FindWithTag(TagManager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();
        playerHealth = playerMaxHealth;
        playerhealthSlider.minValue = 0;
        playerhealthSlider.maxValue = playerHealth;
        playerhealthSlider.value = playerHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;

        playerhealthSlider.value = playerHealth;

        if (playerHealth <= 0f)
        {
            Instantiate(playerExplosionFX, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDestroySound();

            GameOverUIController.instance.OpenGameOverPanel();

            Destroy(gameObject);
        }
        else
        {
            Instantiate(playerDamageFX, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDamageSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectable = collision.GetComponent<Collectable>();

            if(collectable.type == CollectableType.Health)
            {
                
                playerHealth += collectable.healthValue;

                if (playerHealth > playerMaxHealth)
                    playerHealth = playerMaxHealth;

                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20, 40));
            Destroy(collision.gameObject);
        }
    }

}
