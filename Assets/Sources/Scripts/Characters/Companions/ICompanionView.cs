using UnityEngine;

namespace Sources.Scripts.Characters.Companions
{
	public interface ICompanionView
	{
		Transform transform { get; }

		ICompanionSetting CompanionSetting { get;  }
	}
}