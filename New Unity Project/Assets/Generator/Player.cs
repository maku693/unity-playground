using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
	private float speed;

	void FixedUpdate()
	{
        var up = Input.GetKey("w") ? 1f : 0f;
        var left = Input.GetKey("a") ? 1f : 0f;
        var down = Input.GetKey("s") ? 1f : 0f;
        var right = Input.GetKey("d") ? 1f : 0f;
        var velocity = Vector3.zero;
        velocity.z = up - down;
        velocity.x = left - right;
        GetComponent<Transform>().position += velocity * speed * Time.fixedDeltaTime;
	}
}
