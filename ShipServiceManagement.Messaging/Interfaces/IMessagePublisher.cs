﻿using ShipServiceManagement.Messaging.Extensions;
using System.Threading.Tasks;

namespace ShipServiceManagement.Messaging.Interfaces
{
	public interface IMessagePublisher
	{
		/// <summary>
		/// Publishes the message asynchronous.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="messageType">Type of the message.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		Task PublishMessageAsync<T>(MessageTypes messageType, T message);
	}
}
