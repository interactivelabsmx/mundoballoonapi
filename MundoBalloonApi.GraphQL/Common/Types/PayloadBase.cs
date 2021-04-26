using System;
using System.Collections.Generic;

namespace MundoBalloonApi.graphql.Common.Types
{
    public class PayloadBase : ClientMutationBase
    {
        protected PayloadBase() : base()
        {
            Errors = Array.Empty<UserError>();
        }

        protected PayloadBase(IReadOnlyList<UserError> errors) : base()
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError> Errors { get; }
    }
}