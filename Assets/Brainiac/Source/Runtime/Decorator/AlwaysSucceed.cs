﻿using UnityEngine;

namespace Brainiac
{
	[AddNodeMenu("Decorator/Always Succeed")]
	public class AlwaysSucceed : Decorator
	{
		public override string Title
		{
			get
			{
				return "Always Succeed";
			}
		}

		protected override BehaviourNodeStatus OnExecute(AIAgent agent)
		{
			BehaviourNodeStatus status = BehaviourNodeStatus.Success;
			if(m_child != null)
			{
				status = m_child.Run(agent);
				if(status != BehaviourNodeStatus.Running)
				{
					status = BehaviourNodeStatus.Success;
				}
			}

			return status;
		}
	}
}