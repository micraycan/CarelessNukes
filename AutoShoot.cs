using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject projectile;

    private Transform updatedTransform;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        updatedTransform = transform;
    }

    void Shoot()
    {
        Instantiate(projectile, shootPoint.position, updatedTransform.rotation);
    }
}
