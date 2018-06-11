using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField]
    GameObject reward;
    [SerializeField]
    Transform rewardPosition;

    Collider mycollider;
    public Material takenObjectMat;

    //impact look and feel variables
    float amplitude;
    float frequency;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    Animator anim;
    void Start()
    {
        mycollider = GetComponent<Collider>();
        posOffset = transform.position;
        anim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(reward, rewardPosition.position, Quaternion.identity);
            mycollider.enabled = false;
            anim.SetTrigger("Play");
            Impact();
            GetComponent<Renderer>().material = takenObjectMat;
            
        }
    }
    void Impact()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * 3 * frequency) * amplitude;

        transform.position = tempPos;
    }
}
