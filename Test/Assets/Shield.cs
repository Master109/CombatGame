using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
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
		if (lm.GetLeftFinger() != null)
		{
			transform.localPosition = initPos + new Vector3(lm.GetLeftFinger().TipPosition.x, lm.GetLeftFinger().TipPosition.y, -lm.GetLeftFinger().TipPosition.z) * moveSensitivity;
			transform.localRotation = Quaternion.Inverse(Quaternion.LookRotation(new Vector3(-lm.GetLeftFinger().Direction.x, -lm.GetLeftFinger().Direction.y, -lm.GetLeftFinger().Direction.z)));
		}
	}
}
