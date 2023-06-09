using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBullet : MonoBehaviour
{
    public float forceFactor = 200f;

    List<Rigidbody> rgBalls = new List<Rigidbody>();

    Transform magnetP;

    void Start()
    {
        magnetP = GetComponent<Transform>();
    }

    private void FixedUpdate() {
        foreach (Rigidbody rgBall in rgBalls)
        {
            rgBall.AddForce((magnetP.position - rgBall.position) * forceFactor * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Magnetic")){
            rgBalls.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Magnetic")){
            rgBalls.Remove(other.GetComponent<Rigidbody>());
        }
    }
}
