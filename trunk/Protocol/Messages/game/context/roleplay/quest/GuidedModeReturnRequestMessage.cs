// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'GuidedModeReturnRequestMessage.xml' the '27/06/2012 15:55:05'
using System;
using BiM.Core.IO;

namespace BiM.Protocol.Messages
{
	public class GuidedModeReturnRequestMessage : NetworkMessage
	{
		public const uint Id = 6088;
		public override uint MessageId
		{
			get
			{
				return 6088;
			}
		}
		
		
		public override void Serialize(IDataWriter writer)
		{
		}
		
		public override void Deserialize(IDataReader reader)
		{
		}
	}
}