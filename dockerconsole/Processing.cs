using dockerconsole.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dockerconsole
{
    public class Processing
    {
        private readonly testdbContext _testdbContext;

        public Processing(testdbContext testdbContext)
        {
            _testdbContext = testdbContext;
        }


        public async Task DoSomethingAsync()
        {
            for (int i = 0; i < 100; i++)
            {
                _testdbContext.Add(new Log()
                {
                    LogData = $"Iteration: {i}  at time: {DateTime.Now}"
                });
            }

            await _testdbContext.SaveChangesAsync();

            //return true;
        }
    }
}
