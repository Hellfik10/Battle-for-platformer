using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpButton = KeyCode.Space;
    private const KeyCode AttackButton = KeyCode.Mouse0;

    public float Horizontal { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsAttack { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis(nameof(Horizontal));

        if (Input.GetKeyDown(JumpButton))
        {
            IsJump = true;
        }
        else if (Input.GetKeyUp(JumpButton))
        {
            IsJump = false;
        }

        if (Input.GetKeyDown(AttackButton))
        {
            IsAttack = true;
        }
        else if (Input.GetKeyUp(AttackButton))
        {
            IsAttack= false;
        }
    }
}
