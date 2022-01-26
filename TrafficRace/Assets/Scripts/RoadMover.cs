using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMover : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject playerCar;
    private void Update()
    {
        //h�z� zaman ba�l� �ekilde artt�r ve yolu hareket ettir.
        speed += Time.deltaTime / 5;
        if (playerCar.GetComponent<CarController>().isGoing)
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        
        
    }
}
