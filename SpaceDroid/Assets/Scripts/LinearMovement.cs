using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 1f;

    private Vector3 startPosition;
    private Vector3 currentTargetPosition;
    private Vector3 movementPerStep;
    private int remainingSteps;

    void Start()
    {
        startPosition = transform.position;
        currentTargetPosition = targetPosition;
        PrepareMovement();
    }

    void FixedUpdate()
    {
        if (remainingSteps <= 0)
        {
            return;
        }

        transform.position += movementPerStep;
        remainingSteps--;

        if (remainingSteps == 0)
        {
            transform.position = currentTargetPosition;

            Vector3 previousStart = startPosition;
            startPosition = currentTargetPosition;
            currentTargetPosition = previousStart;
            PrepareMovement();
        }
    }

    private void PrepareMovement()
    {
        if (speed <= 0f)
        {
            remainingSteps = 0;
            return;
        }

        float distance = Vector3.Distance(startPosition, currentTargetPosition);

        if (distance <= Mathf.Epsilon)
        {
            remainingSteps = 0;
            return;
        }

        float duration = distance / speed;
        remainingSteps = Mathf.Max(1, Mathf.CeilToInt(duration / Time.fixedDeltaTime));
        movementPerStep = (currentTargetPosition - startPosition) / remainingSteps;
    }
}