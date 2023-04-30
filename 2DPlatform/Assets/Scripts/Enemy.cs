using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 0f;
    public float Speed = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Attack"))
        {
            HP -= 1;
            if (HP <= 0) Die();
        }
	}

    void Die()
    {
        Destroy(this.gameObject);
    }

	void Move()
    {
		Vector3 move = new Vector3(Speed * Time.deltaTime, 0, 0);

		transform.position -= move;
	}
}