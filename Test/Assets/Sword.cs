using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{
	public LeapManager lm;
	public float moveSensitivity = 10;
	public Vector3 initPos;

	// Use this for initialization
	void Start ()
	{
		lm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LeapManager>();
		initPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lm.GetRightFinger() != null)
		{
			transform.localPosition = initPos + new Vector3(lm.GetRightFinger().TipPosition.x, lm.GetRightFinger().TipPosition.y, -lm.GetRightFinger().TipPosition.z) * moveSensitivity;
			transform.localRotation = Quaternion.Inverse(Quaternion.LookRotation(new Vector3(-lm.GetRightFinger().Direction.x, -lm.GetRightFinger().Direction.y, -lm.GetRightFinger().Direction.z)));
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.gameObject.tag == "Enemy")
		{
			Destroy(collision.collider.gameObject);
		}
	}
}
