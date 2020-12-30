using UnityEngine;

public class CubePickup : MonoBehaviour
{
    public float throwDistance;
    Vector3 objectPos;
    float distance;

    public bool canHold;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    private void Update() {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance > 1f || distance < 0.05f) {
            isHolding = false;
        }

        if (isHolding == true) {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1)) {
                //throw
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwDistance);
                isHolding = false;
            }
        } else {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    private void OnMouseDown() {
        if (distance <= 1f || distance < 0.05f) {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
        
    }

    private void OnMouseUp() {
        isHolding = false;
    }
}
