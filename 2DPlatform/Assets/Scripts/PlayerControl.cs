using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidbody = null;
    public float JumpForce = 0f;
    public float WalkForce = 0f;
	public GameObject AttackEffect = null;
	public Transform AttackPostion = null;
    public Transform AttackDown = null;
    public Transform AttackUp = null;
    public float EffectGone = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();

        Move(Input.GetAxis("Horizontal"));

		if (Input.GetKeyDown(KeyCode.Z)) Attack();
	}

    void Jump()
    {
        rigidbody.AddForce(Vector3.up * JumpForce);
    }

    void Move(float horizontalInput)
    {
		Vector3 scale = transform.localScale;
        Vector3 move = new Vector3 (horizontalInput * WalkForce * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && scale.x > 0)
        {
			scale.x *= -1;
			transform.localScale = scale;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && scale.x < 0)
		{
			scale.x *= -1;
			transform.localScale = scale;
		}

		//transform.Rotate(new Vector3(0, horizontalInput * 3600, 0));
		transform.position += move;
    }

    void Attack()
    {
        GameObject attack = Instantiate(AttackEffect);
        attack.transform.position = AttackPostion.position;

        if (this.rigidbody.velocity.y != 0 && Input.GetKey(KeyCode.DownArrow))
        {
            attack.transform.position = AttackDown.position;
            attack.transform.Rotate(0, 0, -90);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
			attack.transform.position = AttackUp.position;
			attack.transform.Rotate(0, 0, 90);
		}

		else if (this.transform.localScale.x < 0)
        {
			Vector3 scale = attack.transform.localScale;
            scale.x *= -1;
            attack.transform.Rotate(0, 0, 32);
            attack.transform.localScale = scale;
        }
        attack.SetActive(true);

        Destroy(attack, EffectGone);
    }
}
