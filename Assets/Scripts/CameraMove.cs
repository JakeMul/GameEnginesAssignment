using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public GameObject core;
    public int speed = 10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(core.transform);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
