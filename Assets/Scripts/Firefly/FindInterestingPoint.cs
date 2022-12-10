using UnityEngine;

public class FindInterestingPoint : MonoBehaviour
{
    [SerializeField] int flyingSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InterestingPoint")
        {
            GetComponent<FireflyMover>().enabled = false;
            GetComponent<Talker>().talkArray = collision.GetComponent<PointTalker>().sentencesArray;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "InterestingPoint")
        {
            if (Vector3.Distance(transform.position, collision.GetComponent<GetPoint>().pointPosition) < 0.1f)
            {
                GetComponent<Talker>().Talk();
                collision.GetComponent<Collider2D>().enabled = false;
            }

            if (Vector3.Distance(transform.position, collision.GetComponent<GetPoint>().pointPosition) > 0.1f)
                FlyToInterestingPoint(collision.GetComponent<GetPoint>().pointPosition);
        }
    }

    void FlyToInterestingPoint(Vector3 flyingDirection) => 
            transform.position = Vector3.Lerp(transform.position, flyingDirection, Time.deltaTime * flyingSpeed);
}