using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using AWSLambdaWorkflow;

namespace AWSLambdaWorkflow.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async void TestToUpperFunctionAsync()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            //var upperCase = function.FunctionHandler("hello world", context);
            var upperCase = function.FunctionHandler( context);
            
            Assert.Equal("OK", upperCase);
        }
    }
}
