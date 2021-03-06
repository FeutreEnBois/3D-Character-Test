using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{

    public float turnSpeed = 15;
    public float aimDuration = 0.3f;

    Camera mainCamera;
    RaycastWeapon weapon;
    public Rig aimLayer;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<RaycastWeapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0),turnSpeed*Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (aimLayer)
        {
            if (Input.GetMouseButton(1))
            {
                aimLayer.weight += Time.deltaTime / aimDuration ;
            }
            else
            {
                aimLayer.weight -= Time.deltaTime / aimDuration ;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.StartFiring();
        }
        if (weapon.isFiring)
        {
            weapon.UpadateFiring(Time.deltaTime);
        }
        weapon.UpdateBullets(Time.deltaTime);
        if (Input.GetButtonUp("Fire1"))
        {
            weapon.StopFiring();
        }


    }
}
