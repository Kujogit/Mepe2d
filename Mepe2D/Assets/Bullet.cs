using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f; //vauhtiarvo
    public Rigidbody2D rb; //raahattava rigidbody
    public int damage = 50; //vahinkom‰‰r‰
    public LayerMask collisionLayers;
    //public gameObject impactEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //kutsutaan rigidbody-elementti bulletista ja laitetaan sille vauhtia kun se syntyy
        rb.linearVelocity = transform.right * speed;
        Destroy(gameObject, 5f);
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (((1 << hitInfo.gameObject.layer) & collisionLayers) == 0) //nyt on sen verran sakeata teksti‰ ett‰ en tajua lol
        {
            return;
        }

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);  
        //ylemm‰ll‰ saisi impact effectin, animaatio tai joku sellainen prefab

        Destroy(gameObject);
    }

}
