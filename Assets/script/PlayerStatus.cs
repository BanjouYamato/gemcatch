using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerStatus : MonoBehaviour
{


    SpriteRenderer sr;
    private void Awake()
    {

        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
    }
    private void Update()
    {
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("speedBuff"))
        {
            StartCoroutine(SpeedEffect());
        }
    }

    public IEnumerator SpeedEffect()
    {
       
            PlayerController.Instance.moveSpeed += 3;
            sr.color = Color.red;
            yield return new WaitForSeconds(5f);
            PlayerController.Instance.moveSpeed -= 3;
            sr.color = Color.white;
        
    }

}
