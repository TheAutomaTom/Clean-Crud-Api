using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Infra.Models.Results
{
	public enum ErrorType
	{
		Unknown,
		Exception,

		Validation,

		ExpectedError,
		DoesNotExist,
		DistributedCacheError,

	}
}
