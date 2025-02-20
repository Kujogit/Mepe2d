using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletPoint; //tämä antaa mahdollisuuden drag-and-dropata weapon-scriptiin bulletpoint-emptyn
    public GameObject bullet;
    void Update()
    {
        if (FindFirstObjectByType<PauseMenu>().GameIsPaused) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() //Tämä on Shoot-funktio johon ylempi viittaa, että jos painat "Fire1" unityn controlleista, niin aja shoot. 
    {
        Instantiate(bullet, bulletPoint.position, transform.rotation ); //luo bullet bulletpointin positioon, rotaatiolla ei väliä ympyrän kanssa
    }
}
