public class PlayerMarcine : CharacterMarcine
{

    public override void Start()
    {
        base.Start(); 
        LinkUi();
    }
    public void Update()
    {
        SetAnimatorValue(CharacterAnimeBoolName.CanWalk, Walkable);
    }

    public void FixedUpdate()
    {
        currentBState?.Execute();
    }
}