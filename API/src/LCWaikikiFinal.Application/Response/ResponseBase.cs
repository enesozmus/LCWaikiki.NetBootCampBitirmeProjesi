using Newtonsoft.Json;

namespace LCWaikikiFinal.Application.Response
{
        public class ResponseBase<TKey>
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public TKey ResponseData { get; set; }
		public ResponseBase(TKey data)
		{
			ResponseData = data;
		}
	}
}
