// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'GameRolePlayNpcWithQuestInformations.xml' the '27/06/2012 15:55:15'
using System;
using BiM.Core.IO;

namespace BiM.Protocol.Types
{
	public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
	{
		public const uint Id = 383;
		public override short TypeId
		{
			get
			{
				return 383;
			}
		}
		
		public Types.GameRolePlayNpcQuestFlag questFlag;
		
		public GameRolePlayNpcWithQuestInformations()
		{
		}
		
		public GameRolePlayNpcWithQuestInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, short npcId, bool sex, short specialArtworkId, Types.GameRolePlayNpcQuestFlag questFlag)
			 : base(contextualId, look, disposition, npcId, sex, specialArtworkId)
		{
			this.questFlag = questFlag;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			questFlag.Serialize(writer);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			questFlag = new Types.GameRolePlayNpcQuestFlag();
			questFlag.Deserialize(reader);
		}
	}
}