using System;
using System.Collections;
using System.Collections.Generic;
using Moq;

namespace UniAgile.Observable.Tests
{
    public static class Extensions
    {
        public class MockListenerFactory : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    CreateMockArray<Action>(1)
                };

                yield return new object[]
                {
                    CreateMockArray<Action>(10)
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private Mock<T>[] CreateMockArray<T>(int numberOfMocks)
                where T : class
            {
                var arr = new Mock<T>[numberOfMocks];

                for (var i = 0; i < numberOfMocks; i++) arr[i] = new Mock<T>();

                return arr;
            }
        }
    }
}