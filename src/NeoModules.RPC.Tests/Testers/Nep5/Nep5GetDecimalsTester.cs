using System;
using System.Threading.Tasks;
using NeoModules.JsonRpc.Client;
using NeoModules.RPC.DTOs;
using NeoModules.RPC.Services.Nep5;
using Xunit;

namespace NeoModules.RPC.Tests.Testers
{
    public class Nep5GetDecimalsTester : RpcRequestTester<Invoke>
    {
        [Fact]
        public async void ShouldReturnDecimals()
        {
            var result = await ExecuteAsync();
            Assert.NotNull(result.Stack[0].Value);
        }

        public override async Task<Invoke> ExecuteAsync(IClient client)
        {
            var decimals = new TokenDecimals(client, Settings.GetNep5TokenHash());
            return await decimals.SendRequestAsync();
        }

        public override Type GetRequestType()
        {
            return typeof(Invoke);
        }
    }
}
