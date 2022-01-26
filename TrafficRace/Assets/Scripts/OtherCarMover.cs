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
        //araca rastgele hýz verme
        speed = Random.Range(minSpeed, maxSpeed);
    }
    private void Update()
    {
        //Hýzý zamana baðlý þekilde arttýrma
        speed += Time.deltaTime / 5;
        //Rakip aracýn hareketi
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        //Araç belirli bir pozisyona gelince yok et
        if (transform.position.z < -maxRange)
        {
            Destroy(this.gameObject);
        }
    }
}
