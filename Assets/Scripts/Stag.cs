using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stag : Animal
{
    private AudioSource StagAudio;
    public AudioClip bleatClip;
    private float regenCooldown = 0.0f;
    private float healthPoints = 8;
    private float regenTime = 2.0f;
    public ParticleSystem regenParticle;
    private int score = 1000;
    void Start()
    {
        StagAudio = GetComponent<AudioSource>();
        StartCoroutine(PlaySound(bleatClip,StagAudio));
    }

    void Update()
    {
        Move();
        Regen();
    }

    void Regen()
    {
        if (healthPoints<8 && Time.time>=regenCooldown)
        {
            healthPoints += 1;
            ParticleSystem obj=Instantiate(regenParticle, transform.position, transform.rotation);
            regenCooldown = Time.time+regenTime;
            StartCoroutine(DestroyParticle(obj));
        }
    }

    public override void AnimalDieToBullet(Collider other, ref float hp)
    {
        ParticleSystem obj = Instantiate(deathParticle, transform.position, transform.rotation);
        DestroyParticle(obj);
        hp -= Bullet.damage;
        if (hp <= 0)
        {
            SpawnManager.instance.AddScore(AnimalMultiplier(score, transform.position.z));
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SpawnManager.isGameActive)
        {
            AnimalDieToBullet(other, ref healthPoints);
        }
    }


}
