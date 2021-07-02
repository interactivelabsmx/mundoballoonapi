using System;
using System.Collections.Generic;

namespace MundoBalloonApi.graphql.Common.Requests
{
    public class PayloadBase : ClientMutationBase
    {
        protected PayloadBase()
        {
            Errors = Array.Empty<UserError>();
        }

        protected PayloadBase(IReadOnlyList<UserError> errors)
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError> Errors { get; }
    }
}