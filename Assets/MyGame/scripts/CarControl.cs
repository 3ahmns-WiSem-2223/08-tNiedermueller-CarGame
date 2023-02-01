using UnityEngine;

public class CarControl : MonoBehaviour
{

    [SerializeField]
    float movSpeed, mov;
    [SerializeField]
    float rotSpeed, rot;
    [SerializeField]
    bool kofferraum = false;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject gift;
    [SerializeField]
    GameObject[] spawnpoints;
    

    
    void Start()
    {
        spawn();   
    }

    
    
    
    
    
    void FixedUpdate()
    {
        rot = Input.GetAxis("Horizontal") * rotSpeed;
        mov = Input.GetAxis("Vertical") * movSpeed;

        transform.Translate(0, mov, 0);
        transform.Rotate(0, 0, -rot);
        
        
    }

    private void LateUpdate()
    {
        cam.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -15);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gift") && !kofferraum)
        {
            kofferraum = true;
            Destroy(other.gameObject);
            
            
        }

        


        if (other.CompareTag("abgabe"))
        {
            if (kofferraum)
            {
                Collected();
            }
            kofferraum = false;
        }

        if (other.CompareTag("wut"))
        {
            movSpeed += 0.1f;
            Destroy(other.gameObject);
            Invoke("SpeedDown", 3);
        }

    }


  


    void spawn()
    {
        int index = Random.Range(0, spawnpoints.Length);
        Instantiate(gift, spawnpoints[index].transform.position, Quaternion.identity);
    }



    void SpeedDown()
    {
        movSpeed -= 0.1f;
    }


    void Collected()
    {
        spawn();
    }


}
