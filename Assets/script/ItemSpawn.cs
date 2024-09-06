using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSpawn : MonoBehaviour
{
    public static ItemSpawn Instance {  get; private set; }
    protected float SpawnTime;

    protected float Timer;

    protected Vector2 randomPos;

    protected float fallingSpeed;

    protected Rigidbody2D rb;

   public bool directionFly;

    
    protected abstract void Effect();

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        fallingSpeed = 6f;
        Timer = GetTimer();
    }

    private void Update()
    {
        if (ScoreManager.Instance.GameOver)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        fallingAction();
    }

    public virtual void SpawnItem()
    {

        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            SpawnTime =GetSpawnTime();
            GetRandomPos();
             Instantiate(gameObject, randomPos, Quaternion.identity);
            Timer = SpawnTime;
        }
    }

    public virtual float GetSpawnTime() { return SpawnTime; }

    public virtual void GetRandomPos()
    {
        randomPos = new Vector2(Random.Range(-8.45f, 8.45f), 6);
    }

    public virtual float GetTimer()
    { return Timer; }

    protected virtual void fallingAction()
    {
        rb.velocity = Vector2.down * fallingSpeed;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundEffectManager.Instance.PlayPlusSound();
            Effect();
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Ground") ||
            collision.CompareTag("vatCan"))
        {
            SoundEffectManager.Instance.PlayMissSound();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("deathZone"))
        {
            Destroy(gameObject);    
        }
    }
}
