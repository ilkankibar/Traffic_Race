using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    
    private void Start()
    {
        //yol box colliderýnýn yarýsýna geldiðinde pozisyonunu sýfýrla
        startPos = transform.position;
        repeatWidth = (GetComponent<BoxCollider>().size.z / 2);
    }
    private void Update()
    {
        
        if (transform.position.z < -repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
