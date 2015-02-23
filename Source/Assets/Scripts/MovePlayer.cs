using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    Vector3 PlayerPos;
    float fwd;
    float side;
    float Speed = 1;
    Vector3 move;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        fwd = Input.GetAxis("Horizontal") * Speed;
        side = Input.GetAxis("Vertical") * Speed;
        move = new Vector3(fwd, 0, side);

        transform.Translate(move);
	}
}
