﻿using System;
using System.Collections.Generic;
using System.Linq;
using BiM.Behaviors;
using BiM.Core.Messages;
using BiM.Core.Network;
using NLog;

namespace BiM.MITM.Network
{
    public class NetworkMessageDispatcher : MessageDispatcher
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly List<Message> m_logs = new List<Message>();

        public NetworkMessageDispatcher()
        {
        }

        public IClient Client
        {
            get;
            set;
        }

        public IClient Server
        {
            get;
            set;
        }

        protected override void Dispatch(Message message, object token)
        {
            m_logs.Add(message);

            if (message == null) throw new ArgumentNullException("message");
            if (message is NetworkMessage)
                Dispatch(message as NetworkMessage, token);
            else
                base.Dispatch(message, token);
        }

        protected void Dispatch(NetworkMessage message, object token)
        {
            if (message == null) throw new ArgumentNullException("message");

            try
            {
                if (message.Destinations.HasFlag(ListenerEntry.Local))
                {
                    InternalDispatch(message, token);
                }

                if (Client != null && message.Destinations.HasFlag(ListenerEntry.Client))
                {
                    Client.Send(message);
                }

                if (Server != null && message.Destinations.HasFlag(ListenerEntry.Server))
                {
                    Server.Send(message);
                }

                message.OnDispatched();
                OnMessageDispatched(message);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Cannot dispatch {0}", message), ex);
            }
        }

        private void InternalDispatch(NetworkMessage message, object token)
        {
            if (message == null) throw new ArgumentNullException("message");
            var handlers = GetHandlers(message.GetType(), token).ToArray(); // have to transform it into a collection if we want to add/remove handler
            

            foreach (var handler in handlers)
            {
                if (handler.Attribute.DestinationFilter != ListenerEntry.Undefined &&
                    handler.Attribute.DestinationFilter != message.Destinations && 
                    (handler.Attribute.DestinationFilter & message.Destinations) == ListenerEntry.Undefined)
                    continue;

                if (handler.Attribute.FromFilter != ListenerEntry.Undefined && 
                    handler.Attribute.FromFilter != message.From &&
                    (handler.Attribute.FromFilter & message.From) == ListenerEntry.Undefined)
                    continue;

                handler.Action(handler.Container, token, message);

                if (message.Canceled)
                    break;
            }
        }
    }
}