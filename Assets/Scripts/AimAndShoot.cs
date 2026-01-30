using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet; //semente
    [SerializeField] private Transform bulletSpawnPoint; 

    private GameObject bulletInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }

    private void HandleGunShooting()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            //instanciar semente
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
        }
    }

    private void HandleGunRotation()
    {
        //rotacionar towards mouse
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        //converte de radiano pra degree
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // flip gun when it reaches 90 degrees
        Vector3 localScale= Vector3.one; //(1f,1f,1f)
        if (angle > 90 && angle < -90) //< -90
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        //mouseWorldPos.z = 0f;
        //Vector2 dir = (mouseWorldPos - transform.position).normalized;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
