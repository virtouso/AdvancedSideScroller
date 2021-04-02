﻿using Brainiac.Serialization;

namespace Brainiac
{
	public abstract class Service
	{
		[BTProperty("IsExpanded")]
		[BTHideInInspector]
		private bool m_isExpanded = true;

		[BTIgnore]
		public virtual string Title
		{
			get { return GetType().Name; }
		}

		[BTIgnore]
		public bool IsExpanded
		{
			get
			{
				return m_isExpanded;
			}
			set
			{
				m_isExpanded = value;
			}
		}

		public virtual void OnBeforeSerialize(BTAsset btAsset) { }
		public virtual void OnAfterDeserialize(BTAsset btAsset) { }

		public virtual void OnEnter(AIAgent agent) { }
		public virtual void OnExit(AIAgent agent) { }
		public abstract void OnExecute(AIAgent agent);
	}
}