using System.Collections.Generic;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;

namespace SignItNow.Helpers.Abstracts
{
	public class AbstractTaskHandler: ITaskHandler
	{
		private ITaskHandler _nextHandler;

		public ITaskHandler SetNext(ITaskHandler handler)
		{
			_nextHandler = handler;
			return handler;
		}

		public virtual object Handle(string taskName, List<User> signers)
		{
			object result = null;

			if (_nextHandler != null)
			{
				result = _nextHandler.Handle(taskName, signers);
			}

			return result;
		}

		public object Handle(int taskId, int documentId)
		{
			object result = null;

			if (_nextHandler != null)
			{
				result = _nextHandler.Handle(taskId, documentId);
			}

			return result;
		}

		public object Handle(int taskId, int userId, string comment)
		{
			object result = null;

			if (_nextHandler != null)
			{
				result = _nextHandler.Handle(taskId, userId, comment);
			}

			return result;
		}
	}
}