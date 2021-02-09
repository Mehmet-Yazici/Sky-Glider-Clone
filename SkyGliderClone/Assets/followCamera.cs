
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float smoothSpeed= 4f;
    public Vector3 offset;
    Player player;
    public int speed = 5;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }


    void FixedUpdate()
    {
        
        if(player.EnteredTriggerOnce)
        {
            if (smoothSpeed < 0.8)
            {
                smoothSpeed += 0.08f * Time.deltaTime;
            }
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        
    }

    private void Update()
    {
        if (player.EnteredTriggerOnce)
        {
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed);
        }
        else
        {
            var targetRotation = Quaternion.LookRotation(target2.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed);
        } 
     }
}
