﻿using Brainiac.Serialization;

namespace Brainiac
{
	public abstract class Constraint
	{
		[BTProperty("IsExpanded")]
		[BTHideInInspector]
		private bool m_isExpanded = true;
		[BTProperty("InvertResult")]
		[BTHideInInspector]
		private bool m_invertResult = false;

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

		[BTIgnore]
		public bool InvertResult
		{
			get
			{
				return m_invertResult;
			}
			set
			{
				m_invertResult = value;
			}
		}

		public virtual void OnBeforeSerialize(BTAsset btAsset) { }
		public virtual void OnAfterDeserialize(BTAsset btAsset) { }

		public bool OnExecute(AIAgent agent)
		{
			bool result = Evaluate(agent);
			return InvertResult ? !result : result;
		}

		protected abstract bool Evaluate(AIAgent agent);
	}
}