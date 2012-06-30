// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ExchangeStartedWithPodsMessage.xml' the '27/06/2012 15:55:10'
using System;
using BiM.Core.IO;

namespace BiM.Protocol.Messages
{
	public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
	{
		public const uint Id = 6129;
		public override uint MessageId
		{
			get
			{
				return 6129;
			}
		}
		
		public int firstCharacterId;
		public int firstCharacterCurrentWeight;
		public int firstCharacterMaxWeight;
		public int secondCharacterId;
		public int secondCharacterCurrentWeight;
		public int secondCharacterMaxWeight;
		
		public ExchangeStartedWithPodsMessage()
		{
		}
		
		public ExchangeStartedWithPodsMessage(sbyte exchangeType, int firstCharacterId, int firstCharacterCurrentWeight, int firstCharacterMaxWeight, int secondCharacterId, int secondCharacterCurrentWeight, int secondCharacterMaxWeight)
			 : base(exchangeType)
		{
			this.firstCharacterId = firstCharacterId;
			this.firstCharacterCurrentWeight = firstCharacterCurrentWeight;
			this.firstCharacterMaxWeight = firstCharacterMaxWeight;
			this.secondCharacterId = secondCharacterId;
			this.secondCharacterCurrentWeight = secondCharacterCurrentWeight;
			this.secondCharacterMaxWeight = secondCharacterMaxWeight;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(firstCharacterId);
			writer.WriteInt(firstCharacterCurrentWeight);
			writer.WriteInt(firstCharacterMaxWeight);
			writer.WriteInt(secondCharacterId);
			writer.WriteInt(secondCharacterCurrentWeight);
			writer.WriteInt(secondCharacterMaxWeight);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			firstCharacterId = reader.ReadInt();
			firstCharacterCurrentWeight = reader.ReadInt();
			if ( firstCharacterCurrentWeight < 0 )
			{
				throw new Exception("Forbidden value on firstCharacterCurrentWeight = " + firstCharacterCurrentWeight + ", it doesn't respect the following condition : firstCharacterCurrentWeight < 0");
			}
			firstCharacterMaxWeight = reader.ReadInt();
			if ( firstCharacterMaxWeight < 0 )
			{
				throw new Exception("Forbidden value on firstCharacterMaxWeight = " + firstCharacterMaxWeight + ", it doesn't respect the following condition : firstCharacterMaxWeight < 0");
			}
			secondCharacterId = reader.ReadInt();
			secondCharacterCurrentWeight = reader.ReadInt();
			if ( secondCharacterCurrentWeight < 0 )
			{
				throw new Exception("Forbidden value on secondCharacterCurrentWeight = " + secondCharacterCurrentWeight + ", it doesn't respect the following condition : secondCharacterCurrentWeight < 0");
			}
			secondCharacterMaxWeight = reader.ReadInt();
			if ( secondCharacterMaxWeight < 0 )
			{
				throw new Exception("Forbidden value on secondCharacterMaxWeight = " + secondCharacterMaxWeight + ", it doesn't respect the following condition : secondCharacterMaxWeight < 0");
			}
		}
	}
}