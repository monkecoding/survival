using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public int speed = 5;
    public GameObject[] weapons;
    public bool[] weaponsUnlocks;
    public Rigidbody2D playerRigidbody;
    int activeWeaponIndex, newWeaponIndex;

    public Camera mainCamera;

    Vector2 mousePosition;
    Vector2 playerMovement;

    void Start()
    {
        // Chek unlock weapon
        weaponsUnlocks = new bool[weapons.Length];
        weaponsUnlocks[0] = true;
        weaponsUnlocks[1] = false;
        weaponsUnlocks[2] = false;
    }

    void Update()
    {
        // Player's inputs
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Weapon 1"))
        {
            newWeaponIndex = 0;
            SwitchWeapon(0);
        }

        if (Input.GetButtonDown("Weapon 2"))
        {
            newWeaponIndex = 1;
            SwitchWeapon(1);
        }

        if (Input.GetButtonDown("Weapon 3"))
        {
            newWeaponIndex = 2;
            SwitchWeapon(2);
        }

    }

    private void FixedUpdate()
    {
        // Player's movement
        playerRigidbody.MovePosition(playerRigidbody.position + playerMovement * speed * Time.fixedDeltaTime);

        // Player's rotation
        Vector2 aimDirection = mousePosition - playerRigidbody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        playerRigidbody.rotation = aimAngle;
    }

    private void SwitchWeapon(int numberOfWeapon)
    {
        // Switch weapon controller
        switch (numberOfWeapon)
        {
            case 0:

                if (weaponsUnlocks[0] && activeWeaponIndex != newWeaponIndex)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                    activeWeaponIndex = newWeaponIndex;
                    Instantiate(weapons[0], gameObject.transform);
                }
                break;
            case 1:

                if (weaponsUnlocks[1] && activeWeaponIndex != newWeaponIndex)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                    activeWeaponIndex = newWeaponIndex;
                    Instantiate(weapons[1], gameObject.transform);
                }
                break;
            case 2:

                if (weaponsUnlocks[2] && activeWeaponIndex != newWeaponIndex)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                    activeWeaponIndex = newWeaponIndex;
                    Instantiate(weapons[2], gameObject.transform);
                }
                break;
            default:
            break;
        }
    }
}
