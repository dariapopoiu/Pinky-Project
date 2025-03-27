using UnityEngine;
using UnityEngine.SceneManagement;


/// Vector3 --> 3 dimensional vector ex (x,y,z)
/// Vector2 --> 2 dimensional vector ex (x,y)
public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;/// cu serializefield 
                                                      ///pot vedea si in unity valoarea variabilei
                                                      /// 1:29:00    jason weimann how to make a game
    

    private void Awake()///poz initiala a pasarii pt launching
    {
        _initialPosition = transform.position;///pastram poz initiala
    }


    private void Update()
    { 
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1,_initialPosition);
       
        if ( _birdWasLaunched && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1 )
        {
            _timeSittingAround += Time.deltaTime;///deltatime= cat dureaza un frame in secunde 

        }
        if (transform.position.y > 15 ||
           transform.position.y < -10 ||
           transform.position.x < -15 ||
           transform.position.x > 40 ||
           _timeSittingAround > 3 )
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
    }


  private void OnMouseDown()///cat "tinem" pasarea ,este rosie
    {

        GetComponent<SpriteRenderer>().color = Color.red;

        GetComponent<LineRenderer>().enabled = true;

    }


    private void OnMouseUp()//lansam pasarea
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = -_initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
        ///in joc gravitatea e 0, iar gr=1 ajuta la caderea in arc
        ///
        GetComponent<LineRenderer>().enabled = false;
    }


    private void OnMouseDrag()///ca sa luam pasarea cu cursorul
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ///luam pozitia cursorului in fct de camera
        transform.position =new Vector3(newPosition.x, newPosition.y);
        ///vom putea tine pasarea cu cursorul,'urmarindu ne'
        /// pastram Z-ul pasarii, altfel se aproprie de camera si nu se mai "vede"
        
    }
}

