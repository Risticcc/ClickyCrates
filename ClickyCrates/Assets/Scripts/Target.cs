using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public int points = 5;
    public ParticleSystem explosionParticle;
    
    
    private Rigidbody _target;
    private  int _minSpeed = 12;
    private  int _maxSpeed = 16;
    private int _maxTorque = 10;
    private int xRange = 4;
    private int yPosition = -6;

    //private GameManager _gameManager;

    void Start()
    {
        _target = GetComponent<Rigidbody>();
        _target.AddForce(RandomForce(), ForceMode.Impulse);
        _target.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

       // _gameManager = GetComponent<GameManager>();
       // Debug.Log(_gameManager);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Random.Range(_minSpeed, _maxSpeed)* Vector3.up;
    } 
    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
    
    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPosition);

    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            GameManager.Instance.ScoreUpdate(points);
        }
    }

    //if game object fall below the sensor it will be destroyed
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
            GameManager.Instance.GameOver();
        Destroy(gameObject);

    }


}
