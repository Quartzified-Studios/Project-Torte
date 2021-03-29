using UnityEngine;

public class PLAYER_TEST : MonoBehaviour
{
    Rigidbody2D rb;
    Camera camera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 300, Input.GetAxisRaw("Vertical") * Time.deltaTime * 300);
    }
}
