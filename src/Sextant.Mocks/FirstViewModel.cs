using System;
using System.Collections.Generic;
using System.Text;

namespace Sextant.Mocks
{
    /// <summary>
    /// The first View Model.
    /// </summary>
    /// <seealso cref="NavigableMock" />
    public class FirstViewModel
        : NavigableMock
    {
        /// <inheritdoc />
        public override string Id => nameof(FirstViewModel);
    }
}
