﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	using TemplateExistConverter = Func<IApiCallDetails, Stream, ExistsResponse>;

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IExistsResponse TemplateExists(Func<TemplateExistsDescriptor, TemplateExistsDescriptor> selector)
		{
			return this.Dispatcher.Dispatch<TemplateExistsDescriptor, TemplateExistsRequestParameters, ExistsResponse>(
				selector,
				(p, d) => this.LowLevelDispatch.IndicesExistsTemplateDispatch<ExistsResponse>(
					p.DeserializationState(new TemplateExistConverter(DeserializeExistsResponse))
				)
			);
		}

		/// <inheritdoc/>
		public IExistsResponse TemplateExists(ITemplateExistsRequest templateRequest)
		{
			return this.Dispatcher.Dispatch<ITemplateExistsRequest, TemplateExistsRequestParameters, ExistsResponse>(
				templateRequest,
				(p, d) => this.LowLevelDispatch.IndicesExistsTemplateDispatch<ExistsResponse>(
					p.DeserializationState(new TemplateExistConverter(DeserializeExistsResponse))
				)
			);
		}

		/// <inheritdoc/>
		public Task<IExistsResponse> TemplateExistsAsync(Func<TemplateExistsDescriptor, TemplateExistsDescriptor> selector)
		{
			return this.Dispatcher.DispatchAsync<TemplateExistsDescriptor, TemplateExistsRequestParameters, ExistsResponse, IExistsResponse>(
				selector,
				(p, d) => this.LowLevelDispatch.IndicesExistsTemplateDispatchAsync<ExistsResponse>(
					p.DeserializationState(new TemplateExistConverter(DeserializeExistsResponse))
				)
			);
		}

		/// <inheritdoc/>
		public Task<IExistsResponse> TemplateExistsAsync(ITemplateExistsRequest templateRequest)
		{
			return this.Dispatcher.DispatchAsync<ITemplateExistsRequest, TemplateExistsRequestParameters, ExistsResponse, IExistsResponse>(
				templateRequest,
				(p, d) => this.LowLevelDispatch.IndicesExistsTemplateDispatchAsync<ExistsResponse>(
					p.DeserializationState(new TemplateExistConverter(DeserializeExistsResponse))
				)
			);
		}

	}
}