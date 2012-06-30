// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'CharacterSelectedErrorMissingMapPackMessage.xml' the '27/06/2012 15:54:58'
using System;
using BiM.Core.IO;

namespace BiM.Protocol.Messages
{
	public class CharacterSelectedErrorMissingMapPackMessage : CharacterSelectedErrorMessage
	{
		public const uint Id = 6300;
		public override uint MessageId
		{
			get
			{
				return 6300;
			}
		}
		
		public int subAreaId;
		
		public CharacterSelectedErrorMissingMapPackMessage()
		{
		}
		
		public CharacterSelectedErrorMissingMapPackMessage(int subAreaId)
		{
			this.subAreaId = subAreaId;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(subAreaId);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			subAreaId = reader.ReadInt();
			if ( subAreaId < 0 )
			{
				throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
			}
		}
	}
}