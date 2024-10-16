namespace Combat
{
	public static class PlayerActions
	{
		public static readonly PlayerAction SKIP_TURN = new PlayerAction(
			"Skip Turn",
			() => true,
			() => {}
		);
		public static readonly PlayerAction DEFEND = new PlayerAction(
				"Defend",
				() => true,
				() => {}
			);
		public static readonly PlayerAction ATTACK = new PlayerAction(
			"Attack",
			() => true,
			() => {}
		);
	}
}