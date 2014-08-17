using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public LeapManager lm;
	public float moveSensitivity = 10;
	public float rotateSensitivity = 10;
	public float rota;
	
	// Use this for initialization
	void Start ()
	{
		lm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LeapManager>();
		rota = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lm.GetRightFinger() != null)
			transform.position += transform.forward * -lm.GetRightFinger().TipPosition.z * moveSensitivity;
		if (lm.GetRightFinger() != null)
		{
			rota += lm.GetRightFinger().Direction.x * rotateSensitivity;
			transform.rotation = Quaternion.Euler(new Vector3(0, rota, 0));
		}
	}
}
