using UnityEngine;

public class cameraController : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private float aheadDistance;
	[SerializeField] private float cameraSpeed;
	private float lookAhead_x;
    private float lookAhead_y;




    private void Update()
	{
		transform.position = new Vector3(player.position.x + lookAhead_x, player.position.y + lookAhead_y, transform.position.z);
		lookAhead_x = Mathf.Lerp(lookAhead_x, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
	}

    public void SetLookAheadY(float value)
    {
        lookAhead_y = value;
    }
}
