namespace ProjectAssets.Scripts.architecture.mvc.player
{
    public sealed class PlayerModel
    {
        public float Speed { get; set; } = 100f;
        public float JumpForce { get; set; } = 150f;
        public bool IsGrounded { get; set; }
    }
}