using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;/// sunt particulele de nori


   private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>() ;
        if (bird != null) ///daca dam de o pasare ( adica ce primim e != NULL)
        {
            Instantiate(_cloudParticlePrefab,transform.position, Quaternion.identity);///incepe particulele de nori
            ///Instatiate( obiect, pozitia enemy, rotatia particulelor)
            Destroy(gameObject);///se distruge dusmanul
            return;//gata!!
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();//analog ca la bird
        if(enemy != null)
        {
            return;///atat!! gata!!
        }

        if(collision.contacts[0].normal.y < -0.5)///daca a fost atins ON top 
                                                 ///acel contact normal ne da unghiul unde a fct contact
        {
            Instantiate(_cloudParticlePrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
