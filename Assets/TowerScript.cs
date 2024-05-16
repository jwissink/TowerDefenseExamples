using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float radius;
    public float delay;
    private float timer;

    public GameObject bullet;
    public GameObject barrel;
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f; 
        if (!barrel)
        {
            barrel = transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            target = GetClosestTarget();
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer < 0.0f)
            {
                timer = delay;
                barrel.transform.LookAt(target.transform.position);
                Shoot();
            }
        }
    }

    GameObject GetClosestTarget()
    {
        RaycastHit hit;

        if(Physics.SphereCast(transform.position, radius, Vector3.right, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    void Shoot()
    {
        GameObject obj = Instantiate(bullet);
        obj.transform.position = barrel.transform.position;
        obj.transform.rotation = barrel.transform.rotation;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }

}
