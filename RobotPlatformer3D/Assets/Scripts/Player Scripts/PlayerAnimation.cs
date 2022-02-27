using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void Play_Run(float speed)
    {
        anim.SetFloat(TagManager.RUN_ANIMATION_PARAMETER, speed);
    }

        public void Play_Jump(bool isGrounded)
    {
        anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, isGrounded);
    }
}
