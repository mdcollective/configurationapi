using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Api.Common.Http.Extensions
{
	/// <summary>
	/// IHeaderDictionary extension methods.
	/// </summary>
	public static class IHeaderDictionaryExtensions
	{
		/// <summary>
		/// Takes an IHeaderDictionary objects and converts x: y format.
		/// </summary>
		/// <param name="objs"></param>
		/// <returns></returns>
		public static string ToHeaderString(this IHeaderDictionary objs)
			=> objs.Aggregate(string.Empty, (current, obj) => current + $"{obj.Key}: {obj.Value};");
	}
}