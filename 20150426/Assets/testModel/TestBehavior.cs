using UnityEngine;
using System.Collections;

public class TestBehavior : MonoBehaviour {
	public GameObject player;

	Transform L_hand;
	Transform L_arm_front;
	Transform L_arm_back;

	bool keybool=false;

	Vector3 targetPosition = new Vector3(0, 0.01f, 0);
	Quaternion targetRotation = Quaternion.Euler (90, 0, 0);

	float speed = 1000f;
	float SLerpSpeed=1f;
	// Use this for initialization
	void Start () {

		L_hand = player.transform.Find("body/L_arm_back/L_arm_front/L_hand");
		L_arm_front = player.transform.Find ("body/L_arm_back/L_arm_front");
		L_arm_back = player.transform.Find ("body/L_arm_back");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space"))
			keybool = true;
		else if (Input.GetKeyUp ("space"))
			keybool = false;

		if (keybool)
				MoveLeftArm ();
	}



	void MoveLeftArm()
	{
		if (L_arm_back.localEulerAngles.y <= 90) {
			if (L_hand.localEulerAngles.y <= 15)
				L_hand.Rotate (0, 1, 0, Space.Self);
			else if (L_arm_front.localEulerAngles.y <= 100)
				L_arm_front.Rotate (0, 1, 0, Space.Self);
			else 
				L_arm_back.Rotate (0, 1, 0, Space.Self);
		} else if(L_arm_back.localEulerAngles.y > 90 &&L_arm_back.localEulerAngles.y <= 180){

			if(L_arm_front.localEulerAngles.y>0 && L_arm_front.localEulerAngles.y <= 180)
				L_arm_front.Rotate (0, -2, 0, Space.Self);
			else
				L_arm_front.Rotate (0, 0, 0, Space.Self);

			L_arm_back.Rotate (0, 1, 0, Space.Self);
		}

	}

}
