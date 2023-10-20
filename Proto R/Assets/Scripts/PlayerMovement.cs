using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public  Transform _camera;
    public float speed = 4;
    public float gravity = -9.8f;

    [SerializeField] float canShoot;
    [SerializeField] float shootingRate;
    [SerializeField] GameObject LightBulletPrefab;
    [SerializeField] GameObject DarkBulletPrefab;
    [SerializeField] Transform shootingPoint;

    // Start is called before the first frame update
    void Start()
    {
        _camera= Camera.main.transform;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hor, 0, ver);


        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        movement.y += gravity * Time.deltaTime;

        characterController.Move(movement);

        PlayerShoot();

    }
    void PlayerShoot()
    {
        canShoot += Time.deltaTime;

        if (Input.GetMouseButton(0) && canShoot > shootingRate)
        {
            Instantiate(LightBulletPrefab, shootingPoint.position, shootingPoint.rotation);
            canShoot = 0;
        }
        else if (Input.GetMouseButton(1) && canShoot > shootingRate)
        {
            Instantiate(DarkBulletPrefab, shootingPoint.position, shootingPoint.rotation);
            canShoot = 0;
        }
    }
}
