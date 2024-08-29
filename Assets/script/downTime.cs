using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downTime : MonoBehaviour
{
    public float fallingSpeed;
    timeManager tm;

    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<timeManager>();
    }

    // Update is called once per frame
    void Update()
    {

        fallingPoint();
    }
    void fallingPoint()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tm.downTime();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground") || collision.CompareTag("vatCan"))
        {
            Destroy(gameObject);
        }
    }
}
