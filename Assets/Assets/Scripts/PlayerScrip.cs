using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    private Animator playerAnim;
    [Range(0, 15)]
    public float speed;
    public Transform targetPos;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            //MoveForward();
            Speen();
        }
    }

    void MoveForward()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos.position, speed * Time.deltaTime);
    }

    void Speen()
    {
        speed = 1;
        playerAnim.SetBool("isSpinning", true);
    }

    void StopMovement()
    {
        speed = 0;
        playerAnim.SetBool("isRunning", false);
    }
}
