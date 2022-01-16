using System;
using System.Threading.Tasks;
using Xunit;

namespace TestAsyncCBAwaitTaskWhenAll
{
    public class UnitTest1
    {
        static Task ExpectAsync(Func<Task> actionAsync)
        {
            return actionAsync();
        }

        static async Task ExpectLogNoWarningsNorErrors2(Func<Task> actionAsync)
        {
            await ExpectAsync(actionAsync: async () =>
                {
                    await actionAsync();
                });
        }

        [Fact]
        public async Task Test1()
        {
            await ExpectLogNoWarningsNorErrors2(async () =>
            {
                await Task.Delay(1000);
            });
        }
    }
}