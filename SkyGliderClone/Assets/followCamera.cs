
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float smoothSpeed= 4f;
    Vector3 offset = new Vector3(0f,5f,-30f);
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
            Vector3 newOffset;

            if (player.Slowdown)
            {

                //newOffset = Quaternion.Inverse(Quaternion.Euler(player.playerTransform.up)) * offset;
                //newOffset = new Vector3(offset.x * player.playerTransform.up.x, offset.y * player.playerTransform.up.y, offset.z * player.playerTransform.up.z);
                offset = new Vector3(-30 * player.playerTransform.up.x, 5f, -30f * player.playerTransform.up.z);
                newOffset = offset;
            }
            else
            {
                newOffset = offset;
            }

            Debug.Log(player.playerTransform.up);

            Vector3 desiredPosition = target.position + newOffset;
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
