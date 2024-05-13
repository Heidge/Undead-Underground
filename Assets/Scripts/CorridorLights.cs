using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorridorLights : MonoBehaviour
{
    private List<StairLight> leftLights = new();
    private List<StairLight> rightLights = new();
    public void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "left")
            {
                foreach (Transform light in child)
                {
                    leftLights.Add(light.GetComponent<StairLight>());
                }
            }
            if (child.name == "right")
            {
                foreach (Transform light in child)
                {
                    rightLights.Add(light.GetComponent<StairLight>());
                }
            }
        }
        leftLights.OrderBy(x => Vector3.Distance(Vector3.zero, x.transform.position));
        rightLights.OrderBy(x => Vector3.Distance(Vector3.zero, x.transform.position));
    }

    public IEnumerator SwitchCorridor(float delay)
    {
        yield return new WaitForSeconds(delay);
        var len = leftLights.Count;
        var timer = 0.8f;

        for (int i = 0; i < len; i++)
        {
            leftLights[i].Switch(true);
            rightLights[i].Switch(true);
            yield return new WaitForSeconds(timer);
            timer -= 0.2f;
        }
    }




}
