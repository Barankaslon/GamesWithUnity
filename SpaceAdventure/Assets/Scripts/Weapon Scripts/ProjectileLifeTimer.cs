using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTimer : MonoBehaviour
{
    [SerializeField] public float timer = 3f;

    private void Start() 
    {
        Destroy(gameObject, timer);
    }
}
