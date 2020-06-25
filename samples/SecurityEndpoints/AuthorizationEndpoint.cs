using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using System;

namespace SecurityEndpoints
{
    [EndpointMetadata(Name = "Authorization", SupportedRoles = SupportedRoles.None)]
    public class AuthorizationEndpoint : IAuthorizationEndpoint, IAuthenticationEndpoint
    {
        private const string TOKEN = "secretToken";
        private const string ROLE = "administrator";
        private const string PASSWORD = "secret";
        public string Authenticate(string authenticationString)
            => authenticationString == PASSWORD ? TOKEN : null;

        public byte[] ExecuteCustomAuthenticationCommand(byte[] command)
            => command;

        public bool IsInRole(string authenticationToken, string roleName)
            => authenticationToken == TOKEN && ROLE.Equals(roleName);
    }
}
