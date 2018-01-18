using System.Collections;


using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour {

    public Transform Player;

    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();

        Player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = Player.position - this.transform.position;

        dir.Normalize();

        rigid.velocity = dir;
	}
}
