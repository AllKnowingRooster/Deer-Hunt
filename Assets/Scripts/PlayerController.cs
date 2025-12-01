using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 15.0f;
    private float maxX = 17.0f;
    private float minX = -6.0f;
    public GameObject bulletPrefab;
    private Vector3 offset;
    private float shootCooldown = 2.0f;
    private float shootTime=0.0f;
    void Start()
    {
        offset = new Vector3(0,1,4);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnManager.isGameActive)
        {
            if (transform.position.x >= maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }

            if (transform.position.x <= minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        }
    }

    private void OnMouseDown()
    {
        if (SpawnManager.isGameActive && Time.time >= shootTime)
        {
            Instantiate(bulletPrefab, transform.position + offset, bulletPrefab.transform.rotation);
            shootTime= Time.time+shootCooldown;
        }
    }

}
