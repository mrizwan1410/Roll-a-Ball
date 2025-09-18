using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
