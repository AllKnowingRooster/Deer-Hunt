using System.Collections;
using System.Transactions;
using Unity;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public abstract class Animal:MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 3.0f;
    private float maxX = 20.0f;
    public float clipInterval = 3.0f;
    private float particleDuration = 0.5f;
    public ParticleSystem deathParticle;

    public void Move()
    {
        if (SpawnManager.isGameActive)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            DestroyAnimal();
        }
    }

    private void DestroyAnimal()
    {
        if (transform.position.x>=maxX)
        {
            ParticleSystem obj = Instantiate(deathParticle, transform.position, transform.rotation);
            StartCoroutine(DestroyParticle(obj));
            Destroy(gameObject);
        }
    }

    public abstract void AnimalDieToBullet(Collider other, ref float hp);

    public int AnimalMultiplier(int score, float position)
    {
        if (position==-25.0f)
        {
            return score;
        }else if (position == -13.0f)
        {
            return score * 2;
        }
        return score*3;
    }

    public IEnumerator DestroyParticle(ParticleSystem particle)
    {
        yield return new WaitForSeconds(particleDuration);
        Destroy(particle.gameObject);
    }

    public IEnumerator PlaySound(AudioClip clip,AudioSource audio)
    {
        yield return new WaitForSeconds(clipInterval);
        audio.PlayOneShot(clip, 0.5f);
    }



}
