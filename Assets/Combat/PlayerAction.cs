using System;

namespace Combat
{
	public record PlayerAction(string Name, Func<bool> MyFunc, Action MyAction);
}