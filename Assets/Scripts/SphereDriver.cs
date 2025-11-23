using UnityEngine;

// Clase basada a PigMove
public class SphereDriver : MonoBehaviour
{
    [SerializeField] GameObject goal;

    [SerializeField] GameObject startingPosition;

    [SerializeField] float speed = 5f;

    Vector3 direction;

    Vector3 position;

    void Start()
    {
        position = this.transform.position;
    }

    private void LateUpdate()
    {
        direction = goal.transform.position - this.transform.position;

        this.transform.LookAt(goal.transform.position);

        // Si alguna esfera está a menos de 8f, se mueve hacia la cápusla, en caso contrario se detiene
        // Si está a menos de 1f, se detiene
        if (direction.magnitude > 1f && direction.magnitude < 8f)
        {
            Search(direction);
        }
        else if (direction.magnitude >= 8f)
        {
            Search(startingPosition.transform.position - this.transform.position);
        }
    }

    void Search(Vector3 dir)
    {
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;
        this.transform.position = this.transform.position + velocity;
    }

}
