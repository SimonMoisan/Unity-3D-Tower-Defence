using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float panSpeed = 30f;
    [SerializeField] public float panBoarderThickness = 10f;
    [SerializeField] public float scrollSpeed = 2f;
    [SerializeField] public float minY = 10f;
    [SerializeField] public float maxY = 80f;

    private bool doMovement = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if(!doMovement)
        {
            return;
        }

        if(doMovement)
        {
            if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - panBoarderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("q") || Input.mousePosition.x <= panBoarderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
