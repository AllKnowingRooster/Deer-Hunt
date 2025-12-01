using System.Collections;
using UnityEngine;

public class Deer : Animal
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private AudioSource deerAudio;
    public AudioClip bleatClip;
    private float healthPoints = 5;
    private int score = 1500;
    public ParticleSystem dodgeParticle;
    void Start()
    {
        deerAudio= GetComponent<AudioSource>();
        StartCoroutine(PlaySound(bleatClip,deerAudio));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void AnimalDieToBullet(Collider other, ref float hp)
    {
        ParticleSystem obj = Instantiate(deathParticle, transform.position, transform.rotation);
        hp -= Bullet.damage;
        DestroyParticle(obj);
        if (hp <= 0)
        {
            SpawnManager.instance.AddScore(AnimalMultiplier(score,transform.position.z));
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (SpawnManager.isGameActive)
        {
            if (Dodge())
            {
                ParticleSystem obj=Instantiate(dodgeParticle, transform.position, transform.rotation);
                StartCoroutine(DestroyParticle(obj));
            }
            else
            {
                AnimalDieToBullet(other, ref healthPoints);
            }
        }
    }

    public bool Dodge()
    {
        int chance=Random.Range(0,10);
        if (chance==0)
        {
            return true;
        }
        return false;
    }


}
