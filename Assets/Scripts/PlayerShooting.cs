using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private int shotDelay = 0;
    //Object reference to the Bullet prefab
    public GameObject bullet;
    public GameObject body;
    //Tracks where the mouse is located
    public Vector3 mouseLocation;
    //Gets the place where the bullets are spawning from
    public Transform firePoint;

    /*
    public void shoot(InputAction.CallbackContext context){
        if (IsOwner){
        if (shotDelay == 0 && !GameManager.Instance.playerDead){
            GameObject bullet = AmmoPool.Instance.GetObject();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            Rigidbody2D bulrb = bullet.GetComponent<Rigidbody2D>();
            float thrust = 5f;
            bulrb.AddForce(firePoint.right * thrust, ForceMode2D.Impulse);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.shotSound);
            shotDelay = 20;
        }
        }
    }
    */

    void Update()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 aimDirect = new Vector2(mouseLocation.x, mouseLocation.y) - rb.position;
        float aimAngle = Mathf.Atan2(aimDirect.y, aimDirect.x) * Mathf.Rad2Deg;// - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, aimAngle);
        if (Input.GetButtonDown("GunFire")){
            Rigidbody2D rb2 = body.gameObject.GetComponent<Rigidbody2D>();
            //Debug.Log(aimDirect);
            //Note for later, this is based off the current location of the mouse v player to get the force, which is bad
            rb2.AddForce(-aimDirect, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        
        if (shotDelay > 0){
            shotDelay--;
        }   
    }
}
