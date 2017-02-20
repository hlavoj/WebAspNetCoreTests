using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAspNetCoreTests.Services
{
	public interface ICustomerSelectOptions
	{
		IEnumerable<SelectListItem> GetSelectListItems();
	}
}