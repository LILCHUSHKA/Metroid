using UnityEngine;

//������������
public class PunchBouncePattern : BouncePattern
{
    //��������� �������� ����� � ����� ���������� �������� �������� isRetreat � ���. ������� ������������ ���������� ���
    void Punch() =>
        anim.Play("Punch");

    //�������� �����. � ��� ����� ����������� TakeDamage() �� ���������. ������ �� ������������ GiveDamage() - �� �����
    public void Attack() =>
        Debug.Log("Give damage");

    public override void ActivePattern() => Punch();
}