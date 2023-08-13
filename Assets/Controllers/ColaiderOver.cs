using UnityEngine;

public class ColaiderOver : MonoBehaviour
{
 public   Transform player;

   
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y-1f, player.position.z);

    }
}
