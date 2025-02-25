using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletPoint; //t�m� antaa mahdollisuuden drag-and-dropata weapon-scriptiin bulletpoint-emptyn
    public GameObject bullet;

    public float fireRate = 1.0f;
    private float nextFireTime = 0;
    void Update()
    {
        if (FindFirstObjectByType<PauseMenu>().GameIsPaused) return;

        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot() //T�m� on Shoot-funktio johon ylempi viittaa, ett� jos painat "Fire1" unityn controlleista, niin aja shoot. 
    {
        Instantiate(bullet, bulletPoint.position, transform.rotation ); //luo bullet bulletpointin positioon, rotaatiolla ei v�li� ympyr�n kanssa
    }
}
