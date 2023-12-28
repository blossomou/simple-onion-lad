using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Animator gunAnimate;
    [SerializeField] private Transform gun; 

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gun.position;

        //formula to calculate angle between the gun and mouse position so we can rotate
        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    public void Shoot()
    {
        gunAnimate.SetTrigger("Shoot");
    }
}
