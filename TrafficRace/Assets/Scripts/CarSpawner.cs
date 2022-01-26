using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject playerCar;
    private int randomCar;
    private Vector3 randomCarSpawnPosition;
    private float maxRange = 4f;
    private Vector3 offset = new Vector3(0, 180, 0);
    private bool isGoing;
    private void Start()
    {
        //Araç oluþturmaya gecikme ekler
        Invoke("SpawnCar",3f);
        
    }
    private void Update()
    {
        isGoing = playerCar.GetComponent<CarController>().isGoing;
    }
    private void SpawnCar()
    {
        StartCoroutine(SpawnRandomCar());
    }
    IEnumerator SpawnRandomCar()
    {
        //X ekseninde rastgele sayý oluþturup listeden rastgele bir aracý orada oluþtur.
        yield return new WaitForSeconds(1);
        randomCar = Random.Range(0, cars.Length);
        randomCarSpawnPosition = new Vector3(Random.Range(-maxRange, maxRange), transform.position.y, transform.position.z);
        if (isGoing)
        {
            Instantiate(cars[randomCar], randomCarSpawnPosition, Quaternion.Euler(offset));
            
        }
        //Tekrarla
        StartCoroutine(SpawnRandomCar());
    }
}
