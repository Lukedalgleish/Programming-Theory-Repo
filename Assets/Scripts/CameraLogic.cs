using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 cameraOffset = new Vector3(0, 0.64f, -0.41f); // we take away 1 from y due to the player pos being (0, 1, 0)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position  + cameraOffset;
    }
}
