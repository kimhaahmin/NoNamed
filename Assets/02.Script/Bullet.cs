using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed =10;
    [SerializeField] float lifeTime = 5;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
        Destroy(gameObject, lifeTime);
    }



}
