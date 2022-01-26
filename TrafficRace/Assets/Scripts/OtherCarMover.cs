using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private float minSpeed = 15f;
    private float maxSpeed = 25f;
    private float maxRange = 140;
    private void Start()
    {
        //araca rastgele h�z verme
        speed = Random.Range(minSpeed, maxSpeed);
    }
    private void Update()
    {
        //H�z� zamana ba�l� �ekilde artt�rma
        speed += Time.deltaTime / 5;
        //Rakip arac�n hareketi
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        //Ara� belirli bir pozisyona gelince yok et
        if (transform.position.z < -maxRange)
        {
            Destroy(this.gameObject);
        }
    }
}
