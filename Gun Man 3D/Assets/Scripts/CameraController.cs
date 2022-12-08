using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool DoMovement = true;

    public float panSpeed;
    public float panBorderThickness;

    public float scrollspeed;

    //clamp move camera
    public float minY;
    public float maxY;

    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;

    void Update()
    {
        if(GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DoMovement = !DoMovement;
        }

        if (!DoMovement) return;

        if(Input.GetKey("w") || Input.mousePosition.y>=Screen.height - panBorderThickness) //up camera move
        {
            transform.Translate(Vector3.forward*panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) //down camera move
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) //left camera move
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)//right camera move
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollspeed * Time.deltaTime;
        
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
