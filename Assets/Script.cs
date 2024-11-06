using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    float extendDelta = 0.1f; // extend speed/collapse
    bool state; // lightsaber on/off
    float minScale = 0;
    float maxScale;
    float interpolation;
    float currentScale;
    float xScale;
    float zScale;

    public GameObject blade;

    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.x;
        zScale = transform.localScale.z;
        maxScale = transform.localScale.y;
        currentScale = maxScale;
        interpolation = maxScale / extendDelta;
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            extendDelta = state ? -Mathf.Abs(extendDelta) : Mathf.Abs(extendDelta);
        }
        currentScale += extendDelta * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        transform.localScale = new Vector3(xScale, currentScale, zScale);
        state = currentScale > 0;

        if(state==true && blade.activeSelf == false)
        {
            blade.SetActive(true);
        }
        else if(state==false && blade.activeSelf == true)
        {
            blade.SetActive(false);
        }
    }
}
