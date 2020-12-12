using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float amount = 0.9f;
    public float maxAmount = 2f;
    public float smoothAmount = 6f;

    private Vector3 initialPosition;

    private void Start() {
        initialPosition = transform.localPosition;
    }
    private void Update() {

        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

        Vector3 finalPosition = new Vector3(movementX, movementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
    }
}
