using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public GameObject cube;

    public GameObject turret;

    public Transform point1;
    public Transform point2;
    public float totalValue;

    private bool isForward = true;
    private float totalSeconds;
    private float currentSeconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(totalValue >= 1f)
        {
            isForward = false;
        } else if(totalValue <= 0f) 
        {
            isForward = true;
        }
        totalValue = Mathf.Clamp(isForward ? totalValue + Time.deltaTime : totalValue - Time.deltaTime, 0, 1f);
        cube.transform.position = Vector3.Lerp(point1.position, point2.position, totalValue);


        turret.transform.rotation = Quaternion.Lerp(point1.rotation, point2.rotation, totalValue);

        currentSeconds += Time.deltaTime;

    }
}
