using System;
using System.Collections.Generic;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Exceptions;

namespace SignItNow.Helpers
{
	public class TaskElementsValidator: AbstractTaskHandler, ITaskElementsValidator 
	{
		public override object Handle(string taskName, List<User> signers)
		{
			ValidateTaskName(taskName);
			ValidateSigners(signers);

			return base.Handle(taskName, signers);
		}

		public void ValidateTaskName(string taskName)
		{
			if (string.IsNullOrEmpty(taskName.Trim()))
			{
				throw new TaskCreateException("Ви не ввели назву задачі!");
			}
		}

		public void ValidateSigners(List<User> signers)
		{
			if (signers == null || signers.Count == 0)
			{
				throw new TaskCreateException("Ви не додали підписантів!");
			}

			if (signers.Count > 15)
			{
				throw new TaskCreateException("Підписантів не може бути більше 15-и!");
			}
		}
	}
}