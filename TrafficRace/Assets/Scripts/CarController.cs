using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleInputNamespace;

public class CarController : MonoBehaviour
{
    [SerializeField] private float maxRightRange = 4f;
    [SerializeField] private float maxForwardRange = 9f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float turnSpeed = 3f;
    [SerializeField] private GameObject gameManager;
    private int score;

    [SerializeField] public bool isGoing = false;
    [SerializeField] public GameObject StartPanel;
    private void Update()
    {
        if (isGoing)
        {
            //Araç hareket ediyorsa bu menzillerin arasýnda aracý hareket ettir.
            horizontalInput = SimpleInput.GetAxis("Horizontal");
            verticalInput = SimpleInput.GetAxis("Vertical");
            Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
            transform.Translate(move * turnSpeed * Time.deltaTime);
            if (transform.position.x > maxRightRange)
            {
                transform.position = new Vector3(maxRightRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -maxRightRange)
            {
                transform.position = new Vector3(-maxRightRange, transform.position.y, transform.position.z);
            }
            if (transform.position.z > maxForwardRange - maxForwardRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxForwardRange - maxForwardRange);
            }
            if (transform.position.z < -maxForwardRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -maxForwardRange);
            }
        }
        score = gameManager.GetComponent<GameManager>().intScore;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //EnemyCar taglý bir objeye çarparsa sahneyi baþtan yükle
        if (collision.gameObject.CompareTag("EnemyCar"))
        {
            isGoing = false;
            SceneManager.LoadScene(1);
            if (score > PlayerPrefs.GetInt("totalScoreKey"))
            {
                PlayerPrefs.SetInt("totalScoreKey", score);
            }
            
        }
        
    }
}
