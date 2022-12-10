using UnityEngine;

public class Hands : MonoBehaviour
{
    [HideInInspector] public bool isHange;

    [SerializeField] Animator playerAnimator;
    [SerializeField] Rigidbody2D playerPhys;
    [SerializeField] Transform playerTransform;

    public void Grab(Transform ledge)
    {
        //���� � �� �������� ������ �����, ��� ������� ������� � ��������� ����� - �������� ��� ����.
        if (playerTransform.rotation.y == 0)
            playerTransform.position = new Vector2(playerTransform.transform.position.x + 0.1f, ledge.position.y);
        else
            playerTransform.position = new Vector2(playerTransform.transform.position.x - 0.1f, ledge.position.y);

        isHange = true;

        playerAnimator.SetBool("isFall", false);
        playerAnimator.SetBool("isHange", true);

        //������� - ���� ��
        playerPhys.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void Unhook()
    {
        isHange = false;

        playerAnimator.SetBool("isFall", true);
        playerAnimator.SetBool("isHange", false);

        playerPhys.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}