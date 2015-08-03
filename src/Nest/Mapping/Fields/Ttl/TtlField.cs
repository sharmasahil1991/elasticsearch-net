﻿using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(ReadAsTypeConverter<TtlField>))]
	public interface ITtlField : ISpecialField
	{
		[JsonProperty("enabled")]
		bool? Enabled { get; set; }

		[JsonProperty("default")]
		string Default { get; set; }
	}

	public class TtlField : ITtlField
	{
		public bool? Enabled { get; set; }
		public string Default { get; set; }
	}

	public class TtlFieldDescriptor 
		: DescriptorBase<TtlFieldDescriptor, ITtlField>, ITtlField
	{
		bool? ITtlField.Enabled { get; set; }
		string ITtlField.Default { get; set; }

		public TtlFieldDescriptor Enable(bool enable = true) => Assign(a => a.Enabled = enable);

		public TtlFieldDescriptor Default(string defaultTtl) => Assign(a => a.Default = defaultTtl);
	}
}