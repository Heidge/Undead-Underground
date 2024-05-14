using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Intro : MonoBehaviour
{
    public GameObject generatorLightA;
    public GameObject generatorLightB;
    public GameObject baseLights;
    public GameObject leftLights;
    public GameObject rightLights;
    public GameObject middleLights;
    public GameObject fanA;
    public GameObject fanB;


    public void Awake()
    {
        PlayIntro();
    }
    public void PlayIntro()
    {
        StartCoroutine(SwitchBase(2.0f));
        StartCoroutine(SwitchOnProjectors(6f));
        StartCoroutine(rightLights.GetComponent<CorridorLights>().SwitchCorridor(8.0f));
        StartCoroutine(middleLights.GetComponent<CorridorLights>().SwitchCorridor(8.0f));
        StartCoroutine(leftLights.GetComponent<CorridorLights>().SwitchCorridor(8.0f));
    }

    IEnumerator SwitchBase(float time)
    {
        List<StairLight> lights = new();
        fanA.GetComponent<AudioSource>().Play();
        fanB.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(time);

        foreach (Transform child in baseLights.transform)
        {

            if (child.tag == "StairLight")
            {
                var light = child.GetComponent<StairLight>();
                lights.Add(light);

            }
        }
        lights = lights.OrderBy(lights => lights.transform.position.x).ToList();
        foreach (StairLight light in lights)
        {
            light.Switch(true);
        }

    }

    IEnumerator SwitchOnProjectors(float time)
    {
        var lightsA = generatorLightA.transform.Find("Lights");
        var lightsB = generatorLightB.transform.Find("Lights");
        var audioA = generatorLightA.GetComponent<AudioSource>();
        var audioB = generatorLightB.GetComponent<AudioSource>();
        audioA.Play();
        audioB.PlayDelayed(0.5f);
        yield return new WaitForSeconds(time);
        lightsA.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        lightsB.gameObject.SetActive(true);

        // Code to execute after the delay
    }


}
