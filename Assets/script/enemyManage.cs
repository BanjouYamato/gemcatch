using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManage : MonoBehaviour
{
    public float moveSpeed;
    UI uiM;
    // Start is called before the first frame update
    void Start()
    {
        uiM = FindObjectOfType<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uiM.RemainTime <= 15)
        {
            transform.Translate(Vector2.right* moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deathZone"))
        {
            Destroy(gameObject);
        }
    }
}
