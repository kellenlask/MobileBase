using System;
using System.Threading;
using System.Threading.Tasks;


namespace MobileBase.Extensions
{
    public static class SemaphoreSlimExtensions
    {
        /// <summary>
        ///     Runs the given function under the given semaphore synchronously, catching any thrown Exceptions, and
        ///     releasing the lock regardless of outcome.
        /// </summary>
        /// <param name="semaphore">The semaphore to lock on</param>
        /// <param name="function">The function to run</param>
        /// <exception cref="Exception">Any Exception raised by the given function</exception>
        public static void Run(this SemaphoreSlim semaphore, Action function)
        {
            semaphore.Wait();

            try
            {
                function();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                semaphore.Release();
            }
        }


        /// <summary>
        ///     Runs a synchronous function with a return under the semaphore, ensuring that the semaphore is released
        ///     if an exception is encountered.
        /// </summary>
        /// <param name="semaphore">The semaphore to lock on</param>
        /// <param name="function">The function to run</param>
        /// <typeparam name="T">The type to be returned</typeparam>
        /// <returns>The result of the function or throws an exception (post-release)</returns>
        /// <exception cref="Exception">Any Exception raised by the given function</exception>
        public static T Get<T>(this SemaphoreSlim semaphore, Func<T> function)
        {
            semaphore.Wait();

            try
            {
                return function();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                semaphore.Release();
            }
        }


        /// <summary>
        ///     Runs the given async function under the given semaphore's lock, catching any thrown Exceptions, and
        ///     giving up the lock regardless of outcome. Obviously, you can use async to circumvent this whole flow,
        ///     but let's be good here. It is the opinion of this author that you can virtually always supply a
        ///     reasonable lock timeout, and so, you don't get any options.
        /// </summary>
        /// <param name="semaphore">The semaphore to lock on</param>
        /// <param name="function">The function to run</param>
        /// <param name="waitExpiration">The lock timeout to use while waiting on the lock</param>
        /// <exception cref="Exception">Any Exception raised by the given function</exception>
        public static async Task RunAsync(this SemaphoreSlim semaphore, Func<Task> function, TimeSpan waitExpiration)
        {
            var gotLock = await semaphore.WaitAsync(waitExpiration);

            if (!gotLock)
            {
                return;
            }

            try
            {
                await function();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                semaphore.Release();
            }
        }


        /// <summary>
        ///     Runs the given async function under the given semaphore's lock, catching any thrown Exceptions, and
        ///     giving up the lock regardless of outcome. Returns the function's output, or default(T) if the lock
        ///     timeout is hit. Obviously, you can use async to circumvent this whole flow, but let's be good here. It
        ///     is the opinion of this author that you can virtually always supply a reasonable lock timeout, and so,
        ///     you don't get any options.
        /// </summary>
        /// <param name="semaphore">The semaphore to lock on</param>
        /// <param name="function">The function to run</param>
        /// <param name="waitExpiration">The lock timeout to use while waiting on the lock</param>
        /// <typeparam name="T">The type to be returned</typeparam>
        /// <returns>The result of the function or throws an exception (post-release)</returns>
        /// <exception cref="Exception">Any Exception raised by the given function</exception>
        public static async Task<T> GetAsync<T>(
            this SemaphoreSlim semaphore,
            Func<Task<T>> function,
            TimeSpan waitExpiration
        )
        {
            var gotLock = await semaphore.WaitAsync(waitExpiration);

            if (!gotLock)
            {
                return default(T);
            }

            try
            {
                return await function();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}