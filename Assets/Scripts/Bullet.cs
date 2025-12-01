using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20.0f;
    public static int damage { get; private set; } = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (transform.position.z >= 5.0f)
        {
            Destroy(gameObject);
        }
    }

}
