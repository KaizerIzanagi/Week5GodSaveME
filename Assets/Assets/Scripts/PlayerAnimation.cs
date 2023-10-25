using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    int horizontal, vertical;

    private void Awake()
    {
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalmovement, float verticalmovement)
    {
        //damp time = blend time
        if (PlayerManager.Instance.isSprinting)
        {
            verticalmovement = 2;
        }
        if (PlayerManager.Instance.isWalking)
        {
            verticalmovement = 0.5f;
        }
        PlayerManager.Instance.playerAnim.SetFloat(horizontal, horizontalmovement, 0.1f, Time.deltaTime);
        PlayerManager.Instance.playerAnim.SetFloat(vertical, verticalmovement, 0.1f, Time.deltaTime);
    }
}
