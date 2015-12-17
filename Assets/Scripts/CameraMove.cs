using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public GameObject core;
    [Range(0.0f, 10.0f)]
    public float speed = 10;
    //Vector3 lerpstart = new Vector3(0, 8, 0);
    //Vector3 lerptarget = new Vector3(0, 2, 0);

    

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(core.transform);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        //transform.Translate(Vector3.Lerp(lerpstart, lerptarget, 0.5f));
    }
}
