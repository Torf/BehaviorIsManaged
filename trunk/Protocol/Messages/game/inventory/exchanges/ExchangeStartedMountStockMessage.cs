// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ExchangeStartedMountStockMessage.xml' the '27/06/2012 15:55:10'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;

namespace BiM.Protocol.Messages
{
	public class ExchangeStartedMountStockMessage : NetworkMessage
	{
		public const uint Id = 5984;
		public override uint MessageId
		{
			get
			{
				return 5984;
			}
		}
		
		public IEnumerable<Types.ObjectItem> objectsInfos;
		
		public ExchangeStartedMountStockMessage()
		{
		}
		
		public ExchangeStartedMountStockMessage(IEnumerable<Types.ObjectItem> objectsInfos)
		{
			this.objectsInfos = objectsInfos;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort((ushort)objectsInfos.Count());
			foreach (var entry in objectsInfos)
			{
				entry.Serialize(writer);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			int limit = reader.ReadUShort();
			objectsInfos = new Types.ObjectItem[limit];
			for (int i = 0; i < limit; i++)
			{
				(objectsInfos as Types.ObjectItem[])[i] = new Types.ObjectItem();
				(objectsInfos as Types.ObjectItem[])[i].Deserialize(reader);
			}
		}
	}
}