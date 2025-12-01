using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : Animal
{
    private AudioSource goatAudio;
    public AudioClip goatClip;
    private float healthPoints = 1;
    private int damage = 1;
    public ParticleSystem damageParticle;
    void Start()
    {
        goatAudio = GetComponent<AudioSource>();
        StartCoroutine(PlaySound(goatClip, goatAudio));
    }

    void Update()
    {
        Move();
    }

    void DamagePlayer()
    {
        ParticleSystem obj = Instantiate(damageParticle, transform.position, transform.rotation);
        StartCoroutine(DestroyParticle(obj));
        SpawnManager.lives -= damage;
        UIHandler.instance.UpdateLives();
        if (SpawnManager.lives==0)
        {
            SpawnManager.instance.GameOver();
        }
    }

    public override void AnimalDieToBullet(Collider other,ref float hp)
    {
        ParticleSystem obj = Instantiate(deathParticle, transform.position, transform.rotation);
        StartCoroutine(DestroyParticle(obj));
        hp -= Bullet.damage;
        if (hp <= 0)
        {
            DamagePlayer();
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
