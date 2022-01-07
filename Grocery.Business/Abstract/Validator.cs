using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Abstract
{
    public interface Validator<T>
    {
        string ErorMessage { get; set; }
        bool Validate(T entity);

    }
}
