using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour {

    public GameObject prefab;
    public FFTWindow quality;
    public AudioSource AS;
    public AudioListener AL;
    public int elementCount = 20;
    public float radius = 5f;
    public Material mat;
    public float r = 0.0F, g = 0.0F, b = 0.0F, v = 0.0F;
    public GameObject[] cubes;
    float[] spectrum = new float[1024];
    
    

    // Use this for initialization
    void Start () {

        r = PlayerPrefs.GetFloat("R");
        g = PlayerPrefs.GetFloat("G");
        b = PlayerPrefs.GetFloat("B");
        v = PlayerPrefs.GetFloat("V");

        for (int i = 0; i < elementCount; i++)
        {
            float angle = i * Mathf.PI * 2 / elementCount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }
        cubes = GameObject.FindGameObjectsWithTag("Cubes");
	}
	
	// Update is called once per frame
	void Update () {
        AL.GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, quality);
        for (int i = 0; i < elementCount; i++)
        {
            Vector3 previousScale = cubes[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 50, Time.deltaTime * 20);
            cubes[i].transform.localScale = previousScale;
        }
	}

    void OnGUI()
    {
        r = GUI.HorizontalSlider(new Rect(20, 10, Screen.width - 40, 20), r, 0.0F, 1.0F);
        g = GUI.HorizontalSlider(new Rect(20, 30, Screen.width - 40, 20), g, 0.0F, 1.0F);
        b = GUI.HorizontalSlider(new Rect(20, 60, Screen.width - 40, 20), b, 0.0F, 1.0F);
        v = GUI.HorizontalSlider(new Rect(20, 90, Screen.width - 40, 20), v, 0.0F, 1.0F);

        mat.color = new Color(r, g, b);
        AS.volume = v;

        PlayerPrefs.SetFloat("R", r);
        PlayerPrefs.SetFloat("G", g);
        PlayerPrefs.SetFloat("B", b);
        PlayerPrefs.SetFloat("V", v);
    }
}
