using UnityEngine;
using System.Collections;

public class RoseSpectrum : MonoBehaviour {

    public GameObject prefab, prefab2, prefab3, prefab4;
    public GameObject core;
    public FFTWindow quality;
    public AudioSource AS;
    public AudioListener AL;
    public int elementCount;
    public float radius, radius2, radius3, radius4;
    public Material mat;
    float r = 0.0F, g = 0.0F, b = 0.0F, v = 0.0F;
    public GameObject[] cubes;
    public GameObject[] cubes2;
    public GameObject[] cubes3;
    public GameObject[] cubes4;

    float[] spectrum = new float[4096];
    
    public void ChangeCount(int newCount)
    {
        elementCount = newCount;
    }

    // Use this for initialization
    void Start () {

        r = PlayerPrefs.GetFloat("R");
        g = PlayerPrefs.GetFloat("G");
        b = PlayerPrefs.GetFloat("B");
        v = PlayerPrefs.GetFloat("V");
        
        radius2 = radius - 2;
        radius3 = radius2 - 2;
        radius4 = radius3 - 2;

        for (int i = 0; i < elementCount ; i++)
        {
            float angle = i * Mathf.PI * 2 / elementCount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Vector3 pos2 = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius2;
            Vector3 pos3 = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius3;
            Vector3 pos4 = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius4;
            Instantiate(prefab, pos, Quaternion.identity);
            Instantiate(prefab2, pos2, Quaternion.identity);
            Instantiate(prefab3, pos3, Quaternion.identity);
            Instantiate(prefab4, pos4, Quaternion.identity);
        }

        //Add cubes to respective arrays
        cubes = GameObject.FindGameObjectsWithTag("Cubes");
        cubes2 = GameObject.FindGameObjectsWithTag("Cubes2");
        cubes3 = GameObject.FindGameObjectsWithTag("Cubes3");
        cubes4 = GameObject.FindGameObjectsWithTag("Cubes4");

    }
	
	// Update is called once per frame
	void Update () {


        AL.GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, quality);

        //Getting an out of range exception when multiplying elementCount
        //Continuing to get out of range exception on cubes2 array
        for (int i = 0; i < elementCount; i++)
        { 
            //Default previous scale to most recent size
            Vector3 previousScale = cubes[i].transform.localScale;
            Vector3 previousScale2 = cubes2[i].transform.localScale;
            Vector3 previousScale3 = cubes3[i].transform.localScale;
            Vector3 previousScale4 = cubes4[i].transform.localScale;

            //Smoothly transition between scales
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 80, Time.deltaTime * 5);
            previousScale2.y = Mathf.Lerp(previousScale2.y, spectrum[i] * 90, Time.deltaTime * 5);
            previousScale3.y = Mathf.Lerp(previousScale3.y, spectrum[i] * 100, Time.deltaTime * 5);
            previousScale4.y = Mathf.Lerp(previousScale4.y, spectrum[i] * 110, Time.deltaTime * 5);

            //Current scale becomes previous scale
            //Set cubes to face core
            cubes[i].transform.localScale = previousScale;
            cubes[i].transform.LookAt(core.transform);
            cubes2[i].transform.localScale = previousScale2;
            cubes2[i].transform.LookAt(core.transform);
            cubes3[i].transform.localScale = previousScale3;
            cubes3[i].transform.LookAt(core.transform);
            cubes4[i].transform.localScale = previousScale4;
            cubes4[i].transform.LookAt(core.transform);

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
